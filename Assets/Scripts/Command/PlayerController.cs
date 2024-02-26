using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed = 3f;

    private CommandInvoker commandInvoker = new CommandInvoker();

    private Dictionary<string, KeyCode> moveKeys = new Dictionary<string, KeyCode>
    {
        { "Forward", KeyCode.W },
        { "Back", KeyCode.S },
        { "Left", KeyCode.A },
        { "Right", KeyCode.D },
    };

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveDirection = Vector3.zero;

        foreach (var pair in moveKeys)
        {
            if (Input.GetKey(pair.Value))
            {
                switch (pair.Key)
                {
                    case "Forward":
                        moveDirection += Vector3.forward;
                        break;

                    case "Back":
                        moveDirection += Vector3.back;
                        break;

                    case "Left":
                        moveDirection += Vector3.left;
                        break;

                    case "Right":
                        moveDirection += Vector3.right;
                        break;
                }
            }
        }

        Command moveCommand = new MoveCommand(transform, moveDirection);
        commandInvoker.SetCommand(moveCommand);
        commandInvoker.ExecuteCommand();
    }
}