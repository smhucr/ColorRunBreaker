using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeColor : MonoBehaviour
{

    public Material playerMaterial;
    public Material[] allMaterials;
    public GameObject particleEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Colors Are [0,1,2] => [Blue,Green,Red]

            if (gameObject.CompareTag("BluePot"))
            {
                PlayerPrefs.SetInt("PlayerMaterial", 0);
                other.GetComponent<Renderer>().sharedMaterial.color = Color.blue ;
                print(other);
                GameManager.instance.ParticleEffectPooling(1, gameObject.transform);
                gameObject.SetActive(false);
            }
            else if (gameObject.CompareTag("GreenPot"))
            {
                PlayerPrefs.SetInt("PlayerMaterial", 1);
                other.GetComponent<Renderer>().sharedMaterial.color = Color.green;
                print(other);
                GameManager.instance.ParticleEffectPooling(1, gameObject.transform);
                gameObject.SetActive(false);
            }
            else if (gameObject.CompareTag("RedPot"))
            {
                PlayerPrefs.SetInt("PlayerMaterial", 2);
                other.GetComponent<Renderer>().sharedMaterial.color = Color.red;
                print(other);
                GameManager.instance.ParticleEffectPooling(1, gameObject.transform);
                gameObject.SetActive(false);
            }



        }


    }
}
