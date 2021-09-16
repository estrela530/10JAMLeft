using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isGround; //�n�ʂ��ǂ���
    bool isJump;    //�W�����v�ł��邩
    public float force; //��
    public float vecY;  //���x�N�g��
    public bool isRotation = false; //�ړ����Ă镗�p�̉�]
    float rotateScale;
    Rigidbody rb;
    bool isDead;    //����

    //�W�����v�̎d���i�������p
    public bool switchJamp;
    // Start is called before the first frame update
    void Start()
    {
        isGround = false;
        rotateScale = 1;
        rb = GetComponent<Rigidbody>();
        isDead = false;

        switchJamp = true;
    }

    void Update()
    {
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
            }
        }

        //�W�����v�@�؂�ւ�
        if (Input.GetKeyDown(KeyCode.A))
        {
            switchJamp = !switchJamp;
        }

        if (isDead)
        {

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isJump)
        {
            isJump = false;
            isGround = false;
            Jump();
        }

        if (isRotation)
            transform.Rotate(new Vector3(0, 0, rotateScale));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Block")
        {
            isGround = true;
        }

        if (other.gameObject.tag == "Trap")
        {
            isDead = true;
        }
    }

    private void Jump()
    {
        if (switchJamp)     //�͂�������
            rb.AddForce(new Vector3(0, force, 0));
        else               //Y���Ƀx�N�g����������
            rb.velocity = new Vector3(0, vecY, 0);
    }
}
