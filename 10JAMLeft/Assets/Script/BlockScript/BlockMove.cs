using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    //取得系------------------------
    [SerializeField]
    GameObject blockObject;


    //------------------------------

    //Blockの移動速度
    public float blockMoveSpeed;
    //Block逆再生用

    //BlockのX軸Position
    float blockXPosition;
    //Blockの収納変数
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
    //Blockの逆再生時に止まるようにFixed変更
    void Update()
    {
        //BlockXMove();
        transform.Translate(blockMoveSpeed, 0, 0);
    }

    /// <summary>
    ///Block移動用メソッド
    /// </summary>
    void BlockXMove()
    {
        //Block移動処理
        rb.velocity = new Vector3(blockMoveSpeed, 0, 0);
        //blockXPosition = blockObject.transform.position.x;
        //blockXPosition += blockMoveSpeed;

    }
}
