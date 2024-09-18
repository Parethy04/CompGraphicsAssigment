using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isSprinting; 
    [SerializeField] float moveSpeed;
    private Vector3 smoothedMoveDir;
    private Vector3 smoothedMoveVelo;
    private Vector3 moveDir;
    [SerializeField]  float sprintTime;
    private Transform CamTransform;
    Rigidbody rb;
    private float coolDown;
    private bool onCoolDown;


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
                isSprinting = false;
                rb.velocity = Vector3.zero; 
                sprintTime = 0;
                StartCoroutine(Cooldown(2));
            }
        }
     


          if (!isSprinting ||  sprintTime <= 0 )
        {
            if (sprintTime <= 2 || sprintTime <= 5)
            {
                if (onCoolDown)
                {
                    StartCoroutine(Cooldown(10));
                }

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
        smoothedMoveDir.y = 0;
        rb.velocity = smoothedMoveDir * moveSpeed;
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

    private IEnumerator Cooldown(float maxCoolDown)
    {
        if (onCoolDown)
        {
            coolDown -= Time.deltaTime;
            coolDown = maxCoolDown;
            onCoolDown = false;
            yield return new WaitUntil(() => coolDown <= 0 );
            onCoolDown = true;
            yield break;
        }

        if (onCoolDown) yield break;


    }
    
}
