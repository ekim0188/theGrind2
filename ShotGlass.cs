using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGlass : MonoBehaviour
{

    private bool isEmpty = true;

    public bool IsEmpty
    {
        get
        {
            return isEmpty;
        }
        set
        {
            isEmpty = value;
        }
    }
    public ShotType ShotType { get; set; }
    public ShotModifier ShotModifier { get; set; }
}
