using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour
{
    public UnityEvent OnEnterGround;    //’…’n‚µ‚½ê‡‚Ìˆ—

    public UnityEvent OnExitGround;     //’n–Ê‚©‚ç—£‚ê‚½ê‡‚Ìˆ—

    int enterNum = 0;   //Ú’n”

    private void OnTriggerEnter(Collider other)
    {
        enterNum++;
        OnEnterGround.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        enterNum--;
        if (enterNum <= 0)
        {
            OnExitGround.Invoke();
        }
    }
}
