using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Tree : MonoBehaviour
    {
        private NodeBase _root;

        void Start()
        {
            _root = SetupNode();
            var initai = _root as IAiNode;
            if (initai != null)
            {
                initai.InitializeAi();
            }
        }

        // Update is called once per frame
        void Update()
        {
            _root.Execute();
            _root.NextNode();
        }

        public abstract NodeBase SetupNode();
    }
}

