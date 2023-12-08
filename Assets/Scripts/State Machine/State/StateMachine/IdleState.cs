using System.Collections;
using UnityEngine;

public class IdleState : State
{
    private float TimeDelay;

    public IdleState(BotController botController, FiniteStateMachine stateMachine) : base(botController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        botController._botController._animator.SetInteger(Settings.Animation_Player, 0);
        TimeDelay = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (botController._botController._isCheckDieEnemy)
        {
            stateMachine.ChangeState(botController.dieState);
        }
        else
        {
            if (botController._botController._transformAttack != null)
            {
                //stateMachine.ChangeState(botController.attackState);
            }
            else
            {
                if (TimeDelay > 5)
                {
                    stateMachine.ChangeState(botController.runState);
                }
                else
                {
                    TimeDelay += Time.deltaTime;
                }
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    
   
}