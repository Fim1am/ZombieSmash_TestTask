using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : Unit
{
    public override void Kill()
    {
        base.Kill();

        GameManager.Instance.GameOver();
    }
}
