using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private NavMeshSurface _navMeshSurface;

    private void Start()
    {
        StartCoroutine(GenerateSomeEnemy());
    }

    IEnumerator GenerateSomeEnemy()
    {
        foreach (var enemy in enemies)
        {
            enemy.SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }
        _navMeshSurface.BuildNavMesh();
    }
}
