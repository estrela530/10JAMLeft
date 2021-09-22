using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
    //�擾�n------------------------
    [SerializeField]
    GameObject blockObject;

    //------------------------------

    float randomYPosition;
    int CreateSpeed;
    BlockMove blockMove;
    float blockSpeed;
    //�������Ԓ�~�̌��ʂ��o�Ă���Ƃ����𔻒f����
    public bool isTimeStopFlag;

    //Block�pList
    List<GameObject> blocksObjlist = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateSpeed = 0;
        blockSpeed = -0.01f;
        isTimeStopFlag = false;
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
                TimeStop();
            }

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isTimeStopFlag == true)
            {
                //blocksObjlist�̒��g��SpeedBack()��S���s
                foreach (var list in blocksObjlist)
                {
                    list.GetComponent<BlockMove>().SpeedBack();
                }

                //blocksObjlist�̒��g�S�폜
                blocksObjlist.Clear();

                TimeStart();
                isTimeStopFlag = false;
            }
        }

    }

    /// <summary>
    /// Block����
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
    /// ���Ԓ�~�E�t�Đ�
    /// </summary>
    void TimeStop()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// ���ԍĐ�
    /// </summary>
    void TimeStart()
    {
        Time.timeScale = 1;
    }

}
