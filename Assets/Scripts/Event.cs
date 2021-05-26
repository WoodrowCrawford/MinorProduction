using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "EventSystem/Event")]
public class Event : ScriptableObject
{
    private List<iListener> _listeners = new List<iListener>();

    public void AddListener(iListener newListener)
    {
        _listeners.Add(newListener);
    }

    public void Raise(GameObject sender = null)
    {
        foreach(iListener listener in _listeners)
        {
            listener.invoke(sender);
        }
    }
}
