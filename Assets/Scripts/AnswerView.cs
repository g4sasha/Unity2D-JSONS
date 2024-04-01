using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AnswerView : MonoBehaviour
{
    [SerializeField] private Text _questionText;
    [SerializeField] private Text _answersText;

    public void SetAnswers(Question question)
    {
        _questionText.text = question.QuestionText;
        string[] strings = question.Answers.Reverse<string>().ToArray();
        _answersText.text = string.Join('\n', strings);
    }
}
