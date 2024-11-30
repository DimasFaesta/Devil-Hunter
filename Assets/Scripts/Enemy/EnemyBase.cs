using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class EnemyBase : BehaviorTree.Tree
{
    public float Health;
    [HideInInspector]
    public string Jenis;
    [HideInInspector]
    protected NavMeshAgent agent;
    public EnemyState state;
    public MusuhData MusuhData;

    public override NodeBase SetupNode()
    {
       return SetNode();
    }

    protected abstract NodeBase SetNode();

    protected bool CheckRight()
    {
        return Physics.Raycast(transform.position, transform.right, 6);
    }
    protected bool CheckLeft()
    {
        return Physics.Raycast(transform.position, -transform.right, 6);
    }
    protected bool CheckFront()
    {
        return Physics.Raycast(transform.position, transform.forward, 6);
    }
    protected bool CheckBehind()
    {
        return Physics.Raycast(transform.position, -transform.forward, 6);
    }

}
public enum EnemyState
{
    Siaga,
    Kejar,
    Serang,
    Gagipapa
}