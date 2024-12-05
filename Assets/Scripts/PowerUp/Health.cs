using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IPowerUp
{
    public void GetPower(GerakanTPS player)
    {
        player._dataKarakter.Health += 10;
        gameObject.SetActive(false);
    }
}
