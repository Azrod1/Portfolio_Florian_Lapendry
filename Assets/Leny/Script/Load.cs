using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{

    public GameObject niveau;


    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            niveau.SetActive(true);
        }
    }
}
