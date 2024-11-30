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
        }

        // Update is called once per frame
        void Update()
        {
            _root.Next();
        }

        public abstract NodeBase SetupNode();
    }
}

