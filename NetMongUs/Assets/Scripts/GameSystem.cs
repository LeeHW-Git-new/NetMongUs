using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameSystem : NetworkBehaviour
{
    public static GameSystem Instance;

    List<InGameCharacterMover> players = new List<InGameCharacterMover>();

    public void AddPlayer(InGameCharacterMover player)
    {
        if(!players.Contains(player))
        {
            players.Add(player);
        }
    }

    IEnumerator GameReady()
    {
        var manager = NetworkManager.singleton as AmongUsRoomManager;
        while(manager.roomSlots.Count != players.Count)
        {
            yield return null;
        }

        for(int i = 0; i < manager.imposterCount; i++)
        {
            var player = players[Random.Range(0, players.Count)];
            if(player.playerType != EPlayerType.Imposter)
            {
                player.playerType = EPlayerType.Imposter;
            }
            else
            {
                i--;
            }
        }

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(IngameUIManager.Instance.IngameIntroUI.ShowIntroSequence());
    }

    public List<InGameCharacterMover> GetPlayerList()
    {
        return players;
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(GameReady());
    }


    void Update()
    {
        
    }
}
