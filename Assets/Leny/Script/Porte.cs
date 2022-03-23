using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{

    public GameObject niveau;
    public GameObject plafond;
    public string clef;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (GameManager.instance.clefParent)
            {
                niveau.SetActive(false);
                plafond.SetActive(false);
            }
        }
    }

    
    
    private void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag(clef))

        if (other.CompareTag("Player"))
        {
            niveau.SetActive(true);
        }
    }
    
    
}
