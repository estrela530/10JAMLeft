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
    /// 衝突した時
    /// </summary>
    /// <param name="collision"></param>
    //void OnCollisionEnter(Collision collision)
    //{
    //    // 衝突した相手にPlayerタグが付いているとき
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("クリア！");
    //        goalFlag = true;
    //        Debug.Log("Flag" + goalFlag);
    //    }
    //}
    void OnTriggerEnter(Collider other)
    {
        // 衝突した相手にPlayerタグが付いているとき
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("クリア！");
            goalFlag = true;
            changer.ChangeScene("Clear");
            Debug.Log("Flag" + goalFlag);
        }
    }

}
