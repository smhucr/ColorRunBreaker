using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoneyController : MonoBehaviour
{
    private Tween tween;

    private void Start()
    {
        tween = gameObject.transform.DOLocalMoveY(-120, 0.6f).SetEase(Ease.InSine).SetLoops(-1, LoopType.Yoyo).From();
    }

}
