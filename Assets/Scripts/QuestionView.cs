using UnityEngine;
using UnityEngine.UI;

public class QuestionView : MonoBehaviour
{
    public Question Question
    {
        get => _question;
        set
        {
            _question = value;
            _questionTextField.text = _question.QuestionText;
        }
    }

    [SerializeField] private Text _questionTextField;
    [SerializeField] private InputField _answerInputField;

    private Question _question;

    public void SendAnswer()
    {
        _question.Answers.Add(_answerInputField.text);
        _answerInputField.text = string.Empty;
    }
}
