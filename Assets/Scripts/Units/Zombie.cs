using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Unit
{
    public static System.Action<Vector3> OnZombieKilled;

    public override void Kill()
    {
        base.Kill();
        OnZombieKilled?.Invoke(transform.position);
    }
}
