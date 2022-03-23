using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddOne : MonoBehaviour
{
    public GameObject texte;

    public void Add() {
        string ch = texte.GetComponent<Text>().text;
        int i = int.Parse(ch) + 1;
        if (i > 9) {
            i = 0;
        }
        texte.GetComponent<Text>().text = i.ToString();
    }
}
