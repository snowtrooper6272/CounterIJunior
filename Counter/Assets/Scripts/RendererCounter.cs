using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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

    public void ChangeText(float value) 
    {
        _counterText.text = value.ToString();
    }
}
