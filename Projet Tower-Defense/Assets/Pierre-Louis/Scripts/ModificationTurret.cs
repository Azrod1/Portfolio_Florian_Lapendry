using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModificationTurret : MonoBehaviour
{
    public GameObject panel;
    public GameObject place;
    public GameObject price;
    public GameObject sold;
    public GameObject graphic = null;

    private int sellMoney;
    private int upPrice;
    private int levelCount = 1;
    private Text priceText;
    private Text soldText;
    private Text levelTurret;
    private bool state = true;

    // Start is called before the first frame update
    void Start() {
        if (tag == "Gunner") {
            sellMoney = 2;
            upPrice = 7;
        }else {
            sellMoney = 4;
            upPrice = 13;
        }

        priceText = price.GetComponent<Text>();
        soldText = sold.GetComponent<Text>();
        levelTurret = panel.GetComponentInChildren<Text>();

        priceText.text = upPrice.ToString() + "$";
        soldText.text = sellMoney.ToString() + "$";
        levelTurret.text = "Level " + levelCount;
    }

    private void OnMouseDown() {
        panel.SetActive(state);
        state = !state;
    }

    public void UpgradeTurret() {
        if (SceneManagement.instance.countMoney >= upPrice && levelCount < 5) {
            levelCount++;
            SceneManagement.instance.AddMoney(-upPrice);
            TargetEnemy turret;
            sellMoney = (upPrice / 2) + sellMoney;
            

            if (tag == "Gunner") {
                turret = gameObject.GetComponentInChildren<TargetEnemy>();
                turret.attackSpeed -= 0.1f;
                upPrice = upPrice * 2;
            }
            else {
                turret = graphic.GetComponent<TargetEnemy>();
                turret.range += 1f;
                upPrice = upPrice * 2;
            }

            turret.damageTurret += 1;

            priceText.text = upPrice + "$";
            soldText.text = sellMoney + "$";
            levelTurret.text = "Level " + levelCount;

            if (levelCount == 3) {
                if (transform.tag != "Gunner") {
                    graphic.transform.GetChild(0).gameObject.SetActive(false);
                    graphic.transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(true);
                }  
            }
            else if(levelCount == 5) {
                panel.GetComponentInChildren<Button>().gameObject.SetActive(false);

                if (transform.tag != "Gunner") {
                    graphic.transform.GetChild(1).gameObject.SetActive(false);
                    graphic.transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).gameObject.SetActive(true);
                }
            }
        }       
    }

    public void SellTurret() {
        SceneManagement.instance.AddMoney(sellMoney);
        Instantiate(place, transform.position, Quaternion.Euler(0,0,0));
        Destroy(gameObject);
    }
}
