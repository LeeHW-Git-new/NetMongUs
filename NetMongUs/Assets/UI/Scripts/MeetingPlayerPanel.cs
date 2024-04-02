using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeetingPlayerPanel : MonoBehaviour
{
    [SerializeField]
    Image characterImg;

    [SerializeField]
    Text nicknameText;

    [SerializeField]
    GameObject deadPlayerBlock;

    [SerializeField]
    GameObject reportSign;

    [SerializeField]
    GameObject voteButtons;

    [HideInInspector]
    public InGameCharacterMover targetPlayer;

    public void SetPlayer(InGameCharacterMover target)
    {
        Material inst = Instantiate(characterImg.material);
        characterImg.material = inst;

        targetPlayer = target;
        characterImg.material.SetColor("_PlayerColor", PlayerColor.GetColor(targetPlayer.playerColor));
        nicknameText.text = target.nickname;

        var myCharacter = AmongUsRoomPlayer.MyRoomPlayer.myCharacter as InGameCharacterMover;
        if(((myCharacter.playerType & EPlayerType.Imposter) == EPlayerType.Imposter)
            && ((targetPlayer.playerType & EPlayerType.Imposter) == EPlayerType.Imposter))
        {
            nicknameText.color = Color.red;
        }
        bool isDead = (targetPlayer.playerType & EPlayerType.Ghost) == EPlayerType.Ghost;
        deadPlayerBlock.SetActive((targetPlayer.playerType & EPlayerType.Ghost) == EPlayerType.Ghost);
        GetComponent<Button>().interactable = !isDead;
        reportSign.SetActive(target.isReporter);
    }

    public void OnClickPlayerPanel()
    {
        var myCharacter = AmongUsRoomPlayer.MyRoomPlayer.myCharacter as InGameCharacterMover;
        if ((myCharacter.playerType & EPlayerType.Ghost) != EPlayerType.Ghost)
        {
            IngameUIManager.Instance.MeetingUI.SelectPlayerPanel();
            voteButtons.SetActive(true);
        }
    }

    public void Unselect()
    {
        voteButtons.SetActive(false);
    }
}
