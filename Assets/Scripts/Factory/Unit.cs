using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Soldier, Flight
}

public abstract class Unit : MonoBehaviour
{
    public string unitName;
    public int level;
    public float HP;
    public float attackPower;

    public abstract string[] InforUnitState();
    public abstract void StateUpdate(SettingDatas2 settingDatas);
    public abstract void Hit(float damage);
    public abstract void UnitDestroy();
    public abstract void SumState();
}