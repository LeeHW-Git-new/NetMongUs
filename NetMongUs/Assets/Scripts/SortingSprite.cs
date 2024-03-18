using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingSprite : MonoBehaviour
{
    public enum ESortingType
    {
        Static, Updata
    }

    [SerializeField]
    ESortingType sortingType;

    SpriteSorter sorter;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        sorter = FindObjectOfType<SpriteSorter>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sortingOrder = sorter.GetSortingOrder(gameObject);
    }

    void Update()
    {
        if (sortingType == ESortingType.Updata)
        {
            spriteRenderer.sortingOrder = sorter.GetSortingOrder(gameObject);
        }
    }
}
