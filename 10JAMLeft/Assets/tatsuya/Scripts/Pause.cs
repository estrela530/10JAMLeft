using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPause = false;
    [SerializeField] private GameObject PausePrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        PausePrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPause)
            {
                TrueActive();
                Time.timeScale = 0.0f;
                isPause = true;
            }
            else
            {
                FalseActive();
                Time.timeScale = 1.0f;
                isPause = false;
            }
        }
    }

    public bool GetPause()
    {
        return isPause;
    }

    public void TrueActive()
    {
        PausePrefab.SetActive(true);
    }

    public void FalseActive()
    {
        PausePrefab.SetActive(false);
    }
}
