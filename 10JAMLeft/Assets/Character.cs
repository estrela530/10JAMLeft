using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isGround;
    bool isJump;
    public float force;
    public float vecY;
    Rigidbody rb;

    public bool switchJamp;
    public bool switchUpdate;
    // Start is called before the first frame update
    void Start()
    {
        isGround = false;
        //force = 200f;
        rb = GetComponent<Rigidbody>();

        switchJamp = true;
        switchUpdate = true;
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            switchJamp = !switchJamp;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isJump)
        {
            isJump = false;
            isGround = false;
            if (switchJamp)
                rb.AddForce(new Vector3(0, force, 0));
            else
                rb.velocity = new Vector3(0, vecY, 0);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isGround = true;
        }
    }
}
