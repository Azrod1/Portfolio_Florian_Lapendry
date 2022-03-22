using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Camera _camera;

    public static MoveCamera instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance 'MoveCamera' dans la scène");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _camera = gameObject.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0.3f) {
            transform.Translate(Vector3.up * Time.deltaTime * 20f);
        }

        if (Input.GetAxis("Vertical") < -0.3f) {
            transform.Translate(Vector3.down * Time.deltaTime * 20f);
        }

        if (Input.GetAxis("Horizontal") > 0.3f) {
            transform.Translate(Vector3.right * Time.deltaTime * 20f);
        }

        if (Input.GetAxis("Horizontal") < -0.3f) {
            transform.Translate(Vector3.left * Time.deltaTime * 20f);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            _camera.fieldOfView -= 1;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < -0f) {
            _camera.fieldOfView += 1;
        }

    }
}
