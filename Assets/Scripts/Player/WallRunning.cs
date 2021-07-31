using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Movement;

//TP Final - Juan Pablo Rshaid
public class WallRunning : MonoBehaviour
{
    public bool isWallRight;
    public bool isWallLeft;
    public bool isWallRunning;
    public LayerMask wallLayer;
    public Transform orientation;

    public float wallForce;
    public Rigidbody rb;

    private void FixedUpdate()
    {
        CheckForWalls();
    }

    void CheckForWalls()
    {
        isWallRight = Physics.Raycast(transform.position, orientation.right, 3f, wallLayer);
        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 3f, wallLayer);

        if (Input.GetKey(KeyCode.D) && isWallRight) StartWallRun();
        if (Input.GetKey(KeyCode.A) && isWallLeft) StartWallRun();

        if (!isWallRight && !isWallLeft)
        {
            StopWallRun();
        }
    }

    void StartWallRun()
    {
        if (!isWallRunning)
        {
            SoundManager.instance.PlaySound(SoundID.WALLRUN);
        }
        rb.useGravity = false;
        isWallRunning = true;
    }

    void StopWallRun()
    {
        SoundManager.instance.StopSound(SoundID.WALLRUN);
        rb.useGravity = true;
        isWallRunning = false;
    }
}
