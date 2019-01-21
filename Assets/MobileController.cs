using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    public ActivePlayer currentActivePlayer;


    public void Dash()
    {
        currentActivePlayer.currentPlayer.abilityController.UseAbility();
    }

    public void Attack()
    {
        currentActivePlayer.currentPlayer.weaponController.Use();
    }
}
