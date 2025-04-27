using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    private void Awake() {
        Application.targetFrameRate = 60;
        
        Debug.Log("Awake");

        gameOver.SetActive(false);  // hide the game over screen
        playButton.SetActive(true); // show play button at start
        Pause();
    }

    public void Play() {
        
        player.transform.position = new Vector3(0, 0, 0);
        score = 0;
        scoreText.text = score.ToString();

        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        PipeMove[] pipes = FindObjectsOfType<PipeMove>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause() {
        Time.timeScale = 0f; // time doesn't update
        player.enabled = false;
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver() {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }
}
