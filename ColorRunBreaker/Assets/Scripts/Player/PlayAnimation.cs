using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    private Animator playerAnimator;
    private void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    public void PlayBreakAnimation()
    {
        playerAnimator.SetBool("isWallBreak", true);
    }

    public void StopBreakAnimation()
    {
        playerAnimator.SetBool("isWallBreak", false);
    }

    public void PlayIdleToWalkAnimation()
    {
        playerAnimator.SetBool("isGameStarted", true);
    }

    public void WalKToFinish()
    {
        playerAnimator.SetBool("isFinished", true);
    }
}
