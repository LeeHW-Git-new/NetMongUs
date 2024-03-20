using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPipLightStarter : MonoBehaviour
{
    WaitForSeconds wait = new WaitForSeconds(1f);

    List<WeaponPipLight> lights = new List<WeaponPipLight>();


    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).GetComponent<WeaponPipLight>();
            if(child)
            {
                lights.Add(child);
            }
        }
        StartCoroutine(TrunOnPipeLight());
    }


    IEnumerator TrunOnPipeLight()
    {
        while(true)
        {
            yield return wait;

            foreach(var child in lights)
            {
                child.TurnOnLight();
            }
        }
    }
}
