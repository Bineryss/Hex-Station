using UnityEngine;
using UnityEngine.Events;

public class AstroidController : MonoBehaviour
{
    [SerializeField] private UnityEvent onHit;
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        onHit?.Invoke();
    }
}
