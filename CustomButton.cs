using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class CustomButton : MonoBehaviour
{
    public UnityEvent unityEvent;

    private void OnMouseDown()
    {
        unityEvent.Invoke();
    }
    
}
