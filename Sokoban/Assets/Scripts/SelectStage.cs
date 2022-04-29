using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour
{
    [SerializeField] Canvas _Canvas;
    [SerializeField] Button _StageButton;

    int width = 20;
    int height = 5;

    float offsetX;
    float offsetY;

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        offsetX = (float)Screen.width / (float)(width + 2);
        offsetY = (float)Screen.height / (float)(height + 2);

        int number = 1;

        for (int y = height / 2; y > -(height / 2) - (height % 2); y--)
        {
            for (int x = -(width / 2); x < width / 2 + (width % 2); x++)
            {
                RectTransform button = Instantiate<GameObject>(_StageButton.gameObject, _Canvas.transform).GetComponent<RectTransform>();

                Vector3 pos = button.localPosition;

                pos.x = x * offsetX + (float)offsetX * 0.5f * (1 - (width % 2));
                pos.y = y * offsetY + (float)offsetY * 0.5f * (1 - (height % 2));

                button.localPosition = pos;
                button.GetComponent<ButtonNumber>().SetNumber(number);

                if (number > PlayerPrefs.GetInt("SaveLevel"))
                    button.GetComponent<Button>().interactable = false;

                button.gameObject.SetActive(true);

                number++;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Back();
    }
}
