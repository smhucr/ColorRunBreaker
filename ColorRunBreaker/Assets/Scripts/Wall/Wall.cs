using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wall : MonoBehaviour
{
    public int scoreHealth;
    public TextMeshProUGUI textScoreHealth;
    public Material[] wallMaterials;
    public GameObject[] childBreakables;

    private void Start()
    {
        int levelIndex = (int)(PlayerPrefs.GetInt("Level")/10) + 1;
        scoreHealth = levelIndex * Random.Range(7, 19);
        textScoreHealth.text = scoreHealth.ToString();
        int randomNumber = Random.Range(0, 3);
        gameObject.GetComponent<Renderer>().sharedMaterial = wallMaterials[randomNumber];
        for (int i = 0; i < childBreakables.Length; i++)
        {
            childBreakables[i].GetComponent<Renderer>().sharedMaterial = wallMaterials[randomNumber];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            //Colors Are [0,1,2] => [Blue,Green,Red]
            if (gameObject.GetComponent<Renderer>().sharedMaterial.name == "WallBlue")
            {
                if (PlayerPrefs.GetInt("PlayerMaterial") == 0)
                {
                    scoreHealth += GameManager.instance.damage;
                    textScoreHealth.text = scoreHealth.ToString();
                }
                else
                {
                    if (scoreHealth - GameManager.instance.damage < 0)
                    {
                        scoreHealth = GameManager.instance.damage - scoreHealth;
                        gameObject.GetComponent<Renderer>().sharedMaterial = wallMaterials[PlayerPrefs.GetInt("PlayerMaterial")];

                        for (int i = 0; i < childBreakables.Length; i++)
                        {
                            childBreakables[i].GetComponent<Renderer>().sharedMaterial = wallMaterials[PlayerPrefs.GetInt("PlayerMaterial")];
                        }
                    }
                    else
                        scoreHealth -= GameManager.instance.damage;
                    textScoreHealth.text = scoreHealth.ToString();
                }
                print("Maviii");
            }

            if (gameObject.GetComponent<Renderer>().sharedMaterial.name == "WallGreen")
            {
                if (PlayerPrefs.GetInt("PlayerMaterial") == 1)
                {
                    scoreHealth += GameManager.instance.damage;
                    textScoreHealth.text = scoreHealth.ToString();
                }
                else
                {
                    if (scoreHealth - GameManager.instance.damage < 0)
                    {
                        scoreHealth = GameManager.instance.damage - scoreHealth;
                        gameObject.GetComponent<Renderer>().sharedMaterial = wallMaterials[PlayerPrefs.GetInt("PlayerMaterial")];

                        for (int i = 0; i < childBreakables.Length; i++)
                        {
                            childBreakables[i].GetComponent<Renderer>().sharedMaterial = wallMaterials[PlayerPrefs.GetInt("PlayerMaterial")];
                        }
                    }
                    else
                        scoreHealth -= GameManager.instance.damage;
                    textScoreHealth.text = scoreHealth.ToString();

                }
                print("Yesill");
            }

            if (gameObject.GetComponent<Renderer>().sharedMaterial.name == "WallRed")
            {
                if (PlayerPrefs.GetInt("PlayerMaterial") == 2)
                {
                    scoreHealth += GameManager.instance.damage;
                    textScoreHealth.text = scoreHealth.ToString();
                }
                else
                {
                    if (scoreHealth - GameManager.instance.damage < 0)
                    {
                        scoreHealth = GameManager.instance.damage - scoreHealth;
                        gameObject.GetComponent<Renderer>().sharedMaterial = wallMaterials[PlayerPrefs.GetInt("PlayerMaterial")];

                        for (int i = 0; i < childBreakables.Length; i++)
                        {
                            childBreakables[i].GetComponent<Renderer>().sharedMaterial = wallMaterials[PlayerPrefs.GetInt("PlayerMaterial")];
                        }
                    }
                    else
                        scoreHealth -= GameManager.instance.damage;
                    textScoreHealth.text = scoreHealth.ToString();

                }
                print("Kirmiziii");
            }
            other.gameObject.SetActive(false);
        }
    }
}
