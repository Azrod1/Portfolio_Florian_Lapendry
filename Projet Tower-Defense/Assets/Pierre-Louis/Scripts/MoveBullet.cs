using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public int damageBullet = 1;
    public Transform target;

    // Update is called once per frame
    void Update(){
        transform.LookAt(target);
        transform.Translate(Vector3.forward * Time.deltaTime * 100f);
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.transform.CompareTag("Enemy")) {
            Destroy(gameObject);
            collision.GetComponent<EnemyHealth>().health -= damageBullet;
        }

        if (collision.transform.CompareTag("OffMap")) {
            Destroy(gameObject);
        }
    }
}
