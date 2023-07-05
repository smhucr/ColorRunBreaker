using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AdsManager adsManager;
    public ObjectsPool objectsPool;
    public bool gameOver;
    public bool startGame;
    public bool isAvailableShoot;
    [Header("UI")]
    public GameObject[] startGameUI;
    public GameObject[] finishGameUI;
    public TextMeshProUGUI levelText;
    public GameObject[] arrows;
    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip[] audioClips; 
    [Header("Animation")]
    public PlayAnimation playAnimation;
    [Header("Gun")]
    public GameObject playerGun;
    [Header("Money")]
    public int currentMoney;
    public TextMeshProUGUI currentMoneyText;
    [Header("FireRate")]
    public float fireRate;
    public int fireRateLevel;
    public int fireRateCost;
    public Button fireRateButton;
    public TextMeshProUGUI fireRateCostText;
    public TextMeshProUGUI fireRateUpgradeToText;
    [Header("Damage")]
    public int damage;
    public int damageLevel;
    public int damageCost;
    public Button damageButton;
    public TextMeshProUGUI damageCostText;
    public TextMeshProUGUI damageUpgradeToText;


    private void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    private void Awake()
    {
        //Screen.SetResolution(1080, 1920, true);
        QualitySettings.SetQualityLevel(0);
        MakeInstance();

    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("Level") == 0)
            PlayerPrefs.SetInt("Level", 1);
        levelText.text = ("Level " + PlayerPrefs.GetInt("Level")).ToString();
        currentMoney = PlayerPrefs.GetInt("CurrentMoney");
        currentMoneyText.text = currentMoney.ToString();
        damage = PlayerPrefs.GetInt("DamageValue");
        if (damage == 0)
            damage = 1;
        fireRate = PlayerPrefs.GetFloat("FireRateValue");
        if (fireRate == 0)
            fireRate = 1f;
        fireRateLevel = PlayerPrefs.GetInt("FireRateLevel");
        if (fireRateLevel == 0)
        {
            fireRateLevel = 1;
            PlayerPrefs.SetInt("FireRateLevel", 1);
        }
        fireRateCost = PlayerPrefs.GetInt("FireRateCost");
        if (fireRateCost == 0)
            fireRateCost = 70; // Changeable
        fireRateUpgradeToText.text = PlayerPrefs.GetInt("FireRateLevel").ToString() + ">" + (PlayerPrefs.GetInt("FireRateLevel") + 1).ToString();
        fireRateCostText.text = fireRateCost.ToString();
        damageLevel = PlayerPrefs.GetInt("DamageLevel");
        if (damageLevel == 0)
        {
            damageLevel = 1;
            PlayerPrefs.SetInt("DamageLevel", 1);
        }
        damageCost = PlayerPrefs.GetInt("DamageCost");
        if (damageCost == 0)
            damageCost = 110; // Changeable
        damageUpgradeToText.text = PlayerPrefs.GetInt("DamageLevel").ToString() + ">" + (PlayerPrefs.GetInt("DamageLevel") + 1).ToString();
        damageCostText.text = damageCost.ToString();
    }

    public void StartGame()
    {
        if (!gameOver)
        {
            startGame = true;
            for (int i = 0; i < startGameUI.Length; i++)
                startGameUI[i].SetActive(false);
            playAnimation.PlayIdleToWalkAnimation();
            StartCoroutine(ActivateGun());
            Debug.Log("Game Started");
        }
    }

    public void WinGame()
    {
        gameOver = true;
        startGame = false;
        for (int i = 0; i < startGameUI.Length; i++)
            finishGameUI[i].SetActive(true);
        playAnimation.WalKToFinish();
        playerGun.SetActive(false);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        Debug.Log("Game Finished");
    }

    public void GameOver()
    {

    }

    public void FireRateIncreaser()
    {

        if (fireRate < 0.1f)
            fireRateButton.interactable = false;
        else if (currentMoney - fireRateCost < 0)
        {
            fireRateButton.interactable = false;
        }
        else
        {

            fireRateLevel++;
            PlayerPrefs.SetInt("FireRateLevel", fireRateLevel);
            fireRate -= 0.02f;
            PlayerPrefs.SetFloat("FireRateValue", fireRate);
            currentMoney -= fireRateCost;
            PlayerPrefs.SetInt("CurrentMoney", currentMoney);
            currentMoneyText.text = currentMoney.ToString();
            if (fireRateCost == 0)
                fireRateCost = 10;
            else
                fireRateCost = (int)(fireRateCost * 1.3f);
            fireRateCost = Mathf.Clamp(fireRateCost, 0, 99999);
            PlayerPrefs.SetInt("FireRateCost", fireRateCost);
            fireRateCostText.text = fireRateCost.ToString();
            fireRateUpgradeToText.text = PlayerPrefs.GetInt("FireRateLevel").ToString() + " > " + (PlayerPrefs.GetInt("FireRateLevel") + 1).ToString();
        }
    }

    public void DamageIncreaser()
    {
        if (currentMoney - damageCost < 0)
        {
            damageButton.interactable = false;
        }
        else
        {
            damageLevel++;
            PlayerPrefs.SetInt("DamageLevel", damageLevel);
            damage++;
            PlayerPrefs.SetInt("DamageValue", damage);
            currentMoney -= damageCost;
            PlayerPrefs.SetInt("CurrentMoney", currentMoney);
            currentMoneyText.text = currentMoney.ToString();
            if (damageCost == 0)
                damageCost = 10;
            else
                damageCost = (int)(damageCost * 1.3);
            damageCost = Mathf.Clamp(damageCost, 0, 99999);
            PlayerPrefs.SetInt("DamageCost", damageCost);
            damageCostText.text = damageCost.ToString();
            damageUpgradeToText.text = PlayerPrefs.GetInt("DamageLevel").ToString() + ">" + (PlayerPrefs.GetInt("DamageLevel") + 1).ToString();
        }


    }

    private IEnumerator ActivateGun()
    {
        yield return new WaitForSeconds(0.3f);
        playerGun.SetActive(true);
    }

    public void AfterBreakWallCorrect(int scoreHealth)
    {
        currentMoney += scoreHealth;
        currentMoney = Mathf.Clamp(currentMoney, 0, 999999);
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        currentMoneyText.text = currentMoney.ToString();
        arrows[0].SetActive(true); // Green Arrow
        arrows[1].SetActive(false); // Red Arrow
        StartCoroutine(CloseArrows());
    }

    public void AfterBreakWallWrong(int scoreHealth)
    {
        currentMoney -= scoreHealth;
        currentMoney = Mathf.Clamp(currentMoney, 0, 999999);
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        currentMoneyText.text = currentMoney.ToString();
        arrows[1].SetActive(true); // Red Arrow
        arrows[0].SetActive(false); // Green Arrow
        StartCoroutine(CloseArrows());
    }

    private IEnumerator CloseArrows()
    {
        yield return new WaitForSeconds(3f);
        arrows[1].SetActive(false); // Red Arrow
        arrows[0].SetActive(false); // Green Arrow
    }


    public void NewLevelLoader()
    {
        SceneManager.LoadScene(0);
    }

    public void ParticleEffectPooling(int objectType, Transform potionPosition)
    {
        var obj = objectsPool.GetPooledObject(objectType);
        obj.transform.position = potionPosition.position;
        StartCoroutine(ParticleActivateNone(obj));
    }

    IEnumerator ParticleActivateNone(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        obj.SetActive(false);
    }
}
