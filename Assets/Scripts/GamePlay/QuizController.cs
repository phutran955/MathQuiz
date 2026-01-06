using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class QuizController : MonoBehaviour
{

    public TMP_Text questionText;
    public TimerUI timerUI;
    public AnswerButton[] answerButtons;

    public float timeLimit = 10f;
    private float timer;

    private MockData database;
    private int currentIndex;

    bool ShowAnswer = false;

    void Start()
    {
        database = FindFirstObjectByType<MockData>();
        currentIndex = 0;
        LoadQuestion();
    }

    void Update()
    {
<<<<<<< Updated upstream
=======
        if (!GameManager.Instance.isGameStarted)
        {
            return;
        }
        
        if(ShowAnswer == false)
>>>>>>> Stashed changes
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
        ShowAnswer = false;
        timer = timeLimit;

            EventSystem.current.SetSelectedGameObject(null);

    for (int i = 0; i < 4; i++)
    {
        Button btn = answerButtons[i].GetComponent<Button>();
        btn.interactable = true;
    }

        QuestionData q = database.questions[currentIndex];
        questionText.text = q.question;

        for (int i = 0; i < 4; i++)
        {
            answerButtons[i].Setup(q.answers[i], i, this);
        }
    }

    public void CheckAnswer(int index)
    {
        if(ShowAnswer) return;

        StartCoroutine(ShowAnswerAndNext(index));
    }

    IEnumerator ShowAnswerAndNext(int selectedIndex)
{
    ShowAnswer = true;

    // Khóa nút
    for (int i = 0; i < answerButtons.Length; i++)
    {
        answerButtons[i].GetComponent<Button>().interactable = false;
    }

    int correctIndex = database.questions[currentIndex].correctIndex;

    // Đáp án đúng -> xanh
    answerButtons[correctIndex].SetColor(Color.green);

    // Nếu chọn sai -> đỏ
    if (selectedIndex != correctIndex)
    {
        answerButtons[selectedIndex].SetColor(Color.red);
        GameManager.Instance.LoseHealth();
    }

    // Delay 1.5s
    yield return new WaitForSeconds(1.5f);

    if (GameManager.Instance.IsDead())
        {
            GameManager.Instance.GameOver();
            yield break;
        }

    NextQuestion();
}


    void NextQuestion()
    {
        currentIndex++;

        if (currentIndex >= database.questions.Count)
            currentIndex = 0;

        LoadQuestion();
    }

    public void ResetQuiz()
    {
        StopAllCoroutines();
        ShowAnswer = false;

        currentIndex = 0;
        LoadQuestion();
    }

}
