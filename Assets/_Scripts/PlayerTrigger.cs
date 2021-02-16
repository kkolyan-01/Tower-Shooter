using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _enter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            _enter.Invoke();
    }
}
