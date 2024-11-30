using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataKarakter", menuName = "ScriptableObjects/DataKarakter", order = 1)]

public class DataKarakter : ScriptableObject
{
    public string Nama;
    public float Health;
    public float kecepatan;
}
