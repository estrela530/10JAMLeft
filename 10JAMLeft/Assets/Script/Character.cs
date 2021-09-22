using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isGround { get; set; } //地面かどうか
    public bool isJump;    //ジャンプできるか
    public float force; //力
    public bool isDeadFlag;
    public float vecY;  //↑ベクトル
    Rigidbody rb;

    public float time = 0;  //入力されてからの経過時間保存用time
    float precedeTime = 0.2f;   //先行入力待機時間

    Renderer renderer;

    [SerializeField]
    private string[] command = new string[] { "a", "p", "e", "x" };
    private int commandCount = 0;
    public float speed; //ボール移動用

    //ジャンプの仕方（見分け用 今のところほぼ変化なし
    public bool switchJamp;

    float x;

    //死亡フラグ
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

        ////ジャンプ法切り替え
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
            Debug.Log("死んだ");
        }
    }

    private void Jump()
    {
        if (switchJamp)     //力を加える
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
