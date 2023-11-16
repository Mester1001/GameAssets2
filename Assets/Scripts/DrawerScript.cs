using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerScript : MonoBehaviour
{

    [SerializeField] private bool isOpen = false;
    [SerializeField] private bool isBusy = false;

    public void interactWithDrawer()
    {
        if(isBusy)  {
            Debug.Log("Busy");
            return; }

        if(isOpen)
        {
            GetComponent<Animator>().Play("close_drawer", 0, 0);
            isOpen = false;
            StartCoroutine(waiter());
        }
        else if (!isOpen) 
        {
            GetComponent<Animator>().Play("open_drawer", 0, 0);
            isOpen = true;
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        isBusy = true;
        yield return new WaitForSeconds(1);
        isBusy = false;
    }


}
