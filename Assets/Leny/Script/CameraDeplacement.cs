 using UnityEngine;

public class CameraDeplacement : MonoBehaviour
{
    // parametres de deplacement de la camera
    public float Speed = 30f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
        }
    }
}
