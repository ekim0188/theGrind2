using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Draggable : MonoBehaviour
{

    [SerializeField] private float snapDistance;
    [SerializeField] private List<GameObject> dropLocations;

    private bool held;
    private Vector3 pos;

    public bool Held
    {
        get
        {
            return held;
        }
        set
        {
            held = value;
        }
    }

    public List<GameObject> DropLocations
    {
        get
        {
            return dropLocations;
        }

        set
        {
            dropLocations = value;
        }
    }

    public void AddDropLocation(Vector3 vector3)
    {
        throw new NotImplementedException();
    }


    public float SnapDistance
    {
        get
        {
            return snapDistance;
        }

        set
        {
            snapDistance = value;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            held = false;
        }

        if (held)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            transform.position = pos;
        }
    }

    private void OnMouseDown()
    {
        held = true;
    }

    private void OnMouseUp()
    {
        foreach (GameObject g in DropLocations)
        {
            if (Vector2.Distance(g.transform.position, transform.position) < SnapDistance)
            {
                transform.position = g.transform.position;
                break;
            }
        }
    }
}
