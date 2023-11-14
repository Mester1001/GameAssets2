using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerScript : MonoBehaviour
{

    [SerializeField] private bool isOpen = false;
    [SerializeField] private bool isBusy = false;
    [SerializeField] private float moveDistance = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void interactWithDrawer()
    {
        
        if(isBusy)  {return; }

        if(isOpen)
        {

            Debug.Log("Try to Close Drawer");
            gameObject.GetComponentInParent<Transform>().localPosition -= Vector3.forward * moveDistance;
            isOpen = false;

        } 
        else if (!isOpen) 
        {
            Debug.Log("Try to Open Drawer");
            gameObject.GetComponentInParent<Transform>().localPosition += Vector3.forward * moveDistance;
            isOpen = true;

        }


    }




}
