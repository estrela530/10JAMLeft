using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    Vector3 objectPoint;    //ブロックのポジション変換用
    Vector3 screenPoint;    //ブロックのスクリーンポジション

    bool clickedObject;     //クリックされたところにブロックがあるか

    Vector3 currentMousePos;    //マウスポジション格納用(前フレーム)
    Vector3 previousMousePos;   //マウスポジション格納用(現在フレーム)

    GameObject clickGameObject; //クリックしたオブジェクトを取得

    // Start is called before the first frame update
    void Start()
    {
        objectPoint = transform.position;   //初期化
        clickedObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Mathf.Approximately(Time.timeScale,0f))
        //{
        //    return;
        //}

        //現在のフレームのマウスポジション格納
        currentMousePos = Input.mousePosition;

        //クリック時処理
        if (Input.GetMouseButtonDown(0))
        {
            //クリックした先にレイを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            //ブロックがある場合
            if(Physics.Raycast(ray,out hit))
            {
                clickGameObject = hit.collider.gameObject;
                clickedObject = true;
            }
        }

        //キーを離したらそこにブロックを配置
        if (Input.GetMouseButtonUp(0))
        {
            clickedObject = false;
        }

        if (clickedObject&&this.gameObject.name == clickGameObject.name)
        {

            //Blockの座標をワールドからスクリーンに
            objectPoint = Camera.main.WorldToScreenPoint(transform.position);

            //Blockのポジションをマウスのベクトル分移動する
            screenPoint = new Vector3(
                (objectPoint + (currentMousePos - previousMousePos)).x,
                (objectPoint + (currentMousePos - previousMousePos)).y,
                objectPoint.z);

            //Blockの座標をスクリーンからワールドに
            objectPoint = Camera.main.ScreenToWorldPoint(screenPoint);

        }
        //ブロックのポジションに変化を割り当て
        transform.position = objectPoint;

        //前のフレームのマウスポジション格納
        previousMousePos = Input.mousePosition;
    }
}
