using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SurveyView : MonoBehaviour
{
    [SerializeField] private Survey _template;
    [SerializeField] private QuestionView _questionPrefab;
    [SerializeField] private Transform _transform;
    [SerializeField] private Button _sendButton;
    [SerializeField] private string _fileName;

    private string _path => Path.Combine(Application.dataPath, _fileName + ".json");
    private List<QuestionView> _questions = new List<QuestionView>();
    private Survey _survey;

    private void Awake()
    {
        _sendButton.onClick.AddListener(OnSend);
    }

    private void Start()
    {
        _survey = Instantiate(_template);

        if (File.Exists(_path))
        {
            string json = File.ReadAllText(_path);
            JsonUtility.FromJsonOverwrite(json, _survey);
        }

        foreach (var item in _survey.Questions)
        {
            QuestionView questionView = Instantiate(_questionPrefab, _transform);
            questionView.Question = item;
            _questions.Add(questionView);
        }
    }

    private void OnSend()
    {
        foreach (QuestionView item in _questions)
        {
            item.SendAnswer();
            string json = JsonUtility.ToJson(_survey);
            File.WriteAllText(_path, json);
        }
    }
}
