using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void end()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
