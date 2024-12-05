using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

public class PackageHandler 
{
    # region Network CallBack

    [HideInInspector]
    public UnityEvent<NetworkConnectionToClient, PlayerStats> OnNewClientConnect =
        new UnityEvent<NetworkConnectionToClient, PlayerStats>();
    
    [Header("Callback message")]
    public UnityEvent<InstructorOrder> OnAssignFromServer;
    public UnityEvent<SendInitializeToClient> OnInitialzeClientFromServer;

    #endregion
    
    public void RegisterPackageServer()
    {
        NetworkServer.RegisterHandler<PlayerStats>((client, stats) => OnNewClientConnect?.Invoke(client, stats));
    }

    public void RegisterPackageClient()
    {
        NetworkClient.RegisterHandler<SendInitializeToClient>(client => OnInitialzeClientFromServer?.Invoke(client));
        NetworkClient.RegisterHandler<InstructorOrder>(order => OnAssignFromServer?.Invoke(order));
    }

    public void SendFromServer<T>(T message, List<int> ReceiverIds) where T : struct, NetworkMessage
    {
        foreach (var receiverId in ReceiverIds)
        {
            foreach (var connections in NetworkServer.connections.Values)
            {
                if (connections.connectionId == receiverId)
                {
                    connections.Send(message);
                }

            }
        }
    }

    public void SendFromServer<T>(T message, int RecieverId) where T : struct, NetworkMessage
    {
        NetworkServer.connections[RecieverId].Send(message);
    }
}

#region Network Message

public struct PlayerStats : NetworkMessage
{
    //public int Id;
    //public int Value;
    //public string Nama;
   public DataKarakter data;
}

public struct InstructorOrder : NetworkMessage
{
    public int Index;
}

public struct SendInitializeToClient : NetworkMessage
{
    public int id;
}


#endregion
