using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class SceneManagement : MonoBehaviour
{
    public int baseHealth = 10;
    public int countMoney = 8;

    public static SceneManagement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance 'SceneManagement' dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        UILevelManager.instance.baseHealth.GetComponent<Text>().text = baseHealth.ToString();
        UILevelManager.instance.countMoney.GetComponent<Text>().text = countMoney.ToString();
    }

    private void Update()
    {
        if(baseHealth <= 0)
        {
            PauseMenu.instance.GameLost();
        }
    }

    public void BaseHit(int damage)
    {
        baseHealth -= damage;
        if(baseHealth < 0) { baseHealth = 0; }
        UILevelManager.instance.baseHealth.GetComponent<Text>().text = baseHealth.ToString();
    }

    public void AddMoney(int money)
    {
        countMoney += money;
        UILevelManager.instance.countMoney.GetComponent<Text>().text = countMoney.ToString();
    }
}
