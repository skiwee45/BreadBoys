using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossesKilledText : MonoBehaviour
{
    private Text bossesKilled;

    void Start()
    {
        bossesKilled = GetComponent<Text>();
    }

    public void RenderText(int bossesDefeated)
    {
        if (bossesDefeated == 0)
        {
            bossesKilled.text = "You've defeated no bosses! Try again and see if you can unlock a new bread!";
        }
        else if (bossesDefeated == 1)
        {
            bossesKilled.text = "You've defeated " + bossesDefeated + " boss!" + " Check the bread select menu to see if you've unlocked a new bread!";
        }
        else if (bossesDefeated > 1)
        {
            bossesKilled.text = "You've defeated " + bossesDefeated + " bosses!" + " Check the bread select menu to see if you've unlocked a new bread!";
        }
    }
}
