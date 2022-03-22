using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class creatTurret : MonoBehaviour
{
    public GameObject canvas;
    public GameObject Gunner;
    public GameObject Missile;

    private bool state = true;

    private void OnMouseDown() {
        canvas.SetActive(state);
        state = !state;
    }

    public void CreateGunner() {
        if (SceneManagement.instance.countMoney >= 4) {
            SceneManagement.instance.AddMoney(-4);
            Instantiate(Gunner, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void CreateMissile() {
        if (SceneManagement.instance.countMoney >= 9) {
            SceneManagement.instance.AddMoney(-9);
            Instantiate(Missile, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
