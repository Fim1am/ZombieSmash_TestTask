using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BombPanel : MonoBehaviour
{
    [SerializeField]
    private BombsController bombsController;

    public void Clicked()
    {
        Debug.Log("clicked");

        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, LayerMask.NameToLayer("ground")))
        {
            Debug.Log(hit.collider.name);
            Instantiate(bombsController, hit.point, Quaternion.identity);
        }
    }

}
