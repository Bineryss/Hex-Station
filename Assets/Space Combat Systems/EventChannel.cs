using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EventChannel", menuName = "Scriptable Objects/EventChannel")]
public class EventChannel : ScriptableObject
{
    public UnityEvent onInvoke = new UnityEvent();
}
