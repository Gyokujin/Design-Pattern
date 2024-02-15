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

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InfoUnitState();
        }
    }

    void Init()
    {
        stateWindow.SetActive(false);
    }

    void InfoUnitState()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hit);

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
}