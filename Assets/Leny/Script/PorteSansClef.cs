using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteSansClef : MonoBehaviour
{

    public GameObject niveau;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            niveau.SetActive(false);

        }
    }

    

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            niveau.SetActive(true);
        }
    }
    
}
