using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    [SerializeField] private GameObject FlyingBonePrefab;
    [SerializeField] private GameObject FishPrefab;
    [SerializeField] private Vector2 SpawnPoint = new Vector2(0f, 0f);
    public int StopSpawning = 0;

    private void Start()
    {
        Invoke("SpawnFlyingBone", 3f);
        Invoke("SpawnFish", Random.Range(5f, 10f));
    }

    private void Update()
    {

    }

    private void SpawnFlyingBone()
    {
        if (StopSpawning == 0)
        {
            SpawnPoint = new Vector2((Random.Range(0f, 1f) > 0.5f) ? Random.Range(-12f, -11f) : Random.Range(11f, 12f), Random.Range(-7f, 18f));
            GameObject flyingBone = Instantiate(FlyingBonePrefab, SpawnPoint, Quaternion.identity);
            Invoke("SpawnFlyingBone", Random.Range(0f, 1f));
        }
    }

   private void SpawnFish()
    {
        if (StopSpawning == 0)
        {
            SpawnPoint = new Vector2(Random.Range(-9f, 9f), Random.Range(-4f, 15f));
            GameObject fish = Instantiate(FishPrefab, SpawnPoint, Quaternion.identity);
            Invoke("SpawnFish", Random.Range(5f, 10f));
        }
    }
}
