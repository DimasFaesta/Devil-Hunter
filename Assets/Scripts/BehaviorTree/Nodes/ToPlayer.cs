using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTree
{
    public class ToPlayer : NodeBase
    {
        NavMeshAgent _agent;
        Transform _target;

        EnemyBase _enemy;


        public ToPlayer(Transform Subjek, Transform Player, List<NodeBase> children) : base(children)
        {
            this.children=children;
            _agent = Subjek.GetComponent<NavMeshAgent>();
            _target = Player;
            _enemy = Subjek.GetComponent<EnemyBase>();

        }

        public ToPlayer(Transform Subjek, Transform Player)
        {
            _agent = Subjek.GetComponent<NavMeshAgent>();
            _target = Player;
            _enemy = Subjek.GetComponent<EnemyBase>();

        }
        public override void Execute()
        {
            _agent.SetDestination(_target.position);
            _enemy.state = EnemyState.Kejar;
            _agent.isStopped = false;

        }
    }
}

