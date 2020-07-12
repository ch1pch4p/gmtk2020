using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class StatsScript : MonoBehaviour
{

    UIPolygon statsIndicator;

    [SerializeField] float str = 1f;
    [SerializeField] float agi = 2f;
    [SerializeField] float foc = 3f;
    [SerializeField] float perc = 4f;
    [SerializeField] float anger = 5f;

    // Start is called before the first frame update
    void Start()
    {
        statsIndicator = GetComponent<UIPolygon>();
        statsIndicator.VerticesDistances = new float[6] { perc * .2f, foc * .2f, agi * .2f, str * .2f, anger * .2f, perc * .2f };
    }

    // Update is called once per frame
    void Update()
    {
        statsIndicator.VerticesDistances = new float[6] { perc * .2f, foc * .2f, agi * .2f, str * .2f, anger * .2f, perc * .2f };
    }
}
