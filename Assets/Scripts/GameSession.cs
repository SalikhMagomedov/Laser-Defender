using UnityEngine;

public class GameSession : MonoBehaviour
{
    private int score = 0;

    private void Awake() => SetUpSingleton();

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int Score => score;

    public void AddtoScore(int scoreValue) => score += scoreValue;

    public void ResetGame() => Destroy(gameObject);
}
