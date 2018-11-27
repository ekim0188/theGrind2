 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InstantiateAndAttachToDraggable : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        GameObject temp = Instantiate(objectPrefab, transform.position, Quaternion.identity);
        //temp.GetComponent<Draggable>().AddDropLocation(new Vector3(0,0,0));
        temp.GetComponent<SpriteRenderer>().sortingLayerName = "BarObjects";
        temp.GetComponent<Draggable>().Held = true;
    }
}
