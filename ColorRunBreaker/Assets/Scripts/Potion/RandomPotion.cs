using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPotion : MonoBehaviour
{
    public GameObject[] potionVariants;



    private void Start()
    {
        for (int i = 0; i < potionVariants.Length; i++)
        {
            potionVariants[i].SetActive(false);
        }

        potionVariants[Random.Range(0, 3)].SetActive(true);
    }
}
