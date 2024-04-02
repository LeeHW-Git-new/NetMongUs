using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Mirror;

public class GameSystem : NetworkBehaviour
{
    public static GameSystem Instance;

    List<InGameCharacterMover> players = new List<InGameCharacterMover>();

    [SerializeField]
    Transform spawnTransform;

    [SerializeField]
    float spawnDistance;

    [SyncVar]
    public float killCooldown;

    [SyncVar]
    public int killRange;

    [SerializeField]
    Light2D shadowLight;

    [SerializeField]
    Light2D lightMapLight;

    [SerializeField]
    Light2D gloabalLight;


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
        killCooldown = manager.gameRuleData.killCooldown;
        killRange = (int)manager.gameRuleData.killRange;

        while (manager.roomSlots.Count != players.Count)
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

        for(int i = 0; i < players.Count; i++)
        {
            float radian = (2f * Mathf.PI) / players.Count;
            radian *= i;
            players[i].RpcTeleport( spawnTransform.position + (new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0f) * spawnDistance));
        }

        yield return new WaitForSeconds(2f);
        RpcStartGame();

        foreach(var player in players)
        {
            player.SetKillCooldown();
        }
    }

    [ClientRpc]
    void RpcStartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        yield return StartCoroutine(IngameUIManager.Instance.IngameIntroUI.ShowIntroSequence());

        InGameCharacterMover myCharacter = null;
        foreach(var player in players)
        {
            if(player.hasAuthority)
            {
                myCharacter = player;
                break;
            }
        }

        foreach(var player in players)
        {
            player.SetNicknameColor(myCharacter.playerType);
        }

        yield return new WaitForSeconds(3f);
        IngameUIManager.Instance.IngameIntroUI.Close();
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
        if(isServer)
        {
            StartCoroutine(GameReady());
        }
    }

    public void ChangeLightMode(EPlayerType type)
    {
        if(type == EPlayerType.Ghost)
        {
            lightMapLight.lightType = Light2D.LightType.Global;
            shadowLight.intensity = 0f;
            gloabalLight.intensity = 1f;
        }
        else
        {
            lightMapLight.lightType = Light2D.LightType.Point;
            shadowLight.intensity = 0.5f;
            gloabalLight.intensity = 0.5f;
        }
    }

    public void StartReportMeeting(EPlayerColor deadbodyColor)
    {
        RpcSendReportSign(deadbodyColor);
    }

    IEnumerator StartMeeting_Coroutine()
    {
        yield return new WaitForSeconds(3f);
        IngameUIManager.Instance.ReportUI.Close();
        IngameUIManager.Instance.MeetingUI.Open();
    }

    [ClientRpc]
    void RpcSendReportSign(EPlayerColor deadbodyColor)
    {
        IngameUIManager.Instance.ReportUI.Open(deadbodyColor);

        StartCoroutine(StartMeeting_Coroutine());
    }
}
