using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnnihilator : MonoBehaviour
{
    public static event System.Action OnZombiePassed;

    private void OnTriggerEnter(Collider _col)
    {
        Unit unit = _col.GetComponent<Unit>();

        if(unit)
        {
            Zombie zombie = unit.gameObject.GetComponent<Zombie>();

            if(zombie)
            {
                OnZombiePassed?.Invoke();
            }

            Destroy(unit.gameObject);

        }
    }
}
