using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clef : MonoBehaviour
{

    public GameObject clefPhysique;
    public GameObject textObjectif;
    public GameObject panelToActive;
    public string texte;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (GameManager.instance.clefParent)
            {
                clefPhysique.SetActive(false);
                textObjectif.SetActive(true);
                panelToActive.SetActive(true);
                textObjectif.GetComponent<Text>().text = texte;
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
