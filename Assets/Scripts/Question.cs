using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Question
{
    public string QuestionText;
    [HideInInspector] public List<string> Answers;
}