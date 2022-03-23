//Script de test

using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject Etage;


    void Start()
    {
        Etage.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey("t"))
        {
            Debug.Log("Afficher: " + Etage.name);
            Etage.SetActive(true);
        }
        if (Input.GetKey("f"))
        {
            Debug.Log("Masquer: " + Etage.name);
            Etage.SetActive(false);
        }
    }


}