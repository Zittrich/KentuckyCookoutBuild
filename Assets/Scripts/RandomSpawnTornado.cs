using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnTornado : MonoBehaviour
{
    public GameObject TornadoPrefab;
    public float SpawnBounds;
    public float SpawntimeMin;
    public float SpawntimeMax;
    public float lifetimeTornado = 8;

    private float timer;
    private float spawntime;
    private int count = 0;
    private float timerTornado;
    private GameObject Tornado;

    // Start is called before the first frame update
    void Start()
    {
        spawntime = Random.Range(SpawntimeMin, SpawntimeMax);
    }

    private void FixedUpdate()
    {
        switch (count)
        {
            case 0:
                timer += Time.deltaTime;
                if (timer >= spawntime)
                {
                    SpawnTornado();
                    timer = 0;
                    count = 1;
                }
                break;
            case 1:
                timerTornado += Time.deltaTime;
                if (timerTornado >= lifetimeTornado)
                {
                    Destroy(Tornado);
                    timerTornado = 0;
                    count = 0;
                }
                break;
        }

    }

    public void SpawnTornado()
    {
        Vector3 SpawnPosition = new Vector3((Random.value - 0.5f) * SpawnBounds * 2 - 4, 0, (Random.value - 0.5f) * SpawnBounds * 2);
        Tornado = Instantiate(TornadoPrefab, SpawnPosition, Quaternion.identity);
    }
}
