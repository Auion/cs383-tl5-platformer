using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    [SerializeField] private GameObject FlyingBonePrefab;
    [SerializeField] private Vector2 SpawnPoint = new Vector2(0f, 0f);
    public int StopSpawning = 0;

    private void Start()
    {
        SpawnPoint = new Vector2(Random.Range(-6f, 6f), 6f);
        Invoke("SpawnFlyingBone", 1f);
    }

    private void Update()
    {

    }

    private void SpawnFlyingBone()
    {
        if (StopSpawning == 0)
        {
            GameObject asteroidInstance = Instantiate(FlyingBonePrefab, SpawnPoint, Quaternion.identity);
            SpawnPoint = new Vector2(Random.Range(-6f, 6f), 6);
            Invoke("SpawnFlyingBone", Random.Range(0f, 1f));
        }
    }
}
