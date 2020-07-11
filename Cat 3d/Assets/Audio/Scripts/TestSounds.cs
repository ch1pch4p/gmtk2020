using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayAllSounds());
    }
    IEnumerator PlayAllSounds()
    {
        while (true)
        {
            Sound[] sounds = AudioManager.instance.getSounds();
            for (int i = 0; i < sounds.Length; i++)
            {
                AudioManager.instance.PlaySound(sounds[i].soundName);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}