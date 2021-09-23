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

    [SerializeField]
    private string[] command = new string[] { "a", "p", "e", "x" };
    private int commandCount = 0;
    public float speed; //�{�[���ړ��p

    //�W�����v�̎d���i�������p ���̂Ƃ���قڕω��Ȃ�
    public bool switchJamp;

    float x;

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
        Command();
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
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
        if (Command())
        {
            x = Input.GetAxis("Horizontal") * speed;
        }

        ////�W�����v�@�؂�ւ�
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    switchJamp = !switchJamp;
        //}
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
                SoundManager.Instance.PlaySeByName("Motion-Pop28-1");
            }
        }
        rb.velocity = new Vector3(x, rb.velocity.y, 0);
        //rb.AddForce(x, rb.velocity.y, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Trap")
        {
            isDeadFlag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "VC")
        {
            isDeadFlag = true;
            Debug.Log("����");
        }
    }

    private void Jump()
    {
        if (switchJamp)     //�͂�������
            rb.AddForce(new Vector3(0, force, 0));
    }

    private bool Command()
    {
        if (commandCount < command.Length && Input.GetKeyDown(command[commandCount]))
        {
            Debug.Log(command[commandCount]);
            commandCount++;
        }
        if (commandCount >= command.Length)
        {
            return true;
        }
        return false;
    }
}
