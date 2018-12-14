using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BombsController : MonoBehaviour
{
    public static event System.Action OnBombExplode;

    private GamePlayManager gamePlayManager;

    [SerializeField]
    private GameObject explosionEffect;

    private Transform aimView, selfTransform;

    private void Start()
    {

        gamePlayManager = FindObjectOfType<GamePlayManager>();
        aimView = transform.GetChild(0);

        selfTransform = transform;

        aimView.localScale = new Vector3(gamePlayManager.gameSettings.bombRadius,
            aimView.localScale.y,
            gamePlayManager.gameSettings.bombRadius);

        if (gamePlayManager.BombsCount < 1)
            Destroy(gameObject);
    }

    private void Update()
    {

        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, LayerMask.NameToLayer("ground")))
        {
            selfTransform.position = hit.point;
        }


        if (Input.GetMouseButtonUp(0))
        {
            if(EventSystem.current.IsPointerOverGameObject())
            {
                Destroy(gameObject);
            }
            else
            {
                BombExplosion(hit.point);
                Destroy(gameObject);
            }
        }
    }

    private void BombExplosion(Vector3 _pos)
    {

        OnBombExplode?.Invoke();

        GameObject effect = Instantiate(explosionEffect, _pos, Quaternion.identity) as GameObject;

        Collider[] hits = Physics.OverlapSphere(_pos, gamePlayManager.gameSettings.bombRadius);

        foreach(Collider c in hits)
        {
            Unit unit = c.GetComponent<Unit>();

            if(unit)
            {
                unit.Kill();
            }
        }

        Destroy(effect, 1.5f);
    }

}
