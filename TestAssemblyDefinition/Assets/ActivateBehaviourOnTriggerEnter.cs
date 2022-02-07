using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ActivateBehaviourOnTriggerEnter : MonoBehaviour
{

    public UnityEvent onEnterEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("AA");
        onEnterEvent?.Invoke();
    }
}
