using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour, IPowerUp
{
    public void GetPower(GerakanTPS p)
    {
        p._dataKarakter.kecepatan += 2;
        gameObject.SetActive(false);
    }
}
