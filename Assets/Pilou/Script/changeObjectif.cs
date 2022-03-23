using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeObjectif : MonoBehaviour
{
    public string texte;
    public GameObject texteObjectif;

    public void SwitchObjectif()
    {
        texteObjectif.GetComponent<Text>().text = texte;
        texteObjectif.GetComponent<Text>().color = Color.green;
        GameManager.instance.canEnd = true;
    }
}
