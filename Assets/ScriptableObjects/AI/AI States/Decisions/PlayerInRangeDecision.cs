﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Player In Range")]
public class PlayerInRangeDecision : Decision
{

    public override bool Decide(AIStateController stateController)
    {
        bool returnValue;

        Vector2 position = stateController.transform.position;
        Vector2 playerPosition = stateController.playerPosition.position;

        if (stateController.InRange(position, playerPosition, stateController.aiStats.attackRange))
        {
            returnValue = true;
        }
        else
        {
           returnValue = false;
        }

        return returnValue;
    }

}
