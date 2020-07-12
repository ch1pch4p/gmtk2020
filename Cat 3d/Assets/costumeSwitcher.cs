using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class costumeSwitcher : MonoBehaviour
{
    [SerializeField]
    private billboardEntry[] billboards;
    [SerializeField]
    private string activeCostume;
    [SerializeField]
    private string activeExpression = "normal";
    private Dictionary<string, billboardEntry> bbDictionary;
    private Dictionary<string, int> costumeIndexes;
    private string[] costumeList = { "Sit 1", "Sit 2", "Walk 1", "Walk 2", "Crouch", "Pounce"};
    // Start is called before the first frame update
    void Start()
    {
        bbDictionary = new Dictionary<string, billboardEntry>();
        for (int i = 0; i < billboards.Length; i++)
        {
            bbDictionary.Add(billboards[i].costumeName, billboards[i]);
            string[] expressionKeys = billboards[i].getExpressionKeys();
            Transform expressionContainer = billboards[i].billboard.gameObject.transform.GetChild(0);
            for (int j = 0; j < billboards[i].billboard.transform.childCount; j ++)
            {
                billboards[i].initializeDictionary();
                //billboards[i].linkExpression(expressionKeys[j], expressionContainer.GetChild(j).gameObject);
            }
            billboards[i].updateExpression(activeExpression);
            billboards[i].billboard.SetActive(false);
        }
        if(bbDictionary[activeCostume] != null)
        {
            bbDictionary[activeCostume].billboard.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public string[] getExpressionKeys()
    {
        string[] keysList = { };
        for(int i = 0; i < )
    }
    */

    public void updateCostume(string costumeName)
    {
        if(bbDictionary[costumeName] != null)
        {
            bbDictionary[activeCostume].billboard.SetActive(false);
            activeCostume = costumeName;
            updateExpression(activeExpression);
            bbDictionary[costumeName].billboard.SetActive(true);
            
            
        }
    }

    public void updateExpression(string expression)
    {
        string[] expressionList = bbDictionary[activeCostume].getExpressionKeys();

        bbDictionary[activeCostume].updateExpression(expression);
    }
}
