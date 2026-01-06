using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButton : MonoBehaviour
{

    public TMP_Text answerText;
    private int index;
    private QuizController quiz;
    
    public Image background;

    public void Setup(string text, int i, QuizController q)
    {
        answerText.text = text;
        index = i;
        quiz = q;

        SetColor(Color.white); 
    }

    public void OnClick()
    {
        quiz.CheckAnswer(index);
    }

        public void SetColor(Color color)
    {
        background.color = color;
    }
}
