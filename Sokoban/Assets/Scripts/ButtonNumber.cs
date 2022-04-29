using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonNumber : MonoBehaviour
{
    int number;

    public void SetNumber(int number)
    {
        this.number = number;

        transform.GetChild(0).GetComponent<Text>().text = number.ToString();
    }

    public void GoToStage()
    {
        PlayerPrefs.SetInt("SelectLevel", number);

        SceneManager.LoadScene("Stage");
    }
}
