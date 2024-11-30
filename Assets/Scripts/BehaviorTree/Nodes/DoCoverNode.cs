using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class DoCoverNode : NodeBase
    {
        public override void Execute()
        {
            Debug.Log("Covering..");
        }
    }
}
