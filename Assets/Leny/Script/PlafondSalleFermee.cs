using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlafondSalleFermee : MonoBehaviour
{

    public GameObject ObjetPlafondSalleFermee;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance.clefParent)
            {
                ObjetPlafondSalleFermee.SetActive(false);

            }
        }
    }

    /*

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag(clef))
        {
            niveau.SetActive(true);
        }
    }
    */
}
