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
    float blockMoveSpeed;
    //Block逆再生用

    //BlockのX軸Position
    float blockXPosition;


    // Start is called before the first frame update
    void Start()
    {
        blockMoveSpeed = 0.5f;
        blockXPosition = 0;
    }

    // Update is called once per frame
    //Blockの逆再生時に止まるようにFixed変更
    void FixedUpdate()
    {
        BlockXMove();
        Debug.Log("Fixed確認");
    }

    //Block移動用メソッド
    void BlockXMove()
    {
        //Block移動処理
        blockXPosition = blockObject.transform.position.x;
        blockXPosition += blockMoveSpeed;

    }
}
