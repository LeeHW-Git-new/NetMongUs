using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DeadBody : NetworkBehaviour
{
    SpriteRenderer spriteRenderer;

    EPlayerColor deadbodyColor;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [ClientRpc]
    public void RpcSetColor(EPlayerColor color)
    {
        deadbodyColor = color;
        spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(color));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<InGameCharacterMover>();
        if(player != null && player.hasAuthority && (player.playerType & EPlayerType.Ghost) != EPlayerType.Ghost)
        {
            IngameUIManager.Instance.ReporButtonUI.SetInteractable(true);
            var myCharacter = AmongUsRoomPlayer.MyRoomPlayer.myCharacter as InGameCharacterMover;
            myCharacter.foundDeadbodyColor = deadbodyColor;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<InGameCharacterMover>();
        if (player != null && player.hasAuthority && (player.playerType & EPlayerType.Ghost) != EPlayerType.Ghost)
        {
            IngameUIManager.Instance.ReporButtonUI.SetInteractable(false);
        }
    }
}
