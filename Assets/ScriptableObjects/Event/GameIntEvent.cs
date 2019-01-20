using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Int")]
public class GameIntEvent : ScriptableObject
{
    private List<GameIntEventListener> listeners = new List<GameIntEventListener>();

    public void Raise(int value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(GameIntEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnRegisterListener(GameIntEventListener listener)
    {
        listeners.Remove(listener);

    }
}
