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

    public bool onClick { get; set; }

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
        Debug.Log(blockMoveSpeed);
        //if (Mathf.Approximately(Time.timeScale, 0f))
        //{
        //    return;
        //}
        //BlockXMove();

        //�������߂��Ύ��Ԓ�~�ł�����
        //if (!onClick)
        //    transform.Translate(blockMoveSpeed, 0, 0);

        //if (transform.position.x > 33f)
        //{
        //    Debug.Log("���񂾁I");
        //    Destory();
        //}

        //if (!GetComponent<Renderer>().isVisible)
        //{
        //    Destroy(this.gameObject);
        //}
    }

    private void FixedUpdate()
    {
        if (!onClick)
            transform.Translate(blockMoveSpeed, 0, 0);

    }


    void OnTriggerEnter(Collider other)
    {
        // �Փ˂��������BlockDethArea�^�O���t���Ă���Ƃ�
        if (other.gameObject.tag == "BlockDethArea")
        {
            Destroy(this.gameObject);
            Debug.Log("���񂾁I");

        }
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

    /// <summary>
    /// blockMoveSpeed�擾�p���\�b�h
    /// </summary>
    public float GetSpeed
    {
        get { return blockMoveSpeed; }

        //set { blockMoveSpeed = value; }
    }

    /// <summary>
    /// �����߂�����Block����
    /// </summary>
    public void SpeedChange()
    {
        blockMoveSpeed = -0.01f;
    }

    public void SpeedBack()
    {
        blockMoveSpeed = 0.01f;
    }

    /// <summary>
    /// ��ʊO�ɍs�������̍폜����
    /// </summary>
    public void Destory()
    {
        Destroy(this.gameObject);
    }
}
