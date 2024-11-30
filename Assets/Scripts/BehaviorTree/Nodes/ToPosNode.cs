using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTree
{
    public class ToPosNode : NodeBase
    {
        string _message;
        NavMeshAgent _nav;
        Transform _target;
        public ToPosNode(List<NodeBase> children, Transform Subjek, Transform Target) : base(children)
        {
            _nav = Subjek.GetComponent<NavMeshAgent>();
            _target = Target;
        }

        public ToPosNode(string Target)
        {
            _message = Target;
        }
        public override void Execute()
        {
            Debug.Log(_message);
         }
    }

}
