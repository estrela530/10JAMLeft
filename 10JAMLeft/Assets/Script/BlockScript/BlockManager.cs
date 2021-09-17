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
    BlockMove[] blockMoves;
    float blockSpeed;

    //Block用配列
    GameObject[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        CreateSpeed = 0;
        blockSpeed = -0.01f;
        blockMove = blockObject.GetComponent<BlockMove>();
        //blockMove = transform.GetComponentInChildren<BlockMove>();
        blocks = new GameObject[20];
        blockMoves = new BlockMove[20];
        //for (int i = 0; i < transform.parent.childCount; i++)
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

        Debug.Log(transform.childCount);



    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount != 0)
        {
            blockMove = transform.GetComponentInChildren<BlockMove>();

        }

        for (int i = 0; i < transform.childCount; i++)
        {
            blocks[i] = this.transform.GetChild(i).gameObject;
            //blockMoves[i] = blocks[i].GetComponentInChildren<BlockMove>();

        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("おされてる〜");
            Time.timeScale = 0;
            blockMove.SpeedChange();
        }
        else
        {
            Time.timeScale = 1;
            blockMove.SpeedBack();
            //blockMove.blockMoveSpeed = 0.01f;
        }

    }

    /// <summary>
    /// Block生成
    /// </summary>
    void CreateBlock()
    {
        randomYPosition = (float)Random.Range(-4.0f, 4.0f);

        var parent = this.transform;
        Instantiate(blockObject, new Vector3(-4, randomYPosition, 0), Quaternion.identity, parent);
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
