using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private BattleSystem battleSystem;
    [SerializeField] private int currentLevel;
    [SerializeField] private int currentMapNumber;
    private GameObject currentMap;
    [SerializeField] private GameObject[] maps;
    [SerializeField] private GameObject[] enemySpawns;
    [SerializeField] private GameObject currentEnemySpawns;

    [SerializeField] private GameObject[] bosses;

    [SerializeField] private AstarPath pathfinder;

    [SerializeField] private float enemyDamage;
    [SerializeField] private float enemyHealth;

    [SerializeField] private AudioSource mainMusic;

    [SerializeField] private Text bossName;

    [SerializeField] private GameObject bossHealthBar;

    private UnlockableBreads uB;

    private GameObject bossSpawnPoint;

    void Start()
    {
        currentLevel = 1;
        enemyDamage = 2;
        enemyHealth = 1;

        uB = FindObjectOfType<UnlockableBreads>();

        //load random map
        currentMapNumber = Random.Range(0, maps.Length);
        mapLoad(currentMapNumber);

        //find battlesystem
        battleSystem = FindObjectOfType<BattleSystem>();

        //sets up trigger in BattleSystem to spawn boss
        battleSystem.BattleOver += BattleSystem_BattleOver;

        //disable bosshealthbar
        bossHealthBar.SetActive(false);
    }

    //loads specified map
    private void mapLoad(int i)
    {
        currentMap = Instantiate(maps[i], new Vector3(0, 0, 0), Quaternion.identity);
        //gets the current enemy spawning empty object
        currentEnemySpawns = GameObject.FindGameObjectWithTag("Enemies");
        //scans the map for enemyMovement
        pathfinder.Scan();
    }

    private void BattleSystem_BattleOver(object sender, System.EventArgs e)
    {
        Debug.Log("Enemies Defeated");
        //destroys enemies + battlesystem
        Destroy(currentEnemySpawns);
        //randomizes bosses and spawns one
        int chooseBoss = Random.Range(0, bosses.Length);
        GameObject boss = bosses[chooseBoss];
        bossSpawnPoint = GameObject.Find("BossSpawnPoint");
        Instantiate(boss, bossSpawnPoint.transform.position, Quaternion.identity);
        //sets up health bar
        bossHealthBar.SetActive(true);
        bossName.text = boss.name;
        //sets up trigger in NormalBossHealth to spawn new enemies after boss is defeated
        FindObjectOfType<NormalBossHealth>().BossBattleOver += NormalBossHealth_BossBattleOver;
        mainMusic.Pause();
    }

    private void NormalBossHealth_BossBattleOver(object sender, System.EventArgs e)
    {
        Debug.Log("boss defeated");
        mainMusic.Play();
        uB.SomethingUnlocked(bossName.text);
        //add level
        currentLevel++;
        //increase enemy stats
        enemyDamage += 0.75f;
        enemyHealth += 0.25f;
        //check off that player has killed this boss
        //reset enemies
        respawnEnemies(currentMapNumber);
        //get rid of healthbar
        bossHealthBar.SetActive(false);
    }

    //respawns all enemies
    private void respawnEnemies(int i)
    {
        Debug.Log("Enemies respawned");
        Instantiate(enemySpawns[i]);
        //find battlesystem
        battleSystem = FindObjectOfType<BattleSystem>();
        //sets up trigger in BattleSystem to spawn boss
        battleSystem.BattleOver += BattleSystem_BattleOver;
    }

    //these two methods are for the enemies to call when they start up
    public float getEnemyDamage()
    {
        return enemyDamage;
    }

    public float getEnemyHealth()
    {
        return enemyHealth;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}
