using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public void Spawn()
    {
        //moves it to spawnpoint
        GameObject spawnpoint = GameObject.FindGameObjectWithTag("BossSpawnPoint");
        this.GetComponent<Rigidbody2D>().MovePosition(spawnpoint.transform.position);
        //play some sort of spawn effect
    }
}
