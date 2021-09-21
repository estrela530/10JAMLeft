using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSlider : MonoBehaviour
{
    [SerializeField] private Slider[] sliders;
    [SerializeField] private int firstSelectUI;

    private void Start()
    {
        sliders[firstSelectUI].Select();
    }
}
