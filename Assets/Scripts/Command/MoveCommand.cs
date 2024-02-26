using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private Transform characterTransform;
    private Vector3 direction;

    public MoveCommand(Transform transform, Vector3 dir)
    {
        characterTransform = transform;
        direction = dir;
    }

    public override void Execute()
    {
        float speed = PlayerController.instance.moveSpeed;
        characterTransform.Translate(direction * speed * Time.deltaTime);
    }
}