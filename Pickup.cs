using UnityEngine;

public class Pickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        FindFirstObjectByType<UIManager>().AddScore(1);
        Destroy(gameObject);
    }
}

Obstacle.cs

using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        FindFirstObjectByType<UIManager>().ShowGameOver();
    }
}
