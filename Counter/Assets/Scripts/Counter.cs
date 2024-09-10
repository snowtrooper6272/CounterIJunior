using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _interval;

    public event UnityAction<float> ValueChanged;

    Coroutine _increasingCounter;

    private int _mouseButton = 0;
    private float _currentValue = 0;
    private bool _isRunningCoroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            if (_isRunningCoroutine == false) 
            {
                _increasingCounter = StartCoroutine(IncreasingCounter());
                _isRunningCoroutine = true;
            }
            else 
            {
                StopCoroutine(_increasingCounter);
                _isRunningCoroutine = false;
            }
        }
    }

    private IEnumerator IncreasingCounter() 
    {
        while (true) 
        {
            _currentValue++;
            ValueChanged.Invoke(_currentValue);
            yield return new WaitForSeconds(_interval);
        }
    }
}