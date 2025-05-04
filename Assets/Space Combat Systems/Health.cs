using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private int health = 100;
    [SerializeField] private UnityEvent OnDestroyed;


    void Start()
    {
        label.text = health.ToString();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag != "damage") return;

        health = Math.Max(0, health - 10);
        label.text = health.ToString();

        if (health == 0)
        {
            OnDestroyed?.Invoke();
        }
    }
}
