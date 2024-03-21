using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enginebody : MonoBehaviour
{
    [SerializeField]
    List<GameObject> steams = new List<GameObject>();

    [SerializeField]
    List<SpriteRenderer> sparks = new List<SpriteRenderer>();

    [SerializeField]
    List<Sprite> sparkSprites = new List<Sprite>();

    int nowIndex = 0;

    void Start()
    {
        foreach(var steam in steams)
        {
            StartCoroutine(RandomSteam(steam));
        }

        StartCoroutine(SparkEngine());
    }

    IEnumerator RandomSteam(GameObject steam)
    {
        while(true)
        {
            float timer = Random.Range(0.5f, 1.5f);
            while(timer >= 0f)
            {
                yield return null;
                timer -= Time.deltaTime;
            }

            steam.SetActive(true);
            timer = 0f;
            while(timer <= 0.6f)
            {
                yield return null;
                timer += Time.deltaTime;
            }
            steam.SetActive(false);
        }
    }

    IEnumerator SparkEngine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.05f);
        while(true)
        {
            float timer = Random.Range(0.2f, 1.5f);
            while (timer >= 0f)
            {
                yield return null;
                timer -= Time.deltaTime;
            }

            int[] indices = new int[Random.Range(2, 7)];
            for(int i = 0; i < indices.Length; i++)
            {
                indices[i] = Random.Range(0, sparkSprites.Count);
            }

            for(int i = 0; i < indices.Length; i++)
            {
                yield return wait;
                sparks[nowIndex].sprite = sparkSprites[indices[i]];
            }

            sparks[nowIndex++].sprite = null;
            if(nowIndex >= sparks.Count)
            {
                nowIndex = 0;
            }
        }
    }
}
