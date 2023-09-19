using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


/*
 * Script By Isak Sørøy
 * 05.Sep 2023
 * 
 */



public class playerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSens = 2f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float rayReach = 1f;
    [SerializeField] private float rayRadius = 1f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private LayerMask groundLayer;



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
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space)) 
        {
            if (isGrounded == true) 
            { 
                GetComponent<Rigidbody>().velocity = Vector3.up * jumpHeight;
                Debug.Log("Jumped");
            } else {
                Debug.Log("Not grounded");
            }
            
        }


    }


    //private void Awake() //Gets called before start
    //{
    //    Rigidbody = GetComponent<Rigidbody>();
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        playerInput();

        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            //Debug.Log("Camera moved");

            transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * mouseSens, 0);
            playerCamera.transform.eulerAngles -= new Vector3(Input.GetAxis("Mouse Y") * mouseSens, 0, 0);
        }







        RaycastHit hit;

        isGrounded = Physics.SphereCast(transform.position, rayRadius, Vector3.down, out hit, rayReach, groundLayer);
        
        
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, rayReach, groundLayer);


        
        /*
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(horizontalAxis, 0f, verticalAxis) * moveSpeed * Time.deltaTime;

        transform.position += velocity; 
            
        rigidbody.AddForce(velocity * 10, ForceMode.Force); 

        */




    }



    //private void OnCollisionStay(Collision collision) //Side Effect of wall jumping
    //{
    //    isGrounded = true;
    //}

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

}
