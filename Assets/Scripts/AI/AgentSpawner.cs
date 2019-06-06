using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float spawnRate = 1f;
    public float radius = 25f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(spawnPrefab));
    }
   
    public IEnumerator Spawn(GameObject prefab)
    {
        Vector3 point = transform.position + GetRandomPointOnTerrain();

        Instantiate(prefab, point, Quaternion.identity);

        yield return new WaitForSeconds(1f / spawnRate);

        StartCoroutine(Spawn(spawnPrefab));
    }

    public Vector3 GetRandomPointOnTerrain()
    {
        Vector3 randomPoint = Random.insideUnitSphere * radius;
        randomPoint.y = Terrain.activeTerrain.SampleHeight(randomPoint);
        return randomPoint;
    }
}
