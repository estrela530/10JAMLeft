using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
    //取得系------------------------
    [SerializeField]
    GameObject blockObject;
    //GameObject blockObject = GameObject.FindGameObjectWithTag("Block");

    //------------------------------

    float randomYPosition;
    int CreateSpeed;
    BlockMove blockMove;
    float blockSpeed;
    //今が時間停止の効果が出ているときかを判断する
    public bool isTimeStopFlag;

    //Block用配列
    GameObject[] blocks;
    BlockMove[] blockMoves;
    List<GameObject> blocksObjlist = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateSpeed = 0;
        blockSpeed = -0.01f;
        blockMove = blockObject.GetComponent<BlockMove>();
        //blockMove = transform.GetComponentInChildren<BlockMove>();
        blocks = new GameObject[20];
        blockMoves = new BlockMove[20];
        isTimeStopFlag = false;

        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    blocks[i] = this.transform.GetChild(i).gameObject;            
        //}
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

        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    blocks[i] = this.transform.GetChild(i).gameObject;
        //}

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
                Time.timeScale = 0;
            }
            
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1;
            //blocksObjlistの中身のSpeedBack()を全実行
            foreach (var list in blocksObjlist)
            {
                list.GetComponent<BlockMove>().SpeedBack();
            }

            //blocksObjlistの中身全削除
            blocksObjlist.Clear();

            isTimeStopFlag = false;
        }

    }

    /// <summary>
    /// Block生成
    /// </summary>
    void CreateBlock()
    {
        randomYPosition = (float)Random.Range(-4.0f, 4.0f);

        var parent = this.transform;
        GameObject bObj = Instantiate(blockObject, new Vector3(-4, randomYPosition, 0), Quaternion.identity, parent);
        bObj.name = "Block" + transform.childCount;
        //blockObject.transform.parent = transform.parent;
    }

    /// <summary>
    /// 時間停止・逆再生
    /// </summary>
    void GoRight()
    {
        Time.timeScale = 0;
        blockMove.blockMoveSpeed = blockSpeed;
        //blockSpeed = blockMove.blockMoveSpeed;
        //blockSpeed = -1;
    }
}
