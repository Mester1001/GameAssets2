using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    private bool stopped = false;

    public void interactWithDoor()
    {
        if(stopped) {  return; }
        GetComponent<Animator>().Play("door_open", 0, 0);
        stopped = true;

    }
}
