using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPControl : MonoBehaviour
{
    [SerializeField]
    private int maxHP = 100;
    [SerializeField]
    private Slider HPSlider;
    private int HP = 0;

    void Start()
    {
        HP = maxHP;
        HPSlider.value = (float)HP / (float)maxHP;
    }

    public void Damage(int amount)
    {
        HP -= amount;

        HPSlider.value = (float)HP / (float)maxHP;

        if (HP <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("»ç¸Á");
    }
}