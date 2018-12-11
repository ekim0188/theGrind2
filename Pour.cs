using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    private List<GameObject> cups = new List<GameObject>();
    private float pourDistance = 1.6f;
    private GameObject nearestCup;
    private CupData cup;
    private ShotGlass shotGlass;
    private PitcherData pitcher;
    private ResetToStart reset;

    public static Action PourAttempted;

    private void Awake()
    {
        InstantiateAndAttachToDraggable.CupSpawned += UpdateCupsList;
        shotGlass = GetComponent<ShotGlass>();
        pitcher = GetComponent<PitcherData>();
        reset = GetComponent<ResetToStart>();
        Draggable.MouseReleased += TryPour;
    }
    private void Update()
    {
        bool close = false;
        for(int i = 0; i < cups.Count; i++)
        {
            if(cups[i] == null)
                continue;
            if(Vector2.Distance(cups[i].transform.position, transform.position) < pourDistance)
            {
                close = true;
                transform.rotation = Quaternion.Euler(0, 0, 30.0f);
                nearestCup = cups[i];
                cup = nearestCup.GetComponent<CupData>();
                if(reset!=null)
                    PourAttempted += reset.ReturnToStart;
                break;
            }
        }
        if(!close)
        {
            if(reset != null)
                PourAttempted -= reset.ReturnToStart;
            nearestCup = null;
            cup = null;
            transform.rotation = Quaternion.identity;
        }
    }

    public void UpdateCupsList()
    {
        cups = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cup"));
    }

    //Not necessary but in case any objects are destroyed events should be unregistered from
    private void OnDestroy()
    {
        InstantiateAndAttachToDraggable.CupSpawned -= UpdateCupsList;
    }

    private void TryPour()
    {
        if(cup == null)
            return;

        //bad code
        if(shotGlass != null)
        {
            if(shotGlass.IsEmpty)
            {
                PourAttempted.Invoke();
                return;
            }
                

            cup.ShotModifier = shotGlass.ShotModifier;
            cup.ShotType = shotGlass.ShotType;

            PourAttempted.Invoke();
        }
        if(pitcher != null)
        {
            if(pitcher.IsEmpty)
            {
                PourAttempted.Invoke();
                return;
            }
                
            cup.MilkType = pitcher.MilkType;
            PourAttempted.Invoke();
        }
    }
}

