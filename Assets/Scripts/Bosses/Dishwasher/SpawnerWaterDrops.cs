using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWaterDrops : MonoBehaviour
{
    public GameObject fireballPrefab;
    int index;
    public float spawnTime = 0.1f;
    int curPosX;

    void Start()
    {
        spawnFireball();
    }

    private void spawnFireball()
    {
        curPosX = Random.Range(-20, 81);
        GameObject a = Instantiate(fireballPrefab) as GameObject;
        a.transform.position = new Vector2(curPosX, 35);
        StartCoroutine(fireballWaves());
    }

    IEnumerator fireballWaves()
    {
        yield return new WaitForSeconds(spawnTime);
        spawnFireball();
    }
}