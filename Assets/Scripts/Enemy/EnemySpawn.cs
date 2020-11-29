using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private bool alive;
    private void Awake()
    {
        gameObject.SetActive(false);
        alive = true;
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        //play some sort of spawn effect
    }

    public void enemyDeath()
    {
        alive = false;
    }

    public bool isAlive()
    {
        return alive;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
