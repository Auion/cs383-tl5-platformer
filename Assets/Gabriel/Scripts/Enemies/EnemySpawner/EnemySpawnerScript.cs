using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    [SerializeField] private GameObject FlyingBonePrefab;
    [SerializeField] private Vector2 SpawnPoint = new Vector2(0f, 0f);
    public int StopSpawning = 0;

    private void Start()
    {
        Invoke("SpawnFlyingBone", 1f);
    }

    private void Update()
    {

    }

    private void SpawnFlyingBone()
    {
        if (StopSpawning == 0)
        {
            SpawnPoint = new Vector2((Random.Range(0f, 1f) > 0.5f) ? Random.Range(-12f, -11f) : Random.Range(11f, 12f), Random.Range(-7f, 18f));
            GameObject asteroidInstance = Instantiate(FlyingBonePrefab, SpawnPoint, Quaternion.identity);
            Invoke("SpawnFlyingBone", Random.Range(0f, 0.5f));
        }
    }
}
