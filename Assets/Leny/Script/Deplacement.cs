using UnityEngine;

public class Deplacement : MonoBehaviour
{
    // parametres de deplacement de la camera
    public float Speed = 30f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("z"))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("q"))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
        }
    }
}
