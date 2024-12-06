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

    public static bool IsServer;

    #region From client Callback

    public void OnDataClientReceive(NetworkConnectionToClient conn,PlayerStats stats)
    {
        stats.data.id = conn.connectionId;
        OnNewClientConnect?.Invoke(stats);
        
    }

    #endregion

    // ----------------------------------------------------
    #region In Server Callback Mirror
    
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        var stat = new PlayerStats()
        {
           data = new DataKarakter()
           {
               id = conn.connectionId,
           }
        };
        
        OnClientLeave?.Invoke(stat);
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        OnServerStart.Invoke();
        PackageHandler.RegisterPackageServer();
        PackageHandler.OnNewClientConnect.AddListener(((arg0, stats) => OnNewClientConnect?.Invoke(stats)));
        IsServer=true;
    }

    #endregion

   //---------------------------------------------- 
    
    #region In Client Callback Mirror

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        
        NetworkClient.Send(new PlayerStats()
        {
            data = new DataKarakter()
            {
                Nama ="flan",
                id = -1
            }
        });
        
        OnConnectToServer.Invoke();
    }

    public override void OnStartClient()
    {
        OnStartAsClient?.Invoke();
    }

    #endregion

    private void OnDestroy()
    {
        StopClient();
    }

}
