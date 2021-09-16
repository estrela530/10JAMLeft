using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    //�擾�n------------------------
    [SerializeField]
    GameObject blockObject;


    //------------------------------

    //Block�̈ړ����x
    float blockMoveSpeed;
    //Block�t�Đ��p

    //Block��X��Position
    float blockXPosition;


    // Start is called before the first frame update
    void Start()
    {
        blockMoveSpeed = 0.5f;
        blockXPosition = 0;
    }

    // Update is called once per frame
    //Block�̋t�Đ����Ɏ~�܂�悤��Fixed�ύX
    void FixedUpdate()
    {
        BlockXMove();
        Debug.Log("Fixed�m�F");
    }

    //Block�ړ��p���\�b�h
    void BlockXMove()
    {
        //Block�ړ�����
        blockXPosition = blockObject.transform.position.x;
        blockXPosition += blockMoveSpeed;

    }
}
