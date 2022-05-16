using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera _MainCamera;
    [SerializeField] Camera _MinimapCamera;
    [SerializeField] Scrollbar _MinimapScrollbar;

    float minimapCameraPosX;

    void Start()
    {
        minimapCameraPosX = _MinimapCamera.transform.localPosition.x;
    }

    public void MoveMainCamera()
    {
        Vector2 mainCameraPos = _MainCamera.transform.localPosition;
        float scrollbarValue = _MinimapScrollbar.value;

        mainCameraPos.x = scrollbarValue * minimapCameraPosX * 2.0f;

        _MainCamera.transform.localPosition = mainCameraPos;
    }

    void Update()
    {
        
    }
}
