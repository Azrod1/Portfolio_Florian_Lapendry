using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractObject : MonoBehaviour
{
    private bool interact = false;
    private Transform interactObject;
    private GameObject col;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && interact)
        {
            if(col.CompareTag("Alter1InteractObject") || col.CompareTag("Alter2InteractObject"))
            {
                col.GetComponent<AlterOneDialog>().PageInteract();
            }

            if (col.CompareTag("PageNote"))
            {
                col.GetComponent<PageNote>().PageInteract();
            }

            if (col.CompareTag("ConditionObject"))
            {
                col.GetComponent<ConditionToInteract>().PageInteract();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        print(collision.name);

        //Si le characters est avec l'alter 1
        if (collision.CompareTag("InteractObject") || collision.CompareTag("Alter1InteractObject") && !PlayerMovement.instance.alterChange)
        {
            interact = true;
            col = collision.gameObject;
        }

        //Si le characters est avec l'alter 2
        if (collision.CompareTag("InteractObject") || collision.CompareTag("Alter2InteractObject") && PlayerMovement.instance.alterChange)
        {
            interact = true;
            col = collision.gameObject;
        }

        if (collision.CompareTag("PageNote"))
        {
            interact = true;
            col = collision.gameObject;
        }

        if (collision.CompareTag("ConditionObject"))
        {
            interact = true;
            col = collision.gameObject;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        //interact = false;

        //Si le characters est avec l'alter 1
        if (collision.CompareTag("InteractObject") || collision.CompareTag("Alter1InteractObject") || collision.CompareTag("Alter2InteractObject"))
        {
            interact = false;
            col = null;
        }

        if (collision.CompareTag("PageNote"))
        {
            interact = false;
            col = null;
        }

        if (collision.CompareTag("ConditionObject"))
        {
            interact = false;
            col = null;
        }
    }
}