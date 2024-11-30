using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTree
{
    public class DashAttackNode : NodeBase
    {
        Transform _target;
        EnemyBase _enemy;
        NavMeshAgent _agent;

        CharacterController _characterController;
        float _cd;
        bool _candash=true;

        public DashAttackNode(List<NodeBase> children, Transform Subjek, Transform Player, float cd) : base(children)
        {
            _agent = Subjek.GetComponent<NavMeshAgent>();
            _target = Player;
            _enemy = Subjek.GetComponent<EnemyBase>();
            _characterController = Subjek.GetComponent<CharacterController>();
            _cd = cd;
        }

        public DashAttackNode(Transform Subjek, Transform Player, float cd)
        {
            _agent = Subjek.GetComponent<NavMeshAgent>();
            _target = Player;
            _enemy = Subjek.GetComponent<EnemyBase>();
            _characterController=Subjek.GetComponent<CharacterController>();
            _cd = cd;
        }

        public override void Execute()
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance && _agent.remainingDistance != 0 && _candash)
            {
                _agent.SetDestination(_target.forward * 2);

                _enemy.state = EnemyState.Serang;
                _agent.isStopped = true;

                float kecepatan = 20;

                DOTween.To(() => kecepatan, x => kecepatan = x, 0, 1).OnUpdate(() =>
                {
                    _characterController.Move(_enemy.transform.forward * kecepatan*Time.deltaTime);
                    _enemy.state=EnemyState.Serang;
                    _candash=false;
                }).OnComplete(() =>
                {
                    _enemy.state = EnemyState.Siaga;
                    _agent.isStopped = false;
                    float durasi = _cd;
                    DOTween.To(() => _cd, x => _cd = x, 0, durasi).OnComplete(() =>
                    {
                        _cd = durasi;
                        _candash=true;
                    });
                });

            }

        }
    }
}


