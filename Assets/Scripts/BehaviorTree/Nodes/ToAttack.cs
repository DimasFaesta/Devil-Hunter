using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.AI;

public class ToAttack : NodeBase
{
    Transform target;
    public ToAttack(Transform Player, List<NodeBase> children) : base(children)
    {
        this.children = children;
    }

    public ToAttack( Transform Player)
    {
        target = Player;
    }
    public override void Execute()
    {
        Debug.Log("Attacking..");
        target.GetComponent<NewBehaviourScript>().target.GetComponent<GerakanTPS>()._dataKarakter.Health -= 2;
    }
}
