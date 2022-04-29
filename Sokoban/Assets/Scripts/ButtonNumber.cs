using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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