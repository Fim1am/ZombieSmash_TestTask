using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpredictableMovement : Movement
{
    private float sideOffset = 1f;

    private float changeDirInterval = 0.45f, toChange;

    private Vector3 currentDirection;

    private Transform selfTransform;

    private void Start()
    {
        selfTransform = transform;

        SetDirection();
    }

    public override void Move()
    {
        selfTransform.rotation = Quaternion.LookRotation(currentDirection);

        selfTransform.position += currentDirection * Unit.Speed * Time.fixedDeltaTime;

        toChange -= Time.fixedDeltaTime;

        if (toChange <= 0 || Mathf.Abs(selfTransform.position.x) > sideOffset)
            SetDirection();
    }

    private void SetDirection()
    {
        toChange = changeDirInterval;

        float xOffset = selfTransform.position.x <= 0 ? Random.Range(0, sideOffset) : Random.Range(-sideOffset, 0);

        currentDirection = new Vector3(xOffset, 0, 1);
    }
}
