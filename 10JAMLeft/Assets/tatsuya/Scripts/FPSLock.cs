using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLock : MonoBehaviour
{
    [SerializeField] private int FPS = 60;

    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = FPS;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("FPS:" + Application.targetFrameRate);
    }
}
