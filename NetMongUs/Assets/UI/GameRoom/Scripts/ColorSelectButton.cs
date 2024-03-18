using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelectButton : MonoBehaviour
{
    [SerializeField]
    GameObject xButton;

    public bool isInteractable = true;

    public void SetInteractable(bool isInteractable)
    {
        this.isInteractable = isInteractable;
        xButton.SetActive(!isInteractable);
    }
}
