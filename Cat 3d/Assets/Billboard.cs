using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Billboard : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public Transform camTransform;
    Dictionary<string, GameObject> expressions;
    string[] expressionKeys = {"alert", "angry", "asleep", "lazy", "normal"};
    private string currentExpression = "normal";
    void Start()
    {
        if(camera != null)
            camTransform = camera.transform;
        expressions = new Dictionary<string, GameObject>();
    }

    public void updateExpression(string expression)
    {
        if(expressions[expression] != null)
        {
            expressions[currentExpression].SetActive(false);
            expressions[expression].SetActive(true);
            currentExpression = expression;
        } else
        {
            Debug.Log("Can't update expression; expression doesn't exist (alert, angry, asleep, lazy, normal)");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(camTransform != null)
        {
            Quaternion dir = Quaternion.LookRotation(-camTransform.forward, camTransform.up);
            this.transform.forward = dir * Vector3.forward;
        }
    }
}
