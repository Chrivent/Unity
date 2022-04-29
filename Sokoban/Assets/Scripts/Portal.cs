using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] AudioSource _InsertMarbleAudio;

    [SerializeField] InsertMarbleEffect _InsertMarbleEffect;
    [SerializeField] FillPortalEffect _FillPortalEffect;

    int marbleCount = 0;
    bool fill = false;

    public void SetMarbleCount(int marbleCount)
    {
        this.marbleCount = marbleCount;
    }

    public void InsertMarble()
    {
        _InsertMarbleAudio.Play();

        Transform insertMarbleEffect = Instantiate<GameObject>(_InsertMarbleEffect.gameObject).transform;

        insertMarbleEffect.localPosition = transform.localPosition;
        insertMarbleEffect.gameObject.SetActive(true);

        marbleCount--;
    }

    public bool CheckFill()
    {
        return fill;
    }

    void FillEvent()
    {
        Transform fillPortalEffect = Instantiate<GameObject>(_FillPortalEffect.gameObject).transform;

        Vector3 pos = transform.localPosition;

        pos.y += 0.5f;

        fillPortalEffect.localPosition = pos;
        fillPortalEffect.SetParent(transform);
        fillPortalEffect.gameObject.SetActive(true);
    }

    void Update()
    {
        if (fill == false && marbleCount == 0)
        {
            FillEvent();

            fill = true;
        }
    }
}