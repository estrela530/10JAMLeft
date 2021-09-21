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
    //�������Ԓ�~�̌��ʂ��o�Ă���Ƃ����𔻒f����
    public bool isTimeStopFlag;

    //Block�p�z��
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
    //Block�̋t�Đ����Ɏ~�܂�悤��Fixed�ύX
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
                Debug.Log("������Ă�`");

                Transform children = transform.GetComponentInChildren<Transform>();
                //�q���I�u�W�F�N�glist�Ɋi�[
                foreach (Transform blo in children)
                {
                    blocksObjlist.Add(blo.gameObject);
                }
                //blocksObjlist�̒��g��SpeedChange()��S���s
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
            //blocksObjlist�̒��g��SpeedBack()��S���s
            foreach (var list in blocksObjlist)
            {
                list.GetComponent<BlockMove>().SpeedBack();
            }

            //blocksObjlist�̒��g�S�폜
            blocksObjlist.Clear();

            isTimeStopFlag = false;
        }

    }

    /// <summary>
    /// Block����
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
