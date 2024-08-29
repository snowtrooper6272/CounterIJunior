using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _interval;

    public UnityAction<float> ValueChanged;

    private int _mousebutton = 0;
    private float _currentValue = 0;
    private bool _isRunningCoroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mousebutton))
        {
            if (_isRunningCoroutine == false) 
            {
                StartCoroutine(nameof(IncreasingCounter));
                _isRunningCoroutine = true;
            }
            else 
            {
                StopCoroutine(nameof(IncreasingCounter));
                _isRunningCoroutine = false;
            }
        }
    }

    private IEnumerator IncreasingCounter() 
    {
        float currentTime = 0;

        while (true) 
        {
            currentTime += Time.deltaTime;

            if (currentTime >= _interval) 
            {
                _currentValue++;
                currentTime = 0;
                ValueChanged.Invoke(_currentValue);
            }

            yield return null;
        }
    }
}