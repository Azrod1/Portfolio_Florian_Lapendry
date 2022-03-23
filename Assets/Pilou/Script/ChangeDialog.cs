using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDialog : MonoBehaviour
{
    public Image profilPicture;
    public GameObject texte;

    public Sprite sadCat;
    public Sprite saladCat;
    public PlayerMovement player;

    public void OnEnable() {
        if (player.alterChange) {
            profilPicture.sprite = sadCat;
            texte.GetComponent<Text>().text = "Story still coming soon";
        }
        else {
            profilPicture.sprite = saladCat;
            texte.GetComponent<Text>().text = "Story coming soon";
        }
    }

}
