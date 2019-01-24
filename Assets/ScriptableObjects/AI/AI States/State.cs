using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitions;

    public void EnterState(AIStateController stateController)
    {
        for (int i = 0; i < actions.Length; ++i)
        {
            actions[i].Enter(stateController);
        }
    }

    public void ExecuteState(AIStateController stateController)
    {
        ExecuteActions(stateController);
        CheckTransitions(stateController);
    }

    private void ExecuteActions(AIStateController stateController)
    {
        for (int i = 0; i < actions.Length; ++i)
        {
            actions[i].Execute(stateController);
        }
    }

    private void CheckTransitions(AIStateController stateController)
    {
        for (int i = 0; i < transitions.Length; ++i)
        {
            Transition currentTransition = transitions[i];
            bool decisionPassed = currentTransition.decision.Decide(stateController);

            if (decisionPassed)
            {
                stateController.TransitionToState(currentTransition.trueState);
            }
            else
            {
                stateController.TransitionToState(currentTransition.falseState);
            }
        }
    }
}