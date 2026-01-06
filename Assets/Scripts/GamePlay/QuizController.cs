using UnityEngine;
using TMPro;

public class QuizController : MonoBehaviour
{

    public TMP_Text questionText;
    public TimerUI timerUI;
    public AnswerButton[] answerButtons;

    public float timeLimit = 10f;
    private float timer;

    private MockData database;
    private int currentIndex;

    void Start()
    {
        database = FindFirstObjectByType<MockData>();
        currentIndex = 0;
        LoadQuestion();
    }

    void Update()
    {
        if (!GameManager.Instance.isGameStarted)
        {
            return;
        }
        timer -= Time.deltaTime;

        timerUI.UpdateTime(timer, timeLimit);

        if (timer <= 0)
        {
            GameManager.Instance.LoseHealth();
            NextQuestion();
        }
    }


    void LoadQuestion()
    {
        timer = timeLimit;

        QuestionData q = database.questions[currentIndex];
        questionText.text = q.question;

        for (int i = 0; i < 4; i++)
        {
            answerButtons[i].Setup(q.answers[i], i, this);
        }
    }

    public void CheckAnswer(int index)
    {
        if (index != database.questions[currentIndex].correctIndex)
        {
            GameManager.Instance.LoseHealth();
        }

        NextQuestion();
    }

    void NextQuestion()
    {
        currentIndex++;

        if (currentIndex >= database.questions.Count)
        {
            GameManager.Instance.GameClear();
            return;
        }


        LoadQuestion();
    }

    public void ResetQuiz()
    {
        currentIndex = 0;
        LoadQuestion();
    }

}
