using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private float waitTime = 2f;

    public void LoadStartMenu()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame() => Application.Quit();

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Game Over");
    }
}
