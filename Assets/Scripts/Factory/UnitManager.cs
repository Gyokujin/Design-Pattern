using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] soldiers;
    [SerializeField]
    private GameObject[] flights;

    public List<GameObject> soldierList = new List<GameObject>();
    public List<GameObject> flightList = new List<GameObject>();

    SettingDatas2 settingDatas = new SettingDatas2();

    public void MakeUnit(UnitType unitType)
    {
        GameObject obj = null;

        switch (unitType)
        {
            case UnitType.Soldier:
                {
                    int ran = Random.Range(0, soldiers.Length);
                    obj = Instantiate(soldiers[ran], new Vector3(0, 0.5f, 0), Quaternion.identity);
                    obj.GetComponent<Soldier>().StateUpdate(settingDatas);

                    soldierList.Add(obj);
                }
                break;

            case UnitType.Flight:
                {
                    int ran = Random.Range(0, flights.Length);
                    obj = Instantiate(flights[ran], new Vector3(0, 0.5f, 0), Quaternion.identity);
                    obj.GetComponent<Flight>().StateUpdate(settingDatas);

                    flightList.Add(obj);
                }
                break;
        }
    }

    public void SoldierHit(RaycastHit hit)
    {
        Soldier soldier = hit.collider.gameObject.GetComponent<Soldier>();
        soldier.Hit(1);

        if (soldier.HP <= 0)
        {
            soldierList.Remove(hit.collider.gameObject);
            soldier.UnitDestroy();
        }
    }

    public void FlightHit(RaycastHit hit)
    {
        Flight flight = hit.collider.gameObject.GetComponent<Flight>();
        flight.Hit(1);

        if (flight.HP <= 0)
        {
            flightList.Remove(hit.collider.gameObject);
            flight.UnitDestroy();
        }
    }

    public void SoldierLevelUp()
    {
        foreach (var soldier in soldierList)
        {
            soldier.GetComponent<Soldier>().SumState();
        }

        SoldierDataUpdate(ref settingDatas.soldierLevel, ref settingDatas.soldierHP, ref settingDatas.soldierAttackPower);
    }

    void SoldierDataUpdate(ref int lv, ref float hp, ref float attack)
    {
        lv++;
        hp += 10;
        attack += 1;
    }

    public void FlightLevelUp()
    {
        foreach (var flight in flightList)
        {
            flight.GetComponent<Flight>().SumState();
        }

        FlightDataUpdate(ref settingDatas.flightLevel, ref settingDatas.flightHP, ref settingDatas.flightAttackPower);
    }

    void FlightDataUpdate(ref int lv, ref float hp, ref float attack)
    {
        lv++;
        hp += 20;
        attack += 2;
    }
}