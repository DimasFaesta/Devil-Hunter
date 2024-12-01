using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTree
{
    public class ToPosNode : NodeBase, IAiNode
    {
        NNModel onnmfile;
        Model runtimeModel;
        IWorker worker;

        Transform _target;

        public ToPosNode(List<NodeBase> children, Transform Subjek, Transform Target) : base(children)
        {
            _target = Target;
        }

        public void InitializeAi()
        {
            runtimeModel = ModelLoader.Load(Resources.Load<NNModel>("AitoPos"));
            worker = WorkerFactory.CreateWorker(WorkerFactory.Type.Auto, runtimeModel);
        }
        public override void Execute()
        {
            Tensor input = new Tensor();
        }
    }

}
