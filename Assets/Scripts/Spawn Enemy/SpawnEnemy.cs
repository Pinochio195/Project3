using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject prefabsEnemy;
    [SerializeField] private List<Transform> listTransformSpawnEnemy;
    private void Awake()
    {
        for(int i = 0;i< 7;i++)
        {
            Transform enemy = LeanPool.Spawn(prefabsEnemy, listTransformSpawnEnemy[Random.Range(0, listTransformSpawnEnemy.Count)].position, Quaternion.identity).transform;
            GameManager.Instance.GetBotControllerAddList(enemy);
            listTransformSpawnEnemy.RemoveAt(listTransformSpawnEnemy.Count - 1);
        }
    }
}
