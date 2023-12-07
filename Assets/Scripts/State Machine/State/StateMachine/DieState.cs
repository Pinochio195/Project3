
using UnityEngine;

public class DieState : State
{
    public DieState(BotController botController, FiniteStateMachine stateMachine) : base(botController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        botController._botController._animator.SetInteger(Settings.Animation_Player, 3);
        botController._botController._isCheckDieEnemy = false;
        /*botController._botController._collider.enabled = false;
        botController._botController._rigidbody.isKinematic = true;
        botController._botController._listCirlce.SetActive(false);*/
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        /*if (botController._botController._isCheckDieEnemy)
        {
            stateMachine.ChangeState(botController.DieState);
        }*/
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}