using System.Collections.Generic;
using UnityEngine;

public class MockData : MonoBehaviour
{
    public List<QuestionData> questions;

    private void Awake()
    {
        LoadFakeData();
    }

    void LoadFakeData()
    {
        questions = new List<QuestionData>()
        {
            new QuestionData()
            {
                question = "Thủ đô của Việt Nam là gì?",
                answers = new string[] {"Hà Nội", "TP.HCM", "Đà Nẵng", "Huế"},
                correctIndex = 0
            },
            new QuestionData()
            {
                question = "2 + 5 = ?",
                answers = new string[] {"5", "6", "7", "8"},
                correctIndex = 2
            }
        };
    }
}
