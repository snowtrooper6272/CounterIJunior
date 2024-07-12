using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private CounterStarter _counterStarter;

    private float _currentValue = 0;

    private void OnEnable()
    {
        _counterStarter.CounterRan += Change;
    }

    private void OnDisable()
    {
        _counterStarter.CounterRan -= Change;
    }

    public void Change(int countOfClicks) 
    {
        if (countOfClicks % 2 == 1)
        {
            StartCoroutine(IncreasingCounter());
        }
        else 
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator IncreasingCounter() 
    {
        while (true) 
        {
            _currentValue += Time.deltaTime;
            counter.text = _currentValue.ToString();

            yield return null;
        }
    }
}