using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class NodeBase
    {
       protected List<NodeBase> children=new List<NodeBase>();
        public NodeBase(List<NodeBase> childs)
        {
            children = childs;

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
