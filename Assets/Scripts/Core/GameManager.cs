using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameStarted = false;
    public GameObject startPanel;

    public HealthUI healthUI;
     public GameObject healthBar;
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;
    public GameObject answerPanel;
    public GameObject answerText;
    public GameObject timerUI;

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
        Time.timeScale = 0;

        startPanel.SetActive(true);
        answerPanel.SetActive(false);
        answerText.SetActive(false);
        timerUI.SetActive(false);
        healthBar.SetActive(false);
    }


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


public bool IsDead()
{
    return health <= 0;
}



    public void GameClear()
    {
        Time.timeScale = 0;
        gameClearPanel.SetActive(true);
        answerPanel.SetActive(false);
        answerText.SetActive(false);
        timerUI.SetActive(false);
    }


    public void GameOver()

    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        answerPanel.SetActive(false);
        answerText.SetActive(false);
        timerUI.SetActive(false);
    }

    public void Retry()
    {
        Time.timeScale = 1;

        health = maxHealth;
        healthUI.UpdateHealth(health);

        gameOverPanel.SetActive(false);
        gameClearPanel.SetActive(false);

        answerPanel.SetActive(true);
        answerText.SetActive(true);
        timerUI.SetActive(true);
        healthBar.SetActive(true);

        isGameStarted = true;

        QuizController quiz = FindAnyObjectByType<QuizController>();
        quiz.ResetQuiz();
    }


}
