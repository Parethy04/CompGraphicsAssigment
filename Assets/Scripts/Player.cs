using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Vector3 smoothedMoveDir;
    private Vector3 smoothedMoveVelo;
    private Vector3 moveDir;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InputManager.Init(this);
        InputManager.EnableInGame();
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //smoothed movement
        smoothedMoveDir = Vector3.SmoothDamp(smoothedMoveDir, moveDir, ref smoothedMoveVelo, 0.1f);
        rb.velocity = smoothedMoveDir * moveSpeed;
    }

    //this handles movement 
    public void SetMoveDirection(Vector3 newDir)
    {
        moveDir = newDir;
    }
}
