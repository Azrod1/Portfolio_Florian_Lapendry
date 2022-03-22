using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    public float range;
    public Transform startbullet;
    public GameObject bulletPrefab;
    public float attackSpeed;
    public int damageTurret;
    public GameObject anim = null;

    private bool startShoot = false;
    private Transform target = null;
    private Animator animer = null;

    private void Start() {
        StartCoroutine(SpawnBullet());
        InvokeRepeating("UpdateTarget",0f,0.5f);
        if (anim != null) {
            animer = anim.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update() {

        if(target != null) {
            if (transform.tag != "Gunner") {
                transform.LookAt(target);
                transform.LookAt(target);
            }
            startbullet.LookAt(target);
            startShoot = true;
        }else {
            startShoot = false;
        }

        if (animer != null) {
            if(startShoot == true) {
                animer.SetBool("shooting", true);
            }
            else {
                animer.SetBool("shooting", false);
            }
        }
    }

    void UpdateTarget() {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestdistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestdistance) {
                shortestdistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestdistance <= range) {
            target = nearestEnemy.transform;
        }else {
            target = null;
        }
    }

    IEnumerator SpawnBullet() {

        while (true) {
            if (startShoot) {
                GameObject bullet = Instantiate(bulletPrefab, startbullet.position, startbullet.rotation);
                GetComponentInParent<AudioSource>().PlayOneShot(GetComponentInParent<AudioSource>().clip);
                
                if (tag == "Gunner") {
                    bullet.GetComponent<MoveBullet>().damageBullet = damageTurret;
                    bullet.GetComponent<MoveBullet>().target = target;
                }
                else {
                    bullet.GetComponent<MoveMissile>().directDamageMissile = damageTurret;
                    bullet.GetComponent<MoveMissile>().areaDamageMissile = damageTurret/2 + 1;
                    bullet.GetComponent<MoveMissile>().target = target;
                }
                yield return new WaitForSeconds(attackSpeed);
            }
            else {
                yield return null;
            }
            
        }

    }

}
