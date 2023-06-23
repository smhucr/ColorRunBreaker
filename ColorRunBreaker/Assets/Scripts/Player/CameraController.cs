using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform targetLookAt;
    public bool lookAtTarget;
    public Controller controller;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Update()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, smoothedPosition, 3 * Time.deltaTime);

            if (lookAtTarget)
                transform.LookAt(targetLookAt);
        }

    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        targetLookAt = newTarget;
    }

}

