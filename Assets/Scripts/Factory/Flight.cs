using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : Unit
{
    void Start()
    {
        SettingDatas2 settingDatas = new SettingDatas2();
        StateUpdate(settingDatas);
    }

    public override string[] InforUnitState()
    {
        string[] state = new string[4];

        state[0] = unitName;
        state[1] = level.ToString();
        state[2] = HP.ToString();
        state[3] = attackPower.ToString();
        return state;
    }

    public override void StateUpdate(SettingDatas2 settingDatas)
    {
        level += settingDatas.flightLevel;
        HP += settingDatas.flightHP;
        attackPower += settingDatas.flightAttackPower;
    }
}