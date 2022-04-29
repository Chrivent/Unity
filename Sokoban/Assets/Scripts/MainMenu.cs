using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _DeleteDataButton;

    public void StartGame()
    {
        if (PlayerPrefs.HasKey("SaveLevel") == false || PlayerPrefs.GetInt("SaveLevel") == 1)
        {
            PlayerPrefs.SetInt("SelectLevel", 1);

            SceneManager.LoadScene("Stage");
        }
        else
            SceneManager.LoadScene("SelectStage");
    }

    public void DeleteData()
    {
        PlayerPrefs.SetInt("SaveLevel", 1);

        _DeleteDataButton.interactable = false;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("SaveLevel") == false || PlayerPrefs.GetInt("SaveLevel") == 1)
            _DeleteDataButton.interactable = false;
        else
            _DeleteDataButton.interactable = true;
    }
}