using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Soldier : Unit
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
        level += settingDatas.soldierLevel;
        HP += settingDatas.soldierHP;
        attackPower += settingDatas.soldierAttackPower;
    }

    public override void Hit(float damage)
    {
        HP -= damage * 2;

        Debug.Log($"남은 체력 : {HP}");
    }

    public override void UnitDestroy()
    {
        Destroy(gameObject);
    }

    public override void SumState()
    {
        level++;
        HP += 10;
        attackPower += 1;
    }
}