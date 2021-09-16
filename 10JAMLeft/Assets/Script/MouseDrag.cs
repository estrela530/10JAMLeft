using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    Vector3 objectPoint;    //ブロックのポジション変換用
    Vector3 screenPoint;    //ブロックのスクリーンポジション

    bool clickedObject;     //クリックされたところにブロックがあるか
    Vector3 justMousePosition;
    Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        objectPoint = transform.position;   //初期化
        clickedObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        //クリック時処理
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            //ブロックがある場合
            if(Physics.Raycast(ray,out hit))
            {
                clickedObject = true;
            }
        }

        //キーを離したらそこにブロックを配置
        if (Input.GetMouseButtonUp(0))
        {
            clickedObject = false;
        }

        if (clickedObject)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);

            //Blockの座標をワールドからスクリーンに
            objectPoint = Camera.main.WorldToScreenPoint(mousePosition - transform.position);

            //Blockのポジションをマウスの位置に
            screenPoint = new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                objectPoint.z);

            //Blockの座標をスクリーンからワールドに
            objectPoint = Camera.main.ScreenToWorldPoint(screenPoint);

        }
        //ブロックのポジションに変化を割り当て
        transform.position = objectPoint;

    }
}
