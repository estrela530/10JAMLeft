using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour
{
    public UnityEvent OnEnterGround;    //着地した場合の処理

    public UnityEvent OnExitGround;     //地面から離れた場合の処理

    int enterNum = 0;   //接地数

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
