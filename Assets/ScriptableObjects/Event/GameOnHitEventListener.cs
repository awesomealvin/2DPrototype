using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityOnHitEvent : UnityEvent<OnHitData>
{

}

public class GameOnHitEventListener : MonoBehaviour
{
    public GameOnHitEvent gameEvent;
    public UnityOnHitEvent response;

    void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    void OnDisable()
    {
        gameEvent.UnRegisterListener(this);
    }

    public void OnEventRaised(OnHitData data)
    {
        response.Invoke(data);
    }
}
