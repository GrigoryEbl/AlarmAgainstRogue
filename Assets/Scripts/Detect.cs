using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Detect : MonoBehaviour
{
    [SerializeField] private UnityEvent _enter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _enter?.Invoke();
            Debug.Log("ALARM");
        }
    }
}