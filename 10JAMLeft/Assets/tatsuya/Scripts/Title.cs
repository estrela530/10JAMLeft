using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private SceneChange change;
    // Start is called before the first frame update
    void Start()
    {
        change = GetCompornent<SceneChanger>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
