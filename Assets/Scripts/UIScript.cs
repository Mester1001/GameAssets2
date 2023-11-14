using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* By Isak Sørøy
 * created 20.Sep 2023
 * Last Updated: 7.nov 2023
 * Ver. 0.2
*/


public class UIScript : MonoBehaviour
{
    private bool escMenuState = false;
    [SerializeField] private GameObject UIReference;
    [SerializeField] private GameObject VictoryScreen;
    [SerializeField] public playerMovement playerScript;



    // Start is called before the first frame update
    void Start()
    {
        UIReference.SetActive(false);
        VictoryScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            MenuOpenClose();




        }
    }



    public void MenuOpenClose() 
    {
            if (!escMenuState)
        {
            escMenuState = true;
            Debug.Log("UI Opened");
            UIReference.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            playerScript.canMove = false;
        }
        else
        {
            escMenuState = false;
            Debug.Log("UI Closed");
            UIReference.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            playerScript.canMove = true;
        }
    }

    public void ExitGame()
    {
        if (escMenuState) {
            Debug.Log("Attempting to Exit game");
            Application.Quit(); 
        }
    }

    public void Victory()
    {
        VictoryScreen.SetActive(true);
    }

}
