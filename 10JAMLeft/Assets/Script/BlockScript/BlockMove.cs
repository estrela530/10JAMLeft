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
    public float blockMoveSpeed;
    //Block�t�Đ��p

    //Block��X��Position
    float blockXPosition;
    //Block�̎��[�ϐ�
    GameObject block;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        blockMoveSpeed = 0.01f;
        blockXPosition = 0;
        //block = blockObject.GetComponent<GameObject>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //Block�̋t�Đ����Ɏ~�܂�悤��Fixed�ύX
    void Update()
    {
        //BlockXMove();
        transform.Translate(blockMoveSpeed, 0, 0);
    }

    /// <summary>
    ///Block�ړ��p���\�b�h
    /// </summary>
    void BlockXMove()
    {
        //Block�ړ�����
        rb.velocity = new Vector3(blockMoveSpeed, 0, 0);
        //blockXPosition = blockObject.transform.position.x;
        //blockXPosition += blockMoveSpeed;

    }
}
