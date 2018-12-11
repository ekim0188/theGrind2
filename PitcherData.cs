using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitcherData : MonoBehaviour
{
    private MilkType milkType;
    public MilkType MilkType
    {
        get { return milkType; }
        set { milkType = value; IsEmpty = false; }
    }
    public bool IsEmpty { get; set; }
    public void FillPitcher()
    {
        if(GameManager.Instance.PitcherOnMachine)
        { 
            MilkType = GameManager.Instance.SelectedMilk;
        }
    }

    private void Awake()
    {
        IsEmpty = true;
    }
}
