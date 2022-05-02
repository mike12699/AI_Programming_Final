using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public sealed class GOAPAgent : MonoBehaviour
{
    private FSM stateMachine;
    private FSM.FSMState idleState;
    private FSM.FSMState moveToState;
    private FSM.FSMState performActionState;

    private HashSet<GOAPAction> availableActions;
    private Queue<GOAPAction> currentActions;
    private IGOAP dataProvider;
    private GOAPPlanner planner;

    void Start()
    {
        stateMachine = new FSM();
        availableActions = new HashSet<GOAPAction>();
        currentActions = new Queue<GOAPAction>();
        planner = new GOAPPlanner();
    }


    void Update()
    {
        
    }
}
