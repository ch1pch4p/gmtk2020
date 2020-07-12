using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMeow : MonoBehaviour
{
    bool meowing = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Meow());
    }

    IEnumerator Meow()
    {
        AudioManager.instance.PlaySound(SoundName.Meow);
        yield return new WaitForSeconds(Random.Range(7, 10));
        StartCoroutine(Meow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
