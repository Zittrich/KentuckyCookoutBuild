using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSpawnScript : MonoBehaviour
{
    public GameObject TornadoPrefab;
    public float SpawnBounds;

    
    public void SpawnTornado()
    {
        Vector3 SpawnPosition = new Vector3((Random.value - 0.5f) * SpawnBounds * 2, 0, (Random.value - 0.5f) * SpawnBounds * 2);
        GameObject Tornado = Instantiate(TornadoPrefab, SpawnPosition, Quaternion.identity);
    }
}
