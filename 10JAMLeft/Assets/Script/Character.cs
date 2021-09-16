using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isGround; //地面かどうか
    bool isJump;    //ジャンプできるか
    public float force; //力
    public float vecY;  //↑ベクトル
    public bool isRotation = false; //移動してる風用の回転
    float rotateScale;
    Rigidbody rb;
    bool isDead;    //死か

    //ジャンプの仕方（見分け用
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
        if (switchJamp)     //力を加える
            rb.AddForce(new Vector3(0, force, 0));
        else               //Y軸にベクトルを加える
            rb.velocity = new Vector3(0, vecY, 0);
    }
}
