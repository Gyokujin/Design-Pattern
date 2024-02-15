using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Health Hp = new Health();
    private HealthManager healthManager;
    private SettingDatas settingDatas = new SettingDatas();

    private float currentHP;
    private float maxHP;

    void Start()
    {
        PlayerInit();
    }

    void PlayerInit()
    {
        maxHP = settingDatas.playerMaxHP;
        currentHP = maxHP;

        healthManager = GetComponent<HealthManager>();

        Hp.RegisterObserver(healthManager);

        Hp.ModifyHealth(currentHP, maxHP);
    }

    public void HPButton()
    {
        currentHP--;
        Debug.Log($"currentHP = {currentHP}");
        Hp.ModifyHealth(currentHP, maxHP);
    }
}