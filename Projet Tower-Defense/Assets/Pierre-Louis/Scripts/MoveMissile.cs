using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMissile : MonoBehaviour
{
    public int areaDamageMissile;
    public int directDamageMissile;
    public GameObject anim;
    public Transform target;
    public GameObject sound;

    private float range = 5f;

    // Update is called once per frame
    void Update() {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * Time.deltaTime * 100f);
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.transform.CompareTag("Enemy")) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            ArrayList enemiesInRange = new ArrayList();

            foreach(GameObject enemy in enemies) {
                if (Vector3.Distance(enemy.transform.position,transform.position) <= range) {
                    enemiesInRange.Add(enemy);
                }
            }

            foreach(GameObject enemy in enemiesInRange) {
                enemy.GetComponent<EnemyHealth>().health -= areaDamageMissile;
            }

            collision.GetComponent<EnemyHealth>().health -= directDamageMissile;
            GameObject explosion = Instantiate(anim, transform.position, transform.rotation);
            GameObject audio = Instantiate(sound,transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 1f);
            Destroy(audio, 1.5f);

        }

        if (collision.transform.CompareTag("OffMap")) {
            Destroy(gameObject);
        }
    }
}
