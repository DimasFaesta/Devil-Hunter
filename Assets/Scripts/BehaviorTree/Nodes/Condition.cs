using BehaviorTree;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : NodeBase
{
    private bool condition;
    public Condition(bool condition, List<NodeBase> truecon, List<NodeBase> falsecon) : base((condition) ? truecon : falsecon)
    {
        this.condition = condition;
    }

    public override void Execute()
    {
        Debug.Log(condition);
    }
}
