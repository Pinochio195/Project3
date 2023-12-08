using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(BotController botController, FiniteStateMachine stateMachine) : base(botController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        CheckRotatePlayer(botController._botController._transformAttack);
        botController._botController._animator.SetInteger(Settings.Animation_Player, 2);
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
    }
    private void CheckRotatePlayer(Transform other)
    {
        if (!botController._botController._checkPlayer.isCheckDetectionObjectBotController)
        {
            RotatePlayer(other);
            botController._botController._checkPlayer.isCheckDetectionObjectBotController = true;
            botController._botController._animator.SetInteger(Settings.Animation_Player, 2);
        }
    }

    private void RotatePlayer(Transform other)
    {
        Vector3 direction = (other.position - botController._botController._meshBot.transform.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        float currentRotationX = botController._botController._meshBot.transform.rotation.eulerAngles.x;
        toRotation = Quaternion.Euler(currentRotationX, toRotation.eulerAngles.y, toRotation.eulerAngles.z);
        botController._botController._meshBot.transform.rotation = toRotation;
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}