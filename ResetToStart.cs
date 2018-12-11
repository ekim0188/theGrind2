using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetToStart : MonoBehaviour {

    // Use this for initialization
    private Vector3 originalPosition;
    private Quaternion rotation;
    private void Awake()
    {
        originalPosition = transform.position;
        rotation = transform.rotation;
    }
    public void ReturnToStart()
    {
        transform.position = originalPosition;
        transform.rotation = rotation;
    }

    private void OnDestroy()
    {
        Pour.PourAttempted -= ReturnToStart;
    }
}
