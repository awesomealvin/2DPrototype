using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityIntEvent : UnityEvent<int>
{

}
public class GameIntEventListener : MonoBehaviour
{
    public GameIntEvent gameEvent;
    public UnityIntEvent response;

    void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    void OnDisable()
    {
        gameEvent.UnRegisterListener(this);
    }

    public void OnEventRaised(int value)
    {
        response.Invoke(value);
    }
}