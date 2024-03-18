using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Mirror;

public class LobbyUIManager : MonoBehaviour
{
    public static LobbyUIManager Instance;

    [SerializeField]
    private CustomizeUI customizeUI;

    public CustomizeUI CustomizeUI { get { return customizeUI; } }

    [SerializeField]
    GameRoomPlayerCounter gameRoomPlayerCounter;
    public GameRoomPlayerCounter GameRoomPlayerCounter { get { return gameRoomPlayerCounter; } }

    [SerializeField]
    Button useButton;
    [SerializeField]
    Sprite originUseButtonSprite;

    [SerializeField]
    Button startButton;


    private void Awake()
    {
        Instance = this;
    }

    public void SetUseButton(Sprite sprite, UnityAction action)
    {
        useButton.image.sprite = sprite;
        useButton.onClick.AddListener(action);
        useButton.interactable = true;
    }

    public void UnsetUseButton()
    {
        useButton.image.sprite = originUseButtonSprite;
        useButton.onClick.RemoveAllListeners();
        useButton.interactable = false;
    }

    public void ActiveStartButton()
    {
        startButton.gameObject.SetActive(true);
    }
    public void SetInteractableStartButton(bool isInteractable)
    {
        startButton.interactable = isInteractable;
    }
    
    public void OnClickStartButton()
    {
        var players = FindObjectsOfType<AmongUsRoomPlayer>();
        for(int i = 0; i < players.Length; i++)
        {
            players[i].readyToBegin = true;
        }

        var manager = NetworkManager.singleton as AmongUsRoomManager;
        manager.ServerChangeScene(manager.GameplayScene);
    }
}
