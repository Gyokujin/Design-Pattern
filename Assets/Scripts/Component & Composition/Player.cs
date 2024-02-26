using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MoveControl moveControl;

    void Start()
    {
        moveControl = GetComponent<MoveControl>();
    }

    void Update()
    {
        moveControl.CharMove();
    }
}