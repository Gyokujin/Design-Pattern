using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputMovement))]
public class MoveControl : MonoBehaviour
{
    [SerializeField]
    private float moveSpedd = 5;

    private InputMovement inputMovement;

    void Start()
    {
        inputMovement = GetComponent<InputMovement>();
    }

    public void CharMove()
    {
        Vector3 movement = inputMovement.InputControl();
        transform.position += movement * moveSpedd * Time.deltaTime;
    }
}