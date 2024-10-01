using Cinemachine;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    [SerializeField] AudioSource sound;
    [SerializeField] CinemachineVirtualCamera cineCam;
    Camera playerCam;
    public bool dead;
    [SerializeField] GameObject enemylookat;
    private Vector3 mousePos;
    RaycastHit hit;
  
    void Start()
    {

        playerCam = gameObject.GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
        InputManager.Init(this);
        InputManager.EnableInGame();
        CamTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        /*
        Input.GetMouseButtonDown(0);
        {
            Mouse mouse = Mouse.current;
            if (mouse.leftButton.wasPressedThisFrame)
            {
                mousePos = playerCam.ScreenToWorldPoint(InputManager.GetMousePos());

              
                Ray ray = playerCam.ScreenPointToRay(mousePos);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 10);
                    print(hit.collider.name);
                }

            }
        }
    */

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
        if (!dead)
        {
            //smoothed movement
            smoothedMoveDir = Vector3.SmoothDamp(smoothedMoveDir, moveDir, ref smoothedMoveVelo, 0.1f);
            smoothedMoveDir = CamTransform.forward * moveDir.z + CamTransform.right * moveDir.x;


            rb.velocity = new Vector3(smoothedMoveDir.x * moveSpeed, -3, smoothedMoveDir.z * moveSpeed);
        }
        

    }

    //this handles movement 
    public void SetMoveDirection(Vector3 newDir)
    {
        if (!dead)
        {
            moveDir = newDir;
        }
        
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Exit"))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("WinArea");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            dead = true;
            StartCoroutine(LookatDeath());
        }
    }
    public IEnumerator LookatDeath()
    {
        cineCam.Priority = 0;
        sound.Play();
        yield return new WaitForSeconds (3);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }


}
    

