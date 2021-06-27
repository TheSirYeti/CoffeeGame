using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Jumping()
    {
        EventManager.Trigger("Jumping");
    }

    public void Landing()
    {
        EventManager.Trigger("Landing");
    }
}
