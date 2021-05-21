using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameEventListenerBehavior : MonoBehaviour, iListener
{
    [SerializeField]
    private UnityEvent _actions;

    [SerializeField]
    private Event _event;

    [SerializeField]
    private GameObject _intendedSender;

    // Start is called before the first frame update
    void Start()
    {
        _event.AddListener(this);
    }

    public void invoke(GameObject sender)
    {
        if (_intendedSender == null || sender == _intendedSender)
            _actions.Invoke();
    }
}
