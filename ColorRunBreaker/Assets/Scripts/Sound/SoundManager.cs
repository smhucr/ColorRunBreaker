using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private GameObject[] soundImages;

    void Start()
    {
        //GameManager.instance.audioSource.mute = true;
        if (PlayerPrefs.GetInt("SoundStatus") == 0)
        {
            GameManager.instance.audioSource.mute = false;
            soundImages[0].SetActive(true);
            soundImages[1].SetActive(false);
        }
        else if(PlayerPrefs.GetInt("SoundStatus") == 1)
        {
            GameManager.instance.audioSource.mute = true;
            soundImages[0].SetActive(false);
            soundImages[1].SetActive(true);
        }
    }

    public void SoundOn()
    {
        PlayerPrefs.SetInt("SoundStatus", 0); //Sound ON
        GameManager.instance.audioSource.mute = false;
        soundImages[0].SetActive(true);
        soundImages[1].SetActive(false);
    }

    public void SoundOff()
    {
        PlayerPrefs.SetInt("SoundStatus", 1); //Sound OFF
        GameManager.instance.audioSource.mute = true;
        soundImages[0].SetActive(false);
        soundImages[1].SetActive(true);
    }

}
