using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    public UnityAction<float> ValueChanged;

    private float _currentValue = 0;
    private bool _isRunningCoroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isRunningCoroutine == false) 
            {
                StartCoroutine(nameof(IncreasingCounter));
                _isRunningCoroutine = true;
            }
            else 
            {
                StopAllCoroutines();
                _isRunningCoroutine = false;
            }
        }
    }

    private IEnumerator IncreasingCounter() 
    {
        while (true) 
        {
            _currentValue += Time.deltaTime;
            ValueChanged.Invoke(_currentValue);

            yield return null;
        }
    }
}