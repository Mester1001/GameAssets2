using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* By Isak Sørøy
 * created 20.Sep 2023
 * Last Updated: 20Sep 2023
 * 
*/


public class UIScript : MonoBehaviour
{
    private bool escMenuState = false;
    [SerializeField] private GameObject UIReference;



    // Start is called before the first frame update
    void Start()
    {
        UIReference.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            

            if (!escMenuState)
            {
                escMenuState = true;
                Debug.Log("UI Opened");
                UIReference.SetActive(true);
                //Disable Player movement
            }
            else
            {
                escMenuState = false;
                Debug.Log("UI Closed");
                UIReference.SetActive(false);
                //Enable Player movement
            }


        }
    }
}
