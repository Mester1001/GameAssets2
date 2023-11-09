using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactingScript : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask interactive;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftHand;
    private GameObject leftHandContent;
    [SerializeField] private GameObject flashlight;
    private bool leftHandFull = false;
    public bool hasFlashlight = false;
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

                Debug.Log("is: " + rayCollider.gameObject.layer + " = " + 7);
                if (rayCollider.gameObject.layer == 7)
                {
                    //trying to move the collided object into rightHand if flashlight. otherwise if left is empty place collided object in left hand. 
                    if (rayCollider.gameObject == flashlight)
                    {
                        hasFlashlight = true;
                        rayCollider.gameObject.transform.parent = rightHand.transform;
                        rayCollider.gameObject.transform.position = rightHand.transform.position;
                        rayCollider.gameObject.transform.rotation = rightHand.transform.rotation;
                    }
                    else if (!leftHandFull)
                    {
                        leftHandFull = true;
                        leftHandContent = rayCollider.gameObject;
                        Debug.Log("Left hand picked up: " + rayCollider.gameObject);
                        leftHandContent.transform.parent = leftHand.transform;
                        leftHandContent.transform.position = leftHand.transform.position;
                        leftHandContent.transform.rotation = leftHand.transform.rotation;
                    }
                }


                


            }
                


            //Debug.Log(Physics.Raycast(_camera.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 7));
        }


        
        //raycast, if looking at (interactible object) pickup item script.
        //hide or remove item from where it was, depending on which item, make it appear in hand.
        //Change value saying it is picked up
        //





    }
}
