using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool goalFlag;
    private SceneChanger changer;

    private void Start()
    {
        changer = FindObjectOfType<SceneChanger>();
    }

    public bool IsGoal
    {
        get => goalFlag;
        set => goalFlag = value;
    }

    /// <summary>
    /// �Փ˂�����
    /// </summary>
    /// <param name="collision"></param>
    //void OnCollisionEnter(Collision collision)
    //{
    //    // �Փ˂��������Player�^�O���t���Ă���Ƃ�
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("�N���A�I");
    //        goalFlag = true;
    //        Debug.Log("Flag" + goalFlag);
    //    }
    //}
    void OnTriggerEnter(Collider other)
    {
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("�N���A�I");
            goalFlag = true;
            changer.ChangeScene("Clear");
            Debug.Log("Flag" + goalFlag);
        }
    }

}
