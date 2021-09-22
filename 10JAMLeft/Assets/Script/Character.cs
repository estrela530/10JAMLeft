using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isGround { get; set; } //�n�ʂ��ǂ���
    public bool isJump;    //�W�����v�ł��邩
    public float force; //��
    public bool isDeadFlag;
    public float vecY;  //���x�N�g��
    Rigidbody rb;

    public float time = 0;  //���͂���Ă���̌o�ߎ��ԕۑ��ptime
    float precedeTime = 0.2f;   //��s���͑ҋ@����

    Renderer renderer;

    //�W�����v�̎d���i�������p ���̂Ƃ���قڕω��Ȃ�
    public bool switchJamp;

    //���S�t���O
    public bool IsDeadFlag
    {
        get => isDeadFlag;
        set => isDeadFlag = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGround = false;
        rb = GetComponent<Rigidbody>();
        isDeadFlag = false;
        renderer = GetComponent<Renderer>();

        switchJamp = true;
    }

    void Update()
    {
        //if(Mathf.Approximately(Time.timeScale,0f))
        //{
        //    return;
        //}

        if (!renderer.isVisible)
        {
            if(transform.position.y <=0)
            {
                isDeadFlag = true;
                Destroy(gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
        if (isJump)
        {
            time += Time.deltaTime;
            if (time > precedeTime)
            {
                isJump = false;
                time = 0;
            }
        }

        //�W�����v�@�؂�ւ�
        if (Input.GetKeyDown(KeyCode.A))
        {
            switchJamp = !switchJamp;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isJump)
        {
            if (isGround)
            {
                isJump = false;
                isGround = false;
                time = 0;
                Jump();
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Trap")
        {
            isDeadFlag = true;
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
