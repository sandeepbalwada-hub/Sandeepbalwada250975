using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    int score = 0;

    public void AddScore(int v)
    {
        score += v;
        scoreText.text = "Score: " + score;
    }

    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
        FindFirstObjectByType<PlayerController>().GameOver();
    }
}


