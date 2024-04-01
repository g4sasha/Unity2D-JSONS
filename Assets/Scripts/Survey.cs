using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Questions/QuestionsList", fileName="MyQuestionsList")]
public class Survey : ScriptableObject
{
    public List<Question> Questions;
}
