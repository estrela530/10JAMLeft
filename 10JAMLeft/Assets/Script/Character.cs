using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isGround { get; set; } //地面かどうか
    public bool isJump;    //ジャンプできるか
    public float force; //力
    public float vecY;  //↑ベクトル
    Rigidbody rb;
    bool isDead;    //死か

    public float time = 0;  //入力されてからの経過時間保存用time
    float precedeTime = 0.2f;   //先行入力待機時間

    Renderer renderer;

    //ジャンプの仕方（見分け用 今のところほぼ変化なし
    public bool switchJamp;
    // Start is called before the first frame update
    void Start()
    {
        isGround = false;
        rb = GetComponent<Rigidbody>();
        isDead = false;
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
                isDead = true;
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

        //ジャンプ法切り替え
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
            isDead = true;
        }
    }

    private void Jump()
    {
        if (switchJamp)     //力を加える
            rb.AddForce(new Vector3(0, force, 0));
        else               //Y軸にベクトルを加える
            rb.velocity = new Vector3(0, vecY, 0);
    }
}
