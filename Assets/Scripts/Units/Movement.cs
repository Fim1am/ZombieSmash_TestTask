using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [HideInInspector]
    public Unit Unit;

    public abstract void Move();
}
