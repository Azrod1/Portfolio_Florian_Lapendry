using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public int ennemyCrash = 0;
    public int damageHit;

    private GameObject enemyToDestroy;

    public static DeathZone instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance 'DeathZone' dans la scène");
            return;
        }

        instance = this;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            damageHit = collision.GetComponent<MoveTo>().damageOnBase;
            enemyToDestroy = collision.gameObject;
            WaveSpawner.instance.enemyInScene--;
            Destroy(enemyToDestroy);

            ennemyCrash++;
            SceneManagement.instance.BaseHit(damageHit);
        }
    }
}
