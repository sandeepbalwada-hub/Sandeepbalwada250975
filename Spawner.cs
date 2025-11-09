using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject pickupPrefab;
    public float zSpawn = 30f;
    public float spawnEvery = 1.2f;
    public float cleanupZ = -10f; // destroy when behind camera
    public float laneOffset = 2.5f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnEvery)
        {
            timer = 0f;
            // 60% obstacle, 40% pickup
            bool makeObstacle = Random.value < 0.6f;
            int lane = Random.Range(0, 3);
            float x = (lane - 1) * laneOffset;

            GameObject prefab = makeObstacle ? obstaclePrefab : pickupPrefab;
            var go = Instantiate(prefab, new Vector3(x, 0.5f, zSpawn), Quaternion.identity);

            // make it move back (world moves) – simple approach:
            go.AddComponent<MoveBack>();
        }
    }
}

public class MoveBack : MonoBehaviour
{
    public float speed = 8f;
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z < -10f) Destroy(gameObject);
    }
}
