using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private enum State
    {
        Idle, //before activation
        Active, //after activation
        BattleOver, //after wave has been killed
    }

    [SerializeField] private ColliderTrigger[] triggers;
    [SerializeField] private Wave[] waves;
    public event EventHandler BattleOver;

    private void Awake()
    {
        //default state to idle for each wave
        foreach (Wave wave in waves)
        {
            wave.state = State.Idle;
        }
    }

    private void Start()
    {
        //checks for event
        foreach (ColliderTrigger trigger in triggers)
        {
            trigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
        }
    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        //turn sender into ColliderTrigger
        ColliderTrigger trig = (ColliderTrigger)sender;
        if (waves[trig.getWaveNumber()].state == State.Idle) //is wave activated already
        {
            //when event happens, starts battle
            startBattle(trig.getWaveNumber());
            trig.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
        }
    }

    private void startBattle(int i)
    {
        Debug.Log("Start Battle");
        waves[i].state = State.Active;

        waves[i].spawnEnemies(); //spawns first wave
    }

    private void Update()
    {
        TestBattleOver();
    }

    private void TestBattleOver()
    {
        bool allWavesOver = false;
        foreach (Wave wave in waves)
        {
            if (wave.isWaveOver())
            {
                //wave is over
            } else
            {
                allWavesOver = false;
                break;
            }
            allWavesOver = true;
        }

        //battle over
        if (allWavesOver)
        {
            Debug.Log("Battle over");

            //change all states
            foreach (Wave wave in waves)
            {
                wave.state = State.BattleOver;
            }

            //alerts other scripts that battle is over (use in boss battle)
            BattleOver?.Invoke(this, EventArgs.Empty);

            //destroy all enemies permenantly to prep for boss battle
            foreach (Wave wave in waves)
            {
                wave.DestroyWave();
            }

            //destroy battle system in order to reload it next time
            Destroy(gameObject);
        }
    }

    public void resetStates()
    {
        //make each state idle again
        foreach (Wave wave in waves)
        {
            wave.state = State.Idle;
        }
    }

    /* 
     Represents 1 enemy wave
     */
    [Serializable]
    private class Wave
    {
        public State state;
        [SerializeField] private EnemySpawn[] enemySpawns;

        public void spawnEnemies()
        {
            foreach (EnemySpawn enemy in enemySpawns)
            {
                enemy.Spawn();
            }
        }

        public bool isWaveOver()
        {
            if(state == State.Active) //check if spawned yet
            {
                //wave has been spawned
                foreach (EnemySpawn enemy in enemySpawns) //checks all enemies to see if alive
                {
                    if (enemy.isAlive())
                    {
                        return false;
                    }
                }
                return true;
            } else
            {
                return false; //enemies have not spawned
            }
        }

        public void DestroyWave()
        {
            foreach (EnemySpawn enemy in enemySpawns)
            {
                enemy.Destroy();
            }
            Debug.Log("Enemies Destroyed");
        }
    }
}
