using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour, IDragHandler
{
    float xAxis, yAxis;
    public float sensivity;
    public PlayerControl player;


    public void OnDrag(PointerEventData eventData)
    {
        float x = player.DesiredX;

        float clampx = player.ClampX;

        if (x <= clampx && x >= clampx * -1)
        {
            xAxis = eventData.delta.x * sensivity;
            player.DesiredX += xAxis;
        }
        else
        {
            player.DesiredX = Mathf.Clamp(player.DesiredX, clampx * -1, clampx);
        }
    }








}
