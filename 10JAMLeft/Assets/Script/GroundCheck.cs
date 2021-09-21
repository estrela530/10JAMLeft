using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour
{
    public UnityEvent OnEnterGround;    //���n�����ꍇ�̏���

    public UnityEvent OnExitGround;     //�n�ʂ��痣�ꂽ�ꍇ�̏���

    int enterNum = 0;   //�ڒn��

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
