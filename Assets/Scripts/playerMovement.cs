using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


/*
 * Script By Isak Sørøy
 * first created: 05.Sep 2023
 * Last Updated: 7.Nov 2023
 * Ver. 0.2
 */



public class playerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sideWayMultiply = 0.5f;
    [SerializeField] private float mouseSens = 2f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float rayReach = 1f;
    [SerializeField] private float rayRadius = 1f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject respawnPoint;
    public bool canMove = true;



    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            playerInput();
            PlayerCameraControl();
        }

        RaycastHit hit;

        isGrounded = Physics.SphereCast(transform.position, rayRadius, Vector3.down, out hit, rayReach, groundLayer);


        if (this.transform.position.y < -100)
        {
            this.transform.position = respawnPoint.transform.position;
        }


    }



    private void PlayerCameraControl()
    {   
        //The following code controlls the camera, first checks for mouse input, then rotates the player left and right, and then rotates the camera up and down.
        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            //Debug.Log("Camera moved");

            transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * mouseSens, 0);
            playerCamera.transform.eulerAngles -= new Vector3(Input.GetAxis("Mouse Y") * mouseSens, 0, 0);
        }
    }




    private void playerInput()  // Controls wasd for movement
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime * sideWayMultiply;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime * sideWayMultiply;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                GetComponent<Rigidbody>().velocity = Vector3.up * jumpHeight;
                //Debug.Log("Jumped");
            } else {
                //Debug.Log("Not grounded");
            }

        }
        

    }



    //private void OnCollisionStay(Collision collision) //Has the side effect of wall jumping
    //{
    //    isGrounded = true;
    //}

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

}
