using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamMovement : MonoBehaviour
{
    private CinemachineInputProvider pov;
    private Vector3 startingPos;
    [SerializeField] float clampAngle;
    private CinemachineVirtualCamera Vcam;



    private void Start()
    {
        pov = GetComponent<CinemachineInputProvider>();
        Vcam = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {

        startingPos = transform.localRotation.eulerAngles;
        startingPos.x += pov.GetAxisValue(0) * Time.deltaTime;
        startingPos.y += pov.GetAxisValue(1) * Time.deltaTime;
        startingPos.y = Mathf.Clamp(startingPos.y, -clampAngle, clampAngle);
        Vcam.transform.rotation = Quaternion.Euler(-startingPos.y, startingPos.x, 0f);

    }

}
