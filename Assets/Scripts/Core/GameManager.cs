using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public HealthUI healthUI;
    public GameObject gameOverPanel;


    public int maxHealth = 3;
    public int health;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        health = maxHealth;
    }

    private void Start()
    {
        healthUI.UpdateHealth(health);
    }

<<<<<<< Updated upstream
    public void LoseHealth()
    {
        health--;
=======
    public void StartGame()
    {
        isGameStarted = true;
        Time.timeScale = 1;

        startPanel.SetActive(false);
        answerPanel.SetActive(true);
        answerText.SetActive(true);
        timerUI.SetActive(true);
        healthBar.SetActive(true);
    }


public void LoseHealth()
{
    health--;
    healthUI.UpdateHealth(health);
}
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

public bool IsDead()
{
    return health <= 0;
}

<<<<<<< Updated upstream
    void GameOver()
=======
    public void GameClear()
    {
        Time.timeScale = 0;
        gameClearPanel.SetActive(true);
        answerPanel.SetActive(false);
        answerText.SetActive(false);
        timerUI.SetActive(false);
    }


    public void GameOver()
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        health = maxHealth;
        healthUI.UpdateHealth(health);

        gameOverPanel.SetActive(false);

        QuizController quiz = FindAnyObjectByType<QuizController>();
        quiz.ResetQuiz();
    }

}
