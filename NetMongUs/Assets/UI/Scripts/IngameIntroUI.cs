using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameIntroUI : MonoBehaviour
{
    [SerializeField]
    GameObject shhhhObj;

    [SerializeField]
    GameObject crewmateObj;

    [SerializeField]
    Text playerType;

    [SerializeField]
    Image gradientImg;

    [SerializeField]
    IntroCharacter myCharacter;

    [SerializeField]
    List<IntroCharacter> otherCharacters = new List<IntroCharacter>();

    [SerializeField]
    Color crewColor;

    [SerializeField]
    Color imposterColor;

    [SerializeField]
    CanvasGroup canvasGroup;

    public IEnumerator ShowIntroSequence()
    {
        shhhhObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        shhhhObj.SetActive(false);

        ShowPlayerType();
        crewmateObj.SetActive(true);
    }

    public void ShowPlayerType()
    {
        var players = GameSystem.Instance.GetPlayerList();

        InGameCharacterMover myPlayer = null;
        foreach(var player in players)
        {
            if(player.hasAuthority)
            {
                myPlayer = player;
                break;
            }
        }

        myCharacter.SetIntroCharacter(myPlayer.nickname, myPlayer.playerColor);

        if(myPlayer.playerType == EPlayerType.Imposter)
        {
            playerType.text = "임포스터";
            playerType.color = gradientImg.color = imposterColor;

            int i = 0;
            foreach(var player in players)
            {
                if(!player.hasAuthority && player.playerType == EPlayerType.Imposter)
                {
                    otherCharacters[i].SetIntroCharacter(player.nickname, player.playerColor);
                    otherCharacters[i].gameObject.SetActive(true);
                    i++;
                }
            }
        }
        else
        {
            playerType.text = "크루원";
            playerType.color = gradientImg.color = crewColor;

            int i = 0;
            foreach (var player in players)
            {
                if (!player.hasAuthority)
                {
                    otherCharacters[i].SetIntroCharacter(player.nickname, player.playerColor);
                    otherCharacters[i].gameObject.SetActive(true);
                    i++;
                }
            }
        }
    }

    public void Close()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float timer = 0f;
        while(timer <= 1f)
        {
            yield return null;
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer);
        }

        gameObject.SetActive(false);
    }
}
