using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Flashlight : MonoBehaviour
{


    [SerializeField] private int time = 1000;
    [SerializeField] private float maxTime = 3000;
    [SerializeField] private float multiplier = 2f;
    [SerializeField] private GameObject Spotlight;
    [SerializeField] public bool hasFlashlight = false;
    private float countdown = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (!hasFlashlight) { return; }

        Countdown();

        if (Input.GetMouseButtonDown(0) && countdown < maxTime)
        {
            Debug.Log("Pressed left-click.");
            Spotlight.SetActive(true);
            countdown += time;
        }
    }


    private void Countdown()
    {
        if (countdown > 0)
        {
            countdown--;
            Spotlight.GetComponent<Light>().intensity = (Mathf.Clamp((countdown / maxTime), 0f, 0.5f)) * multiplier;
        }
        
        if (countdown <= 0) 
        {
            Spotlight.SetActive(false);
        }
    }


}
