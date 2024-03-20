using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPipLight : MonoBehaviour
{
    Animator animator;

    WaitForSeconds wait = new WaitForSeconds(0.15f);

    List<WeaponPipLight> lights = new List<WeaponPipLight>();

    void Start()
    {
        animator = GetComponent<Animator>();

        for(int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).GetComponent<WeaponPipLight>();
            if(child)
            {
                lights.Add(child);
            }
        }
    }

    public void TurnOnLight() 
    {
        animator.SetTrigger("on");
        StartCoroutine(TurnOnLightAtChild());
    }

    IEnumerator TurnOnLightAtChild()
    {
        yield return wait;

        foreach(var child in lights)
        {
            child.TurnOnLight();
        }
    }
}
