using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CommandInput
{
    public UnitPrefabsScriptableObject unitPrefabs = null;

    public GameObject BuildUnit(Building building, UnitType type)
    {
        var spawnLocation = building.spawnLocation;
        var faction = (int)building.faction;
        Debug.Assert(faction == 0 || faction == 1);
        var prefab = (faction == 0 ? unitPrefabs.brightUnitPrefabs : unitPrefabs.darkUnitPrefabs)[(int)type];
        return GameObject.Instantiate(prefab, spawnLocation);
    }

    public void MoveUnit(GameObject unit, Vector3 targetPosition)
    {
        var agent = unit.GetComponentInChildren<NavMeshAgent>();
        Debug.Assert(agent != null);
        agent.SetDestination(targetPosition);
    }

    public void Attack(GameObject attacker, GameObject target)
    {
        // todo
    }
}
