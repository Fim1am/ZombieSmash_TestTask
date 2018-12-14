using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    private float rayLenth = 300f;

    private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        RaycastHit hit;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, rayLenth))
            {
                Unit unit = hit.collider.GetComponent<Unit>();

                if (unit != null)
                {
                    unit.Kill();
                }
            }
        }

	}
}
