using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject stateWindow;
    [SerializeField]
    private Text textLV;
    [SerializeField]
    private Text textName;
    [SerializeField]
    private Text textHP;
    [SerializeField]
    private Text textAttackPower;

    UnitManager unitManager;

    void Start()
    {
        Init();
    }

    void Init()
    {
        stateWindow.SetActive(false);
        unitManager = GetComponent<UnitManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InfoUnitState();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            HitUnit();
        }
    }

    void InfoUnitState()
    {
        RaycastHit hit;
        Physics.Raycast(ClickPosition(), out hit);

        if (hit.collider.CompareTag("Soldier"))
        {
            ShowStateInUI(hit.collider.gameObject.GetComponent<Soldier>().InforUnitState());
        }
        else if (hit.collider.CompareTag("Flight"))
        {
            ShowStateInUI(hit.collider.gameObject.GetComponent<Flight>().InforUnitState());
        }
    }

    void ShowStateInUI(string[] state)
    {
        textName.text = $"Name : {state[0]}";
        textLV.text = $"LV : {state[1]}";
        textHP.text = $"HP : {state[2]}";
        textAttackPower.text = $"Attack : {state[3]}";

        stateWindow.SetActive(true);
    }

    public void UnitSpawnButton(int type)
    {
        switch (type)
        {
            case 0:
                {
                    unitManager.MakeUnit(UnitType.Soldier);
                }
                break;
            case 1:
                {
                    unitManager.MakeUnit(UnitType.Flight);
                }
                break;
        }
    }

    void HitUnit()
    {
        RaycastHit hit;
        Physics.Raycast(ClickPosition(), out hit);

        if (hit.collider.gameObject.CompareTag("Soldier"))
        {
            unitManager.SoldierHit(hit);
        }
        else if (hit.collider.gameObject.CompareTag("Flight"))
        {
            unitManager.FlightHit(hit);
        }
    }

    Ray ClickPosition()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition); ;
    }

    public void SoldierLevelUpButton()
    {
        unitManager.SoldierLevelUp();
    }

    public void FlightLevelUpButton()
    {
        unitManager.FlightLevelUp();
    }
}