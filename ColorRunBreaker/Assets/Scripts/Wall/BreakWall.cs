using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    public GameObject unBreakableWall;
    public GameObject breakableWall;
    public GameObject canvasScoreHealth;
    public GameObject playerGun;
    public PlayAnimation playAnimation;
    public Wall wallScript;
    public bool isTriggered;

    private void Start()
    {
        isTriggered = false;
        playerGun = GameManager.instance.playerGun;
        playAnimation = GameManager.instance.playAnimation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            GameManager.instance.isAvailableShoot = false;
            playAnimation.PlayBreakAnimation();
            playerGun.SetActive(false);
            StartCoroutine(SmoothBreaking());
            if (unBreakableWall.GetComponent<Renderer>().sharedMaterial.name == "WallBlue")
            {
                if (PlayerPrefs.GetInt("PlayerMaterial") == 0)
                    GameManager.instance.AfterBreakWallCorrect(wallScript.scoreHealth);
                else
                    GameManager.instance.AfterBreakWallWrong(wallScript.scoreHealth);

            }
            else if (unBreakableWall.GetComponent<Renderer>().sharedMaterial.name == "WallGreen")
            {
                if (PlayerPrefs.GetInt("PlayerMaterial") == 1)
                    GameManager.instance.AfterBreakWallCorrect(wallScript.scoreHealth);
                else
                    GameManager.instance.AfterBreakWallWrong(wallScript.scoreHealth);
            }
            else if (unBreakableWall.GetComponent<Renderer>().sharedMaterial.name == "WallRed")
            {
                if (PlayerPrefs.GetInt("PlayerMaterial") == 2)
                    GameManager.instance.AfterBreakWallCorrect(wallScript.scoreHealth);
                else
                    GameManager.instance.AfterBreakWallWrong(wallScript.scoreHealth);
            }

        }
    }

    private IEnumerator SmoothBreaking()
    {
        yield return new WaitForSeconds(0.12f);
        unBreakableWall.SetActive(false);
        canvasScoreHealth.SetActive(false);
        StartCoroutine(DisableBreakableParts());
        StartCoroutine(EnableShooting());
    }

    private IEnumerator EnableShooting()
    {
        yield return new WaitForSeconds(0.8f);
        GameManager.instance.isAvailableShoot = true;
        playAnimation.StopBreakAnimation();
        yield return new WaitForSeconds(0.15f);
        playerGun.SetActive(true);
    }

    private IEnumerator DisableBreakableParts()
    {
        breakableWall.SetActive(true);
        yield return new WaitForSeconds(4f);
        breakableWall.SetActive(false);
    }

}
