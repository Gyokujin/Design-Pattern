using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : Unit
{
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

    public override void Hit(float damage)
    {
        HP -= damage;

        Debug.Log($"비행기 남은 체력 : {HP}");
    }

    public override void UnitDestroy()
    {
        Destroy(gameObject);
    }

    public override void SumState()
    {
        level++;
        HP += 20;
        attackPower += 2;
    }
}