using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Attack();
    }

    void Attack()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        if (hit.collider.CompareTag("Player"))
        {
            hit.collider.gameObject.GetComponent<HPControl>().Damage(2);
        }
    }
}