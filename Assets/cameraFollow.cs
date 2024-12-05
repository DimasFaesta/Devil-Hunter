using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private Vector3 posawal;
    public Transform player;
    private void Start()
    {
        posawal = transform.position;
    }

    void Update()
    {
        if(player == null)
            return;
        transform.position = posawal + (posawal + player.position);
    }
}
