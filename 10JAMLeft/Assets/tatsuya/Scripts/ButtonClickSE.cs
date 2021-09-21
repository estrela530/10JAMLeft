using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSE : MonoBehaviour
{
    public void OnClick()
    {
        SoundManager.Instance.PlaySeByName("Xylophone03-01(Multi1-1)");
    }
}
