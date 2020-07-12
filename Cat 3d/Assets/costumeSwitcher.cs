using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class costumeSwitcher : MonoBehaviour
{
    [SerializeField]
    private billboardEntry[] billboards;
    [SerializeField]
    private string activeCostume;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < billboards.Length; i++)
        {
            billboards[i].billboard.SetActive(false);
            if (billboards[i].costumeName == activeCostume)
            {
                billboards[i].billboard.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void updateCostume(string costumeName)
    {
        for (int i = 0; i < billboards.Length; i++)
        {
            if (billboards[i].costumeName == costumeName)
            {
                billboards[i].billboard.SetActive(true);
                activeCostume = costumeName;
            }
        }
    }
}
