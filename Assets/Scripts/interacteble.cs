using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class interacteble : MonoBehaviour
{
    private bool isOpen = false;
    private bool isBusy = false;
    [SerializeField] private bool stopped = false;
    [SerializeField] private bool oneShot = false;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private AnimationClip animation1;
    [SerializeField] private AnimationClip animation2_Optional;



    public void interacted()
    {
        //Debug.Log("Trying to use new script");

        if (isBusy || stopped)
        {
            Debug.Log("Busy");
            return;
        }

        if (!isOpen)
        {
            GetComponent<Animator>().Play(animation1.name, 0, 0);
            isOpen = true;
            if (oneShot) { stopped = true; return; }
            StartCoroutine(waiter());
        }
        else if (isOpen)
        {
            GetComponent<Animator>().Play(animation2_Optional.name, 0, 0);
            isOpen = false;
            StartCoroutine(waiter());
        }
    }


    IEnumerator waiter()
    {
        isBusy = true;
        yield return new WaitForSeconds(waitTime);
        isBusy = false;
    }

}
