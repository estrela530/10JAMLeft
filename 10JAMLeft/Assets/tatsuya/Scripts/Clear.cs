using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    private SceneChanger change;
    // Start is called before the first frame update
    void Start()
    {
        change = GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            change.ChangeScene();
        }
        
    }
}
