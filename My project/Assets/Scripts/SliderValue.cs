using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI text;
    void Start()
    {
        slider.onValueChanged.AddListener((v) => { text.text = v.ToString("0")+"%"; });
    }
}
