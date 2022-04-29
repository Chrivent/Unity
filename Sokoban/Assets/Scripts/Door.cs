using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] AudioSource _OpenAudio;

    [SerializeField] OpenDoorEffect _OpenDoorEffect;

    public void Open()
    {
        _OpenAudio.Play();

        Transform openDoorEffect = Instantiate<GameObject>(_OpenDoorEffect.gameObject).transform;

        openDoorEffect.localPosition = transform.localPosition;
        openDoorEffect.gameObject.SetActive(true);

        Destroy(gameObject);
    }
}
