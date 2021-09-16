using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
    //éÊìæån------------------------
    [SerializeField]
    GameObject blockObject;
    //GameObject blockObject = GameObject.FindGameObjectWithTag("Block");

    //------------------------------

    float randomYPosition;
    int CreateSpeed;
    BlockMove blockMove;

    float blockSpeed;

    //BlockópîzóÒ
    GameObject[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        CreateSpeed = 0;
        blockSpeed = -0.01f;
        blockMove = blockObject.GetComponent<BlockMove>();
        blocks = new GameObject[20];
        //for (int i = 0; i < transform.parent.childCount; i++)
        //{
        //    blocks[i] = this.transform.GetChild(i).gameObject;            
        //}

    }

    // Update is called once per frame
    //BlockÇÃãtçƒê∂éûÇ…é~Ç‹ÇÈÇÊÇ§Ç…FixedïœçX
    void FixedUpdate()
    {
        CreateSpeed++;
        if (CreateSpeed > 60)
        {
            CreateBlock();
            CreateSpeed = 0;
        }

        Debug.Log(transform.childCount);

        for (int i = 0; i < transform.childCount; i++)
        {
            blocks[i] = this.transform.GetChild(i).gameObject;
            blockMove = blocks[i].GetComponent<BlockMove>();
        }

    //    foreach (var blo in blocks)
    //    {
    //        blockMove = transform.GetComponentInChildren<BlockMove>();
    //    }
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (var blo in blocks)
        //{
        //                

        //}


        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Ç®Ç≥ÇÍÇƒÇÈÅ`");
            GoRight();
        }
        else
        {
            Time.timeScale = 1;
            blockMove.blockMoveSpeed = 0.01f;
        }



    }

    /// <summary>
    /// Blockê∂ê¨
    /// </summary>
    void CreateBlock()
    {
        randomYPosition = (float)Random.Range(-4.0f, 4.0f);

        var parent = this.transform;
        Instantiate(blockObject, new Vector3(-4, randomYPosition, 0), Quaternion.identity,parent);
        //blockObject.transform.parent = transform.parent;
    }

    /// <summary>
    /// éûä‘í‚é~ÅEãtçƒê∂
    /// </summary>
    void GoRight()
    {
        Time.timeScale = 0;
        blockMove.blockMoveSpeed = blockSpeed;
        //blockSpeed = blockMove.blockMoveSpeed;
        //blockSpeed = -1;
    }
}
