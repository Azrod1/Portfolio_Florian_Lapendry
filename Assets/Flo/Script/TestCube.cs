using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
    public Material mat;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

        if(Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            Debug.Log("Le raycast touche un objet !");

            //hit.transform.gameObject.GetComponent<PlayerMovement>().rend.sharedMaterial = mat;
        }
    }
}
