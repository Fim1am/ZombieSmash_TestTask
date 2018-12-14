using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private int citizenSpawnChance = 15;

    [SerializeField]
    private Zombie[] zombies;

    [SerializeField]
    private Citizen citizen;

    private float spawnXOffset = 1f;

    private float minSpawnInterval = 0.75f, maxSpawnInterval = 1.5f, toSpawn;

    private List<Unit> activeUnits;

    private GamePlayManager gamePlay;

    private void OnEnable()
    {
        gamePlay = FindObjectOfType<GamePlayManager>();

        activeUnits = new List<Unit>();
        SpawnUnit();

        GameManager.Instance.OnGameOver += GameoverAct;
    }

    private void GameoverAct()
    {
        DestroyAllUnits();
        gameObject.SetActive(false);
    }

    private void Update ()
    {
        toSpawn -= Time.deltaTime;

        if (toSpawn <= 0)
            SpawnUnit();
	}

    public void DestroyAllUnits()
    {       
        activeUnits.ForEach(u => Destroy(u.gameObject));
        activeUnits.Clear();
    }

    private void SpawnUnit()
    {
        toSpawn = Random.Range(minSpawnInterval, maxSpawnInterval - gamePlay.GetSpawnModifier());

        Unit unitToSpawn;

        if (GameUtilities.GetRandomRoll(citizenSpawnChance))
            unitToSpawn = citizen;
        else
            unitToSpawn = zombies[Random.Range(0, zombies.Length)];

        Unit newUnit = Instantiate(unitToSpawn,
                        new Vector3(Random.Range(-spawnXOffset, spawnXOffset), unitToSpawn.transform.position.y, transform.position.z),
                        Quaternion.identity);

        newUnit.GamePlay = gamePlay;

        newUnit.OnUnitDestroyed += UnitDestroyed;

        activeUnits.Add(newUnit);
    }

    private void UnitDestroyed(Unit _unit)
    {
        activeUnits.Remove(_unit);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= GameoverAct;
    }
}
