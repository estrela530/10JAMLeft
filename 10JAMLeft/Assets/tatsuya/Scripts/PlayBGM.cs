using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    public string playBGM;

    // Start is called before the first frame update
    void Awake()
    {
        if(SoundManager.Instance.IsPlayBGM)
        {
            SoundManager.Instance.StopBgm();
        }
    }

    // Update is called once per frame
    void Update()
    {
        SoundManager.Instance.PlayBgmByName(playBGM);
    }
}
