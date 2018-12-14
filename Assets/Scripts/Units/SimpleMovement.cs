using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : Movement
{
    private Transform selfTransform;

    private void Start()
    {
        selfTransform = transform;
	}

    public override void Move()
    {
        selfTransform.position += selfTransform.forward * Unit.Speed * Time.fixedDeltaTime;
    }
}
