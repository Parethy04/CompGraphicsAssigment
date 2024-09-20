using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static Controls controls;
    
    //Activates player controls;
    public static void Init(Player player)
    {
        controls = new Controls();

        controls.InGame.Movement.performed += _ =>
        {
            player.SetMoveDirection(_.ReadValue<Vector3>());
        };
        controls.InGame.Sprint.performed += _ =>
        {
            player.startSprint();
        };
        controls.InGame.Sprint.canceled += _ =>
        {
            player.cancelSprint();   
        };
    }
    public static void InitCam() 
    { 
        controls = new Controls();
         controls.InGame.Mouse.performed += _ =>
        {
            print(_.ReadValue<Vector2>());
        };
    }
    public static void EnableInGame()
    {
        controls.InGame.Enable();
    }
    public static void DisableInGame()
    {
        controls.InGame.Disable();
    }

}
