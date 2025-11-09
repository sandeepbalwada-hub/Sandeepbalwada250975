using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 8f;
    public float laneOffset = 2.5f;   // distance between lanes
    public float laneSwapSpeed = 12f; // how fast we lerp into lane
    int lane = 1; // 0=left, 1=mid, 2=right
    bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        // forward auto move
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // input: A/D lane swap
        if (Input.GetKeyDown(KeyCode.A)) lane = Mathf.Max(0, lane - 1);
        if (Input.GetKeyDown(KeyCode.D)) lane = Mathf.Min(2, lane + 1);

        // smooth move to target lane x
        float targetX = (lane - 1) * laneOffset;
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, targetX, laneSwapSpeed * Time.deltaTime);
        transform.position = pos;
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
