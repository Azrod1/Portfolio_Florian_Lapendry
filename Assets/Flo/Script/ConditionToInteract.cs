using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionToInteract : MonoBehaviour
{
    public GameObject clefActivate;
    public GameObject button;

    private void Update()
    {
        if (button.GetComponent<ValidateCode>().correctCode)
        {
            clefActivate.SetActive(true);
        }
    }

    public void PageInteract()
    {
        UIManager.instance.OpenPuzzle();
    }
}