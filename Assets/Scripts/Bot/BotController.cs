using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ring;

public class BotController : MonoBehaviour
{
    [HeaderTextColor(0.2f, .7f, .8f, headerText = "Player Component")] public BotManager _botController;
    public IdleState idleState;
    public RunState runState;
    public DieState dieState;
    public AttackState attackState;
    private FiniteStateMachine stateMachine;
    void Start()
    {
        Intil();
        StateMachineBot();
    }
    private void StateMachineBot()
    {
        stateMachine = new FiniteStateMachine();
        runState = new RunState(this, stateMachine);
        idleState = new IdleState(this, stateMachine);
        dieState = new DieState(this, stateMachine);
        attackState = new AttackState(this, stateMachine);
        stateMachine.Initialize(idleState);
    }
    private void Intil()
    {
        _botController._ShortMaterialBot.mainTexture = _botController._ShortSpritesRandom[Random.Range(0, _botController._ShortSpritesRandom.Count)];
        _botController._BodySkinnedMeshRendererBot.material = _botController._ShortMaterialsRandom[Random.Range(0, _botController._ShortMaterialsRandom.Count)];
        _botController._listAccessory[Random.Range(0, _botController._listAccessory.Count)].SetActive(true);
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
}
