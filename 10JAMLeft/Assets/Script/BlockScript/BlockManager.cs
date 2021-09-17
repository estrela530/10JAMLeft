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
    BlockMove[] blockMoves;
    float blockSpeed;

    //BlockópîzóÒ
    GameObject[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        CreateSpeed = 0;
        blockSpeed = -0.01f;
        blockMove = blockObject.GetComponent<BlockMove>();
        //blockMove = transform.GetComponentInChildren<BlockMove>();
        blocks = new GameObject[20];
        blockMoves = new BlockMove[20];
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



    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount != 0)
        {
            blockMove = transform.GetComponentInChildren<BlockMove>();

        }

        for (int i = 0; i < transform.childCount; i++)
        {
            blocks[i] = this.transform.GetChild(i).gameObject;
            //blockMoves[i] = blocks[i].GetComponentInChildren<BlockMove>();

        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Ç®Ç≥ÇÍÇƒÇÈÅ`");
            Time.timeScale = 0;
            blockMove.SpeedChange();
        }
        else
        {
            Time.timeScale = 1;
            blockMove.SpeedBack();
            //blockMove.blockMoveSpeed = 0.01f;
        }

    }

    /// <summary>
    /// Blockê∂ê¨
    /// </summary>
    void CreateBlock()
    {
        randomYPosition = (float)Random.Range(-4.0f, 4.0f);

        var parent = this.transform;
        Instantiate(blockObject, new Vector3(-4, randomYPosition, 0), Quaternion.identity, parent);
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
