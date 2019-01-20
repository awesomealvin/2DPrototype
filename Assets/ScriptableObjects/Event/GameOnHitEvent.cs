using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/On Hit")]
public class GameOnHitEvent : ScriptableObject
{
    private List<GameOnHitEventListener> listeners = new List<GameOnHitEventListener>();

    public void Raise(OnHitData data)
    {
   
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(data);
        }
    }

    public void RegisterListener(GameOnHitEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnRegisterListener(GameOnHitEventListener listener)
    {
        listeners.Remove(listener);

    }
}
