using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactingScript : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask interactive;


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

            if (Physics.Raycast(ray, out hit, 100, interactive))
            {
                Debug.Log("Found something");
                Debug.DrawLine(ray.origin, hit.point);
                Debug.Log("Hit: " + hit.collider);
            }
                


            //Debug.Log(Physics.Raycast(_camera.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 7));
        }


        
        //raycast, if looking at (interactible object) pickup item script.
        //hide or remove item from where it was, depending on which item, make it appear in hand.
        //Change value saying it is picked up
        //





    }
}
