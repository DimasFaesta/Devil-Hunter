using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class NodeBase
    {
       protected List<NodeBase> children=new List<NodeBase>();
        public NodeBase(List<NodeBase> childs)
        {
            children = childs;
            foreach (IAiNode child in children)
            {
                child.InitializeAi();
                Debug.Log("jalan");
            }
        }
        public NodeBase() { }
        public abstract void Execute();

        public void NextNode()
        {

            for (int i = 0; i < children.Count; i++)
            {
                children[i].Execute();
            }
        }
    }
}
