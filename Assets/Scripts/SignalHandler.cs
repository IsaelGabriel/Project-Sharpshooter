using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalHandler : MonoBehaviour
{
    [SerializeField] private List<SignalHandler> listeners = new List<SignalHandler>();

    protected virtual void ReceiveSignal(string signal){}

    protected void SendSignal(string signal)
    {
        for(int i = 0; i < listeners.Count; i++)
        {
            listeners[i].ReceiveSignal(signal);
        }
    }

    public void AddListener(SignalHandler listener)
    {
        if(!listeners.Contains(listener)) listeners.Add(listener);
    }

    public void RemoveListener(SignalHandler listener)
    {
        if(listeners.Contains(listener)) listeners.Remove(listener);
    }


}
