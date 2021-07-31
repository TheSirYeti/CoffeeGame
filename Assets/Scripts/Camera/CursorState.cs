using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP Final - Juan Cruz Cristófalo
public class CursorState : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //Locks and hides the cursor
        Cursor.visible = false;
    }

    public void end()
    {
        Cursor.lockState = CursorLockMode.None;    //Shows the cursor and unlocks it
        Cursor.visible = true;
    }
}
