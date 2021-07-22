using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Movement;

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
        isWallRight = Physics.Raycast(transform.position, orientation.right, 2f, wallLayer);
        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 2f, wallLayer);

        if (Input.GetKeyDown(KeyCode.D) && isWallRight) StartWallRun();
        if (Input.GetKeyDown(KeyCode.A) && isWallLeft) StartWallRun();

        if (isWallRunning)
        {
            if (isWallRight)
            {
                rb.AddForce(orientation.right * (wallForce / 5) * Time.deltaTime);
            } else rb.AddForce(-orientation.right * (wallForce / 5) * Time.deltaTime);
        }


        if (!isWallRight && !isWallLeft)
        {
            StopWallRun();
        }
    }

    void StartWallRun()
    {
        //GetComponent<PlayerMovement>().enabled = false;
        rb.useGravity = false;
        isWallRunning = true;
        rb.AddForce(orientation.forward * wallForce * Time.deltaTime);
    }

    void StopWallRun()
    {
        //GetComponent<PlayerMovement>().enabled = true;
        rb.useGravity = true;
        isWallRunning = false;
    }
}
