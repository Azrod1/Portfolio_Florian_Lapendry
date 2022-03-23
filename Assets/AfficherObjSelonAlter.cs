using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfficherObjSelonAlter : MonoBehaviour
{
    public GameObject[] objectAlter1;
    public GameObject[] objectAlter2;

    // Update is called once per frame
    void Update()
    {
        if(!PlayerMovement.instance.alterChange)
        {
            foreach (GameObject objectA in objectAlter1)
            {
                objectA.SetActive(true);
            }
            foreach (GameObject objectA in objectAlter2)
            {
                objectA.SetActive(false);
            }
        }
        else if(PlayerMovement.instance.alterChange)
        {
            foreach(GameObject objectA in objectAlter2)
            {
                objectA.SetActive(true);
            }
            foreach (GameObject objectA in objectAlter1)
            {
                objectA.SetActive(false);
            }
        }
    }
}
