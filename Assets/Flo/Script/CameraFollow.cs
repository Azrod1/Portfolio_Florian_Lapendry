using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(PlayerMovement.instance.transform.position.x , PlayerMovement.instance.transform.position.y + 6, PlayerMovement.instance.transform.position.z - 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerMovement.instance.transform.position.x , PlayerMovement.instance.transform.position.y + 6, PlayerMovement.instance.transform.position.z - 4);
    }
}