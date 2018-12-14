using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsPool : MonoBehaviour
{
    private List<GameObject> effects = new List<GameObject>();
	
	void Start ()
    {

        foreach(Transform t in transform)
        {
            effects.Add(t.gameObject);
        }

        Zombie.OnZombieKilled += SpawnEffect;

	}
	
    public void SpawnEffect(Vector3 _pos)
    {
        GameObject effect = effects.Find(e => !e.activeSelf);

        effect.transform.position = _pos;

        effect.SetActive(true);

        StartCoroutine(DisactiveObj(effect));
    }

    private IEnumerator DisactiveObj(GameObject _obj)
    {
        yield return new WaitForSeconds(2f);

        _obj.SetActive(false);
    }

}
