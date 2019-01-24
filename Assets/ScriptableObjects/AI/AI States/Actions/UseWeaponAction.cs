using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Use Weapon")]
public class UseWeaponAction : Action
{
    public override void Enter(AIStateController stateController)
    {
        stateController.combatActionDelay = stateController.aiStats.combatDelay;
    }
    
    public override void Execute(AIStateController stateController)
    {
        WeaponController weaponController = stateController.weaponController;
        if (stateController.combatActionDelay <= 0.0f)
        {
            weaponController.Use();
        }
    }
}