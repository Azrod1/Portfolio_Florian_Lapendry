using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameObject simpleEnemy;
    public GameObject heavyEnemy;
    public GameObject speedEnemy;
    public GameObject bossEnemy;

    public Transform spawnPoint;
    public Transform goalPoint;

    public int enemyInScene = 0;
    public int numberWave = 1;

    public static WaveSpawner instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance 'WaveSpawner' dans la scène");
            return;
        }

        instance = this;
    }

    private void Update()
    {
        if(enemyInScene <= 0 && UILevelManager.instance.startButton.activeSelf == false)
        {
            numberWave++;
            UILevelManager.instance.startButton.SetActive(true);
        }
        if (numberWave >= 6) {
            PauseMenu.instance.GameWin();
        }
        else 
        {
            UILevelManager.instance.countWave.GetComponent<Text>().text = (numberWave + " / 5");
        }
    }

    public void StartWave()
    {
        UILevelManager.instance.startButton.SetActive(false);
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        int numberSimpleEnemy = 4;
        int numberHeavyEnemy = 1;
        int numberSpeedEnemy = 1;

        numberSimpleEnemy *= numberWave;
        numberHeavyEnemy *= numberWave;
        numberSpeedEnemy *= numberWave;

        // Pour la vague 1 -------------------------------------------------------------------
        if (numberWave == 1)
        {
            //nombre de "simpleEnemy" à faire spawn
            for (int i = 0; i < numberSimpleEnemy; i++)
            {
                SpawnEnemy(simpleEnemy);
                enemyInScene++;
                yield return new WaitForSeconds(0.5f);
            }
        }

        // Pour la vague 2 -------------------------------------------------------------------
        if (numberWave == 2)
        {
            //nombre de "speedEnemy" à faire spawn
            for (int i = 0; i < numberSpeedEnemy; i++)
            {
                SpawnEnemy(speedEnemy);
                enemyInScene++;
                yield return new WaitForSeconds(0.5f);
            }

            //nombre de "simpleEnemy" à faire spawn
            for (int i = 0; i < numberSimpleEnemy; i++)
            {
                SpawnEnemy(simpleEnemy);
                enemyInScene++;
                yield return new WaitForSeconds(0.5f);
            }
        }

        // Pour la vague 3 -------------------------------------------------------------------
        else if(numberWave >= 3)
        {
            //nombre de "speedEnemy" à faire spawn
            for (int i = 0; i < numberSpeedEnemy; i++)
            {
                SpawnEnemy(speedEnemy);
                enemyInScene++;
                yield return new WaitForSeconds(0.5f);
            }

            //nombre de "heavyEnemy" à faire spawn
            for (int i = 0; i < numberHeavyEnemy; i++)
            {
                SpawnEnemy(heavyEnemy);
                enemyInScene++;
                yield return new WaitForSeconds(0.5f);
            }

            //nombre de "simpleEnemy" à faire spawn
            for (int i = 0; i < numberSimpleEnemy; i++)
            {
                SpawnEnemy(simpleEnemy);
                enemyInScene++;
                yield return new WaitForSeconds(0.5f);
            }

            if (numberWave == 5) 
            {
                SpawnEnemy(bossEnemy);
                enemyInScene++;
            }
        }
    }

    void SpawnEnemy(GameObject enemySpawning)
    {
        GameObject ennemy;
        ennemy = Instantiate(enemySpawning, spawnPoint.position, spawnPoint.rotation) as GameObject;
        ennemy.GetComponent<MoveTo>().goal = goalPoint;
    }
}
