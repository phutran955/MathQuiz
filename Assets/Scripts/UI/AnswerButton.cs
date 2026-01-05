using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButton : MonoBehaviour
{

    public TMP_Text answerText;
    private int index;
    private QuizController quiz;

    public void Setup(string text, int i, QuizController q)
    {
        answerText.text = text;
        index = i;
        quiz = q;
    }

    public void OnClick()
    {
        quiz.CheckAnswer(index);
    }
}
