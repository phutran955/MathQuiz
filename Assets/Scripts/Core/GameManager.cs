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

    public void LoseHealth()
    {
        health--;

        healthUI.UpdateHealth(health);

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
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
