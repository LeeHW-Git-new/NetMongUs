using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskListUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    float offset;

    [SerializeField]
    RectTransform TaskListUITransform;

    bool isOpen = true;

    float timer;

    public void OnPointerClick(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(OpenAndHideUI());
    }
    
    IEnumerator OpenAndHideUI()
    {
        isOpen = !isOpen;
        if (timer != 0f)
        {
            timer = 1f - timer;
        }

        while(timer <= 1f)
        {
            timer += Time.deltaTime * 2f;

            float start = isOpen ? -TaskListUITransform.sizeDelta.x : offset;
            float dest = isOpen ? offset : -TaskListUITransform.sizeDelta.x;
            TaskListUITransform.anchoredPosition = new Vector2(Mathf.Lerp(start, dest, timer), TaskListUITransform.anchoredPosition.y);
            yield return null;
        }
    }
}
