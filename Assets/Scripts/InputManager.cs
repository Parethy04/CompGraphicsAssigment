using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
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
