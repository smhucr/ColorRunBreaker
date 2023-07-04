using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] public ObjectsPool objectPool = null;

    // SpawnPoint
    public Transform bulletPoint;

    private void Start()
    {
        GameManager.instance.isAvailableShoot = true;
        StartCoroutine(Shoot(0));
    }
    public IEnumerator Shoot(int objectType)
    {
        //Spawn New Object
        if (GameManager.instance.isAvailableShoot && GameManager.instance.startGame)
        {
            var obj = objectPool.GetPooledObject(objectType);
            obj.transform.position = bulletPoint.position;
            GameManager.instance.audioSource.PlayOneShot(GameManager.instance.audioClips[0], 0.1f);
            StartCoroutine(Disableobj(obj));
        }
        yield return new WaitForSeconds(GameManager.instance.fireRate);
        StartCoroutine(Shoot(objectType));

    }

    // Object Disable
    IEnumerator Disableobj(GameObject obj)
    {
        yield return new WaitForSeconds(3);
        obj.SetActive(false);
    }
}
