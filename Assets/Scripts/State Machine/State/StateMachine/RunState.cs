
using TMPro;
using UnityEngine;

public class RunState : State
{
    Transform targetPosition;
    public RunState(BotController botController, FiniteStateMachine stateMachine) : base(botController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        targetPosition = GameManager.Instance._gameController._listPositionMove[Random.Range(0, GameManager.Instance._gameController._listPositionMove.Count - 1)];
        botController._botController._animator.SetInteger(Settings.Animation_Player, 1);
        //TargetEnemy();
        botController._botController._navMeshAgent.SetDestination(targetPosition.position);
    }

    public override void Exit()
    {
        base.Exit();
        targetPosition = null;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (botController._botController._isCheckDieEnemy)
        {
            stateMachine.ChangeState(botController.dieState);
            botController._botController._navMeshAgent.isStopped = true;
        }
        if (botController._botController._navMeshAgent.remainingDistance <= botController._botController._navMeshAgent.stoppingDistance)
        {
            stateMachine.ChangeState(botController.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
   
}

