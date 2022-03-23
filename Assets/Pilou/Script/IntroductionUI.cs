using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionUI : MonoBehaviour
{
    public List<GameObject> textList;
    public GameObject panelToActivate;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(gameObject.activeSelf)
            {
                NextText();
            }
        }
    }

    private void NextText()
    {
        foreach(GameObject obj in textList)
        {
            if (obj.activeSelf)
            {
                if(obj.name == textList[0].name)
                {
                    textList[0].SetActive(false);
                    textList[1].SetActive(true);
                    return;
                }
                else if(obj.name == textList[1].name)
                {
                    textList[1].SetActive(false);
                    textList[2].SetActive(true);
                    return;
                }
                else if (obj.name == textList[2].name)
                {
                    CloseIntro();
                }
            }
        }
    }

    private void  CloseIntro()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        panelToActivate.SetActive(true);
    }
}
