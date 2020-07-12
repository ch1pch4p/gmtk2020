using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class billboardEntry
{
    public string costumeName;
    public GameObject billboard;
    public Dictionary<string, GameObject> expressions;
    private static string[] expressionKeys = { "Alert", "Angry", "Asleep", "Lazy", "Normal" };
    private string currentExpression = "Normal";

    public void initializeDictionary()
    {
        Transform faceContainer = billboard.transform.GetChild(0);
        expressions = new Dictionary<string, GameObject>();
        for(int i = 0; i < faceContainer.childCount; i++)
        {
            GameObject currentExpression = faceContainer.GetChild(i).gameObject;
            expressions.Add(currentExpression.name, currentExpression);
        }
    }

    public void linkExpression(string expressionKey, GameObject expression)
    {
        //initialize dictionary
        if(expressions == null)
        {
            expressions = new Dictionary<string, GameObject>();
        }
        expressions.Add(expressionKey, expression);
    }
    public string[] getExpressionKeys()
    {
        return expressionKeys;
    }
    public void updateExpression(string expression)
    {
        if(expressions.Keys.Count > 0)
        {
            if(expressions[expression] != null)
            {
                expressions[currentExpression].SetActive(false);
                expressions[expression].SetActive(true);
                currentExpression = expression;
            }
            else
            {
                Debug.Log("Can't update expression; expression doesn't exist (alert, angry, asleep, lazy, normal)");
            }
        }

    }
}
