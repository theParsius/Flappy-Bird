using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour {
    private Text scoreText;
    private Text highscoreText;

    private void Awake() {
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        highscoreText = transform.Find("highscoreText").GetComponent<Text>();
        transform.Find("retryBtn").GetComponent<Button>().onClick.AddListener(() => Loader.Load(Loader.Scene.GameScene));
        // transform.Find("retryBtn").GetComponent<Button>().AddButtonSounds();
        transform.Find("mainMenuBtn").GetComponent<Button>().onClick.AddListener(() => Loader.Load(Loader.Scene.MainMenu));
        // transform.Find("mainMenuBtn").GetComponent<Button>().AddButtonSounds();
    }

    private void Start() {
        Bird.GetInstance().OnDied += Bird_OnDied;
        Hide();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            // Retry
            Loader.Load(Loader.Scene.GameScene);
        }
    }

   private void Bird_OnDied(object sender, System.EventArgs e) {
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();
        if(Level.GetInstance().GetPipesPassedCount() >= Score.GetHighscore()) {
            // New Highscore!
            highscoreText.text = "NEW HIGHSCORE";
        } else {
            highscoreText.text = "HIGHSCORE: " + Score.GetHighscore();

        }
        Show();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void Show() {
        gameObject.SetActive(true);
    }
}
