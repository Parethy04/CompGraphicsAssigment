using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Sprinting
    private bool isSprinting; 
    [SerializeField]  float sprintTime;
    private bool onCoolDown;
    [SerializeField] private float maxSprintTime;
    //Camera location
    private Transform CamTransform;

    //standard movement
    [SerializeField] float moveSpeed;
    Rigidbody rb;
    private Vector3 smoothedMoveDir;
    private Vector3 smoothedMoveVelo;
    private Vector3 moveDir;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InputManager.Init(this);
        InputManager.EnableInGame();
        CamTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (isSprinting )
        {
            sprintTime -= Time.deltaTime;
            if (sprintTime >= 0)
            {
                rb.velocity = smoothedMoveDir * (moveSpeed * 1.5f);
            }
            else if (sprintTime <= 0)
            {
                StartCoroutine(Cooldown(2));
                isSprinting = false;
                rb.velocity = Vector3.zero; 
                sprintTime = 0;
            }
        }
     


          if (!isSprinting ||  sprintTime <= 0 )
        {
            if (sprintTime <= 2 || sprintTime <= maxSprintTime)
            {
                if (!onCoolDown)
                {
                    sprintTime += Time.deltaTime;
                }
                
            }


               
            
        } 
        
    }
    private void FixedUpdate()
    {
        //smoothed movement
        smoothedMoveDir = Vector3.SmoothDamp(smoothedMoveDir, moveDir, ref smoothedMoveVelo, 0.1f);
        smoothedMoveDir = CamTransform.forward * moveDir.z + CamTransform.right * moveDir.x;
          
        
        rb.velocity = new Vector3 (smoothedMoveDir.x * moveSpeed,-3, smoothedMoveDir.z * moveSpeed);

    }

    //this handles movement 
    public void SetMoveDirection(Vector3 newDir)
    {
        moveDir = newDir;
    }

    public void startSprint()
    {
        isSprinting = true;
    }

    public void cancelSprint()
    {
        isSprinting = false;
        
    }

    public IEnumerator Cooldown(float maxCoolDown)
    {
        onCoolDown = true;
        yield return new WaitForSeconds(maxCoolDown);
        onCoolDown = false;
    }



    }
    

