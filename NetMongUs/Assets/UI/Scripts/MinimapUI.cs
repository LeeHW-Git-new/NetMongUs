using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapUI : MonoBehaviour
{
    [SerializeField]
    Transform left;
    [SerializeField]
    Transform right;
    [SerializeField]
    Transform top;
    [SerializeField]
    Transform bottm;

    [SerializeField]
    Image minimapImage;
    [SerializeField]
    Image minimapPlayerImage;

    CharacterMover targetPlayer;

    void Start()
    {
        var inst = Instantiate(minimapImage.material);
        minimapImage.material = inst;

        targetPlayer = AmongUsRoomPlayer.MyRoomPlayer.myCharacter;
    }

    void Update()
    {
        if(targetPlayer != null)
        {
            Vector2 mapArea = new Vector2(Vector3.Distance(left.position, right.position), Vector3.Distance(bottm.position, top.position));
            Vector2 charPos = new Vector2(Vector3.Distance(left.position, new Vector3(targetPlayer.transform.position.x, 0f, 0f)),
                Vector3.Distance(bottm.position, new Vector3(0f, targetPlayer.transform.position.y, 0f)));
            Vector2 normalPos = new Vector2(charPos.x / mapArea.x, charPos.y / mapArea.y);

            minimapPlayerImage.rectTransform.anchoredPosition = new Vector2(minimapImage.rectTransform.sizeDelta.x * normalPos.x,
                minimapImage.rectTransform.sizeDelta.y * normalPos.y);
        }
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
