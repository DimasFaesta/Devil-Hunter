using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> powerups;
    public GameObject prefabplayer, OtherPlayerPrefab;
    private List<DataKarakter> playerlist;
    public List<DataKarakter> getplayerlist => playerlist;
    void Start()
    {
        StartCoroutine(shufflePowerUp());
    }

    public void OnStartGame()
    {
        Instantiate(prefabplayer);
    }

    IEnumerator shufflePowerUp()
    {
        yield return new WaitForSeconds(3);
        var p = powerups[Random.Range(0, 2)];
        float pos = 35;

        if (p.activeSelf)
        {
            p.SetActive(true);
            p.transform.position = new Vector3(Random.Range(-pos, pos), 3.56f, Random.Range(-pos, pos));
        }

        StartCoroutine(shufflePowerUp());
    }
}
