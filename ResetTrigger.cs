using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour

{

    public void TriggerReset(string s)
    {
        GetComponent<Animator>().ResetTrigger(s);
    }


}
