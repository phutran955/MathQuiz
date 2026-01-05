using System;

[Serializable]
public class QuestionData
{
    public string question;
    public string[] answers; // 4 đáp án
    public int correctIndex; // 0–3
}
