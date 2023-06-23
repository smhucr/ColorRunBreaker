using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject[] levels;

    private void Awake()
    {
        int randomNumber = Random.Range(0, 9);
        levels[randomNumber].SetActive(true);
    }

}
