using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
    //�擾�n------------------------
    [SerializeField]
    GameObject blockObject;
    //GameObject blockObject = GameObject.FindGameObjectWithTag("Block");

    //------------------------------

    float randomYPosition;
    int CreateSpeed;
    BlockMove blockMove;

    float blockSpeed;

    //Block�p�z��
    GameObject[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        CreateSpeed = 0;
        blockSpeed = -0.01f;
        blockMove = blockObject.GetComponent<BlockMove>();
        blocks = new GameObject[20];
        //for (int i = 0; i < transform.parent.childCount; i++)
        //{
        //    blocks[i] = this.transform.GetChild(i).gameObject;            
        //}

    }

    // Update is called once per frame
    //Block�̋t�Đ����Ɏ~�܂�悤��Fixed�ύX
    void FixedUpdate()
    {
        CreateSpeed++;
        if (CreateSpeed > 60)
        {
            CreateBlock();
            CreateSpeed = 0;
        }

        Debug.Log(transform.childCount);

        for (int i = 0; i < transform.childCount; i++)
        {
            blocks[i] = this.transform.GetChild(i).gameObject;
            blockMove = blocks[i].GetComponent<BlockMove>();
        }

    //    foreach (var blo in blocks)
    //    {
    //        blockMove = transform.GetComponentInChildren<BlockMove>();
    //    }
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (var blo in blocks)
        //{
        //                

        //}


        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("������Ă�`");
            GoRight();
        }
        else
        {
            Time.timeScale = 1;
            blockMove.blockMoveSpeed = 0.01f;
        }



    }

    /// <summary>
    /// Block����
    /// </summary>
    void CreateBlock()
    {
        randomYPosition = (float)Random.Range(-4.0f, 4.0f);

        var parent = this.transform;
        Instantiate(blockObject, new Vector3(-4, randomYPosition, 0), Quaternion.identity,parent);
        //blockObject.transform.parent = transform.parent;
    }

    /// <summary>
    /// ���Ԓ�~�E�t�Đ�
    /// </summary>
    void GoRight()
    {
        Time.timeScale = 0;
        blockMove.blockMoveSpeed = blockSpeed;
        //blockSpeed = blockMove.blockMoveSpeed;
        //blockSpeed = -1;
    }
}
