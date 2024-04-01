using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AnswerListView : MonoBehaviour
{
    [SerializeField] private AnswerView _answerPrefab;
    [SerializeField] private Transform _answerContainer;
    [SerializeField] private string _surveyFileName;

    private string _path => Path.Combine(Application.dataPath, _surveyFileName + ".json");
    private List<AnswerView> _answers = new List<AnswerView>();

    private void OnEnable()
    {
        if (!File.Exists(_path))
        {
            return;   
        }

        string json = File.ReadAllText(_path);
        Survey survey = ScriptableObject.CreateInstance<Survey>();
        JsonUtility.FromJsonOverwrite(json, survey);

        while (_answers.Count > 0)
        {
            Destroy(_answers[0].gameObject);
            _answers.RemoveAt(0);
        }

        foreach (Question question in survey.Questions)
        {
            AnswerView answerView = Instantiate(_answerPrefab, _answerContainer);
            answerView.SetAnswers(question);
            _answers.Add(answerView);
        }
    }
}
