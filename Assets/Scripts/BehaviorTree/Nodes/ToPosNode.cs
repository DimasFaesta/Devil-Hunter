using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
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
        string ouputname;

        public ToPosNode(List<NodeBase> children, Transform Subjek, Transform Target) : base(children)
        {
            _target = Target;
        }

        public ToPosNode():base() { }

        public void InitializeAi()
        {
            // runtimeModel = ModelLoader.Load(Resources.Load<NNModel>("AitoPos"));
            // worker = WorkerFactory.CreateWorker(WorkerFactory.Type.Auto, runtimeModel);
            // ouputname = runtimeModel.outputs[runtimeModel.outputs.Count - 1];
            //
            // foreach(var input in runtimeModel.inputs)
            // {
            //     Debug.Log(input.name);
            //     foreach(var angka in input.shape)
            //     {
            //         Debug.Log(angka);
            //     }
            // }
        }
        public override void Execute()
        {
            // var input = new Dictionary<string, Tensor>();
            // input[runtimeModel.inputs[0].name] = new Tensor(runtimeModel.inputs[0].shape);
            // input[runtimeModel.inputs[1].name] = new Tensor(runtimeModel.inputs[1].shape);
            // worker.Execute(input);
            // Tensor output = worker.PeekOutput(ouputname);
        }
    }

}
