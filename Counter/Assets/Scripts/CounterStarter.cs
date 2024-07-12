using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CounterStarter : MonoBehaviour
{
    public event UnityAction<int> CounterRan;

    private int _countOfClicks;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            _countOfClicks++;

            CounterRan.Invoke(_countOfClicks);
        }
    }
}
