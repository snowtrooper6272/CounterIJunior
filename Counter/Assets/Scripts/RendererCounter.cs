using TMPro;
using UnityEngine;
using System;

public class RendererCounter : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    private void OnEnable()
    {
        _counter.ValueChanged += ChangeText;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= ChangeText;
    }

    private void ChangeText(float value) 
    {
        _counterText.text = value.ToString();
    }
}
