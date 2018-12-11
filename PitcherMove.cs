using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitcherMove: MonoBehaviour
{
    private Vector3 position;
    private bool holding;
    public GameObject snapToPoint;
    [SerializeField]
    private float snapToDistance;

    void Update()
    {
        if (holding)
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //-3.21
            position.z = 0.0f;
            if(position.y > -2.37f)
                position.y = -2.37f;
            gameObject.transform.position = position;
        }
    }

    private void OnMouseDown()
    {
        holding = true;
    }

    private void OnMouseUp()
    {
        if (Vector2.Distance(snapToPoint.transform.position, transform.position) < snapToDistance)
        {
            transform.position = snapToPoint.transform.position;
            GameManager.Instance.PitcherOnMachine = true;
        }
        else
        {
            GameManager.Instance.PitcherOnMachine = false;
        }
        Draggable.MouseReleased?.Invoke();
        holding = false;
    }
}
