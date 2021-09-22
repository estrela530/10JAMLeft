using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomScript : MonoBehaviour
{
    [SerializeField]private bool isPush;

    public bool IsPush
    {
        get => isPush;
        set => isPush = value;
    }

    public void Start()
    {
        isPush = false;
    }

    public void OnClick()
    {
        isPush = true;
    }
}
