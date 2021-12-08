using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEventManager : MonoBehaviour
{
    UIBossHealthBar bossHealthBar;
    EnemyBossManager bossManager;

    public bool bossFightIsActive; // Is fighting boss?

    public bool bossHasBeenAwakend; // if boss is woken up

    public bool bossDefeated; // boss has been defeated

    private void Awake()
    {
        bossHealthBar = FindObjectOfType<UIBossHealthBar>();
    }

    public void ActiveateBossFight()
    {
        bossFightIsActive = true;
        bossHasBeenAwakend = true;
        bossHealthBar.SetUiHealthBarToActive();
        //Activate fog walls
    }

    public void bossHasBeenDefeated()
    {
        bossDefeated = true;
        bossFightIsActive = false;
        //DEACTIVATE FOG WALLS
    }
}
