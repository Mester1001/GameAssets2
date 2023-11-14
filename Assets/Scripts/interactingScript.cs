using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Script By Isak Sørøy
 * first created: 08.Nov 2023
 * Last Updated: 14.Nov 2023
 * Ver. 0.2
 */


public class interactingScript : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask interactive;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftHand;
    private GameObject leftHandContent;
    [SerializeField] private GameObject flashlight;
    [SerializeField] private GameObject fuse;
    [SerializeField] private GameObject generator;
    [SerializeField] private GameObject sharkSubKey;
    [SerializeField] private GameObject sharkSub;
    private bool leftHandFull = false;
    [SerializeField] private GameObject flashlightScript;
    private GameObject rayCollider;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //RaycastHit hit;
        //If press E do this:
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5))
            {
                rayCollider = hit.collider.gameObject;
                /*Debug.Log("Found something");
                Debug.DrawLine(ray.origin, hit.point);
                Debug.Log("Hit: " + hit.collider);
                Debug.Log(rayCollider);*/
                //Debug.Log("is: " + rayCollider.gameObject.layer + " = " + 7);

                //If the Object hit by the raycast is on layer 7 (Interactive) then continue in code.
                if (rayCollider.gameObject.layer == 7)
                {
                    //trying to move the collided object into rightHand if flashlight. otherwise if left is empty place collided object in left hand. 
                    if (rayCollider.gameObject == flashlight)
                    {
                        flashlightScript.GetComponent<Flashlight>().hasFlashlight = true;
                        rayCollider.gameObject.transform.parent = rightHand.transform;
                        rayCollider.gameObject.transform.position = rightHand.transform.position;
                        rayCollider.gameObject.transform.rotation = rightHand.transform.rotation;
                    }
                    else if (!leftHandFull && (rayCollider.gameObject == fuse || rayCollider.gameObject == sharkSubKey))
                    {
                        leftHandFull = true;
                        leftHandContent = rayCollider.gameObject;
                        Debug.Log("Left hand picked up: " + rayCollider.gameObject);
                        leftHandContent.transform.parent = leftHand.transform;
                        leftHandContent.transform.position = leftHand.transform.position;
                        leftHandContent.transform.rotation = leftHand.transform.rotation;
                    }

                    //If player has fuse place fuse in generator.
                    if (fuse == leftHandContent && rayCollider.gameObject == generator)
                    {
                        Debug.Log("Generator found, fuse placed");
                        leftHandContent.transform.parent = rayCollider.gameObject.transform.GetChild(0).gameObject.transform;
                        leftHandContent.transform.position = rayCollider.gameObject.transform.GetChild(0).gameObject.transform.position;
                        leftHandContent.transform.rotation = rayCollider.gameObject.transform.GetChild(0).gameObject.transform.rotation;
                        leftHandFull = false;
                        leftHandContent = null;

                        //Remember to do whatever the generator will do.

                    }

                    if (sharkSubKey == leftHandContent && rayCollider.gameObject == sharkSub)
                    {
                        Debug.Log("Game Won");
                        leftHandContent.transform.parent = rayCollider.gameObject.transform;
                        leftHandContent.transform.position = rayCollider.gameObject.transform.position;
                        leftHandContent.transform.rotation = rayCollider.gameObject.transform.rotation;
                        leftHandFull = false;
                        leftHandContent = null;

                        //Remember to do whatever Winning will do.

                    }



                }
            }
        }


        






    }
}
