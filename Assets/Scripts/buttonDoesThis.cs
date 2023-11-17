using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonDoesThis : MonoBehaviour
{

    [SerializeField] private GameObject heavyDoorPivot;
    [SerializeField] public bool powerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void buttonPressed()
    {

        //whatever the button does happens here
        if (!powerOn) { return; }
        Debug.Log("Button pressed");
        heavyDoorPivot.GetComponent<interacteble>().interacted();

    }

}
