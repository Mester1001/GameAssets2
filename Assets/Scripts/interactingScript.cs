using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/*
 * Script By Isak Sørøy
 * first created: 08.Nov 2023
 * Last Updated: 16.Nov 2023
 * Ver. 0.3
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
    [SerializeField] private GameObject UIReference;
    [SerializeField] private GameObject consoleButton;
    private bool leftHandFull = false;
    [SerializeField] private GameObject flashlightScript;
    [SerializeField] private GameObject lightsParent;
    private GameObject rayCollider;






    // Update is called once per frame
    void Update()
    {
        
        //RaycastHit hit;
        //If press E do this:
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3))
            {
                rayCollider = hit.collider.gameObject.gameObject;
                Debug.Log("I hit: " + rayCollider);

                //If the Object hit by the raycast is on layer 7 (Interactive) then continue in code.
                if (rayCollider.layer == 7)
                {


                    if (rayCollider.GetComponent<interacteble>())   //If the raycast hits a object with an interacteble class it will try to use it.
                    {
                        rayCollider.GetComponent<interacteble>().interacted();
                        return;
                    }


                    //trying to move the collided object into rightHand if flashlight. otherwise if left is empty place collided object in left hand. 
                    if (rayCollider == flashlight)
                    {

                        flashlightScript.GetComponent<Flashlight>().hasFlashlight = true;
                        rayCollider.transform.parent = rightHand.transform;
                        rayCollider.transform.position = rightHand.transform.position;
                        rayCollider.transform.rotation = rightHand.transform.rotation;
                    }
                    else if (!leftHandFull && (rayCollider == fuse || rayCollider == sharkSubKey)) //If the raycast hits either the fuse or keys and left hand is empty, place object on left hand.
                    {
                        leftHandFull = true;
                        leftHandContent = rayCollider;
                        Debug.Log("Left hand picked up: " + rayCollider);
                        leftHandContent.transform.parent = leftHand.transform;
                        leftHandContent.transform.position = leftHand.transform.position;
                        leftHandContent.transform.rotation = leftHand.transform.rotation;
                        if (rayCollider == sharkSubKey) { if (sharkSubKey.GetComponent<AudioSource>() != null) { sharkSubKey.GetComponent<AudioSource>().Play(); } }
                        if (rayCollider == fuse) { if (fuse.GetComponent<AudioSource>() != null) { fuse.GetComponent<AudioSource>().Play(); } } //remember to Place sound on the fuse
                    }

                    //If player has fuse place fuse in generator.
                    if (fuse == leftHandContent && rayCollider == generator)
                    {
                        Debug.Log("Generator found, fuse placed");
                        leftHandContent.transform.parent = rayCollider.transform.GetChild(0).gameObject.transform;
                        leftHandContent.transform.position = rayCollider.transform.GetChild(0).gameObject.transform.position;
                        leftHandContent.transform.rotation = rayCollider.transform.GetChild(0).gameObject.transform.rotation;
                        leftHandFull = false;
                        leftHandContent = null;

                        //Remember to do whatever the generator will do.

                        if (rayCollider.GetComponent<AudioSource>() != null) { rayCollider.GetComponent<AudioSource>().Play(); };

                        consoleButton.GetComponent<buttonDoesThis>().powerOn = true;
                        lightsParent.SetActive(true);


                    }

                    if (sharkSubKey == leftHandContent && rayCollider.transform.parent.gameObject == sharkSub)
                    {
                        Debug.Log("Game Won");
                        leftHandContent.transform.parent = rayCollider.transform;
                        leftHandContent.transform.position = rayCollider.transform.position;
                        leftHandContent.transform.rotation = rayCollider.transform.rotation;
                        leftHandFull = false;
                        leftHandContent = null;

                        UIReference.gameObject.GetComponent<UIScript>().Victory();

                    }
                }
            }
        }
    }
}
