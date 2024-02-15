using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Health Hp = new Health();
    private HealthManager healthManager;
    private SettingDatas settingDatas = new SettingDatas();

    private float currentHP;
    private float maxHP;
    [SerializeField]
    private float sumHP;

    void Start()
    {
        PlayerInit();
    }

    void PlayerInit()
    {
        maxHP = settingDatas.enemyMaxHP + sumHP;
        currentHP = maxHP;

        healthManager = GetComponent<HealthManager>();

        Hp.RegisterObserver(healthManager);

        Hp.ModifyHealth(currentHP, maxHP);
    }

    public void HPButton()
    {
        currentHP--;
        Debug.Log($"enemyHP = {currentHP}");
        Hp.ModifyHealth(currentHP, maxHP);
    }
}