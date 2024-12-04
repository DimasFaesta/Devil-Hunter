using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweupManager : MonoBehaviour
{
    public DataKarakter dataKarakter;

    public List<GameObject> powerUps;
    public float durasi;

  
    IEnumerator start()
    {
        yield return new WaitForSeconds(durasi);
        powerUps[Random.Range(0, 2)].SetActive(true);
    }
}
