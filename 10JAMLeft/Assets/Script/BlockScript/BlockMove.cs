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
    //Blockの逆再生時に止まるようにFixed変更
    void Update()
    {
        Debug.Log(blockMoveSpeed);
        //if (Mathf.Approximately(Time.timeScale, 0f))
        //{
        //    return;
        //}
        //BlockXMove();

        //↓これを戻せば時間停止でも動く
        //if (!onClick)
        //    transform.Translate(blockMoveSpeed, 0, 0);

        //if (transform.position.x > 33f)
        //{
        //    Debug.Log("しんだ！");
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
        // 衝突した相手にBlockDethAreaタグが付いているとき
        if (other.gameObject.tag == "BlockDethArea")
        {
            Destroy(this.gameObject);
            Debug.Log("しんだ！");

        }
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

    /// <summary>
    /// blockMoveSpeed取得用メソッド
    /// </summary>
    public float GetSpeed
    {
        get { return blockMoveSpeed; }

        //set { blockMoveSpeed = value; }
    }

    /// <summary>
    /// 巻き戻し時のBlock動作
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
    /// 画面外に行った時の削除処理
    /// </summary>
    public void Destory()
    {
        Destroy(this.gameObject);
    }
}
