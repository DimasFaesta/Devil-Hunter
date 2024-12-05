using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

public class NetManager : NetworkManager
{
    private PackageHandler PackageHandler = new PackageHandler();

    [Header("Callback")]
    public UnityEvent OnServerStart, OnServerStop;
    public UnityEvent OnStartAsClient, OnStopAsClient;
    public UnityEvent<PlayerStats> OnNewClientConnect, OnClientLeave;
    public UnityEvent OnConnectToServer;


    #region From client Callback

    public void OnDataClientReceive(NetworkConnectionToClient conn,PlayerStats stats)
    {
        stats.Id = conn.connectionId;
        OnNewClientConnect?.Invoke(stats);
    }

    #endregion

    // ----------------------------------------------------
    #region In Server Callback Mirror
    
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        var stat = new PlayerStats()
        {
            Id = conn.connectionId
        };
        
        OnClientLeave?.Invoke(stat);
    }

    public override void OnStartServer()
    {
        OnServerStart.Invoke();
        PackageHandler.RegisterPackageServer();
        PackageHandler.OnNewClientConnect.AddListener(((arg0, stats) => OnNewClientConnect?.Invoke(stats)));
    }

    #endregion

   //---------------------------------------------- 
    
    #region In Client Callback Mirror

    public override void OnClientConnect()
    {
        if (!NetworkClient.ready)
            NetworkClient.Ready();
        
        NetworkClient.Send(new PlayerStats()
        {
            Id = -1,
            Nama = "fulan"
        });
        
        OnConnectToServer.Invoke();
    }

    public override void OnStartClient()
    {
        OnStartAsClient?.Invoke();
    }

    #endregion
    
}
