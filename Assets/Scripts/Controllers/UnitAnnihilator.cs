using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnnihilator : MonoBehaviour
{
    public static event System.Action OnZombiePassed;

    private void OnTriggerEnter(Collider _col)
    {
        Unit unit = _col.GetComponent<Unit>();

        //Debug.Log(unit.name);

        if(unit != null)
        {
            Zombie zombie = unit.gameObject.GetComponent<Zombie>();

            if(zombie != null)
            {
                OnZombiePassed?.Invoke();
            }

            Destroy(unit.gameObject);

        }
    }
}
