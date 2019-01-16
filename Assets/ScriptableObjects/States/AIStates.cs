using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI States Holder")]
public class AIStates : ScriptableObject
{
    public AIState followPlayerState;

    public AIState lookAtState;

    public AIState attackState;

    public AIState outOfAttackRangeState;

    public AIState stationaryState;

}
