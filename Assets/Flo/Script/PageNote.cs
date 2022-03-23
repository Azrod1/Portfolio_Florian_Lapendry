using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageNote : MonoBehaviour
{
    public void PageInteract()
    {
        UIManager.instance.OpenPage();
        if (gameObject.GetComponent<changeObjectif>())
        {
            gameObject.GetComponent<changeObjectif>().SwitchObjectif();
        }
    }
}
