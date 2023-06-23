using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class PlayerControl : MonoBehaviour
{

    public float RunSpeed;
    public float DesiredX;
    public float ClampX;
    public bool levelEndingWorks;
    public CameraController control;
    public float speed;
    public Transform player;
    public GameObject materialBody;
    private Color[] randomColor = { Color.blue, Color.green, Color.red };

    public Transform mainPlayer
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
            mainPlayer.tag = "Player";
            control.SetTarget(mainPlayer.transform);
        }
    }

    private void Start()
    {
        int randomNumber = Random.Range(0, 3);
        PlayerPrefs.SetInt("PlayerMaterial", randomNumber);
        materialBody.GetComponent<Renderer>().sharedMaterial.color = randomColor[randomNumber];
    }
    private void Update()
    {
        if (GameManager.instance.startGame)
        {
            HandleSwerve();

            if (!levelEndingWorks)
                HandleControll();
        }

    }

    void HandleSwerve()
    {
        Vector3 pos = mainPlayer.position;
        pos.x = Mathf.Clamp(DesiredX, ClampX * -1, ClampX);
        mainPlayer.position = Vector3.Lerp(mainPlayer.position, pos, 3);
    }

    void HandleControll()
    {
        transform.position += (Vector3.forward * RunSpeed * Time.deltaTime);
    }


}
