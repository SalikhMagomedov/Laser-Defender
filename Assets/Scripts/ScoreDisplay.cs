using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private GameSession gameSession;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        scoreText.text = gameSession.Score.ToString();
    }
}
