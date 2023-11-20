using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private buttonDoesThis scriptLink = null;
    [SerializeField] private AudioSource soundToPlay = null;



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
            if (soundToPlay != null) { soundToPlay.Play(); }
            if (animation2_Optional != null) { isOpen = true; }
            if (scriptLink != null) { scriptLink.buttonPressed(); }
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
