using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TipAnimation : MonoBehaviour
{
    public GameObject hand;
    private Tween tween;

    private void Start()
    {
        tween = hand.transform.DOLocalMove(new Vector3(400, -67,0), 2).SetEase(Ease.InSine).SetLoops(-1, LoopType.Yoyo).From();
    }

    private void OnDisable()
    {
        tween.Kill();
    }
}
