using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoMelee : NodeBase
{
    public override void Execute()
    {
        Debug.Log("melee");
    }
}
