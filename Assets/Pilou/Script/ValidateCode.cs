using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidateCode : MonoBehaviour
{
    public GameObject[] textes;
    public bool correctCode = false;

    public void Validate() {
        List<int> numbers = new List<int>();
        foreach(GameObject textebox in textes) {
            numbers.Add(int.Parse(textebox.GetComponent<Text>().text));
        }

        if (numbers[0] == 4) {
            if (numbers[1] == 2) {
                if (numbers[2] == 0) {
                    correctCode = true;
                    UIManager.instance.ClosePuzzle();
                }
            }
        }
    }
}
