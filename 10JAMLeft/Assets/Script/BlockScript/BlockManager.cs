using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
    //取得系------------------------
    [SerializeField]
    GameObject blockObject;

    //------------------------------

    float randomYPosition;
    int CreateSpeed;
    BlockMove blockMove;
    float blockSpeed;
    //今が時間停止の効果が出ているときかを判断する
    public bool isTimeStopFlag;

    //Block用List
    List<GameObject> blocksObjlist = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateSpeed = 0;
        blockSpeed = -0.01f;
        isTimeStopFlag = false;
    }

    // Update is called once per frame
    //Blockの逆再生時に止まるようにFixed変更
    void FixedUpdate()
    {
        CreateSpeed++;
        if (CreateSpeed > 60)
        {
            CreateBlock();
            CreateSpeed = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f) && isTimeStopFlag == false)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isTimeStopFlag = true;

            if (isTimeStopFlag == true)
            {
                Debug.Log("おされてる～");

                Transform children = transform.GetComponentInChildren<Transform>();
                //子供オブジェクトlistに格納
                foreach (Transform blo in children)
                {
                    blocksObjlist.Add(blo.gameObject);
                }
                //blocksObjlistの中身のSpeedChange()を全実行
                foreach (var list in blocksObjlist)
                {
                    list.GetComponent<BlockMove>().SpeedChange();
                }
                TimeStop();
            }

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isTimeStopFlag == true)
            {
                //blocksObjlistの中身のSpeedBack()を全実行
                foreach (var list in blocksObjlist)
                {
                    list.GetComponent<BlockMove>().SpeedBack();
                }

                //blocksObjlistの中身全削除
                blocksObjlist.Clear();

                TimeStart();
                isTimeStopFlag = false;
            }
        }

    }

    /// <summary>
    /// Block生成
    /// </summary>
    void CreateBlock()
    {
        randomYPosition = (float)Random.Range(-4.0f, 4.0f);

        var parent = this.transform;
        GameObject bObj = Instantiate(blockObject, new Vector3(-12, randomYPosition, 0), Quaternion.identity, parent);
        bObj.name = "Block" + transform.childCount;
        //blockObject.transform.parent = transform.parent;
    }

    /// <summary>
    /// 時間停止・逆再生
    /// </summary>
    void TimeStop()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// 時間再生
    /// </summary>
    void TimeStart()
    {
        Time.timeScale = 1;
    }

}
