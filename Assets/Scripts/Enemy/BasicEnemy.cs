using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : EnemyBase
{
    public Transform player;

    protected override NodeBase SetNode()
    {
        return new Condition((Vector3.Distance(transform.position, player.position) <= 3), new List<NodeBase>
        {
            new DoCoverNode()
        },
        new List<NodeBase>
        {
            new ToPlayer(transform,player)
        });

    }

}
