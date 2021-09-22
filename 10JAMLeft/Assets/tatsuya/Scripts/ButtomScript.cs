using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomScript : MonoBehaviour
{
    private bool isPush;

    public bool IsPush
    {
        get => isPush;
        set => isPush = value;
    }
    public void OnClick()
    {
        isPush = true;
    }
}
