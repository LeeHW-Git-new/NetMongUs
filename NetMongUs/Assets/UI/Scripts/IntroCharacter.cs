using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCharacter : MonoBehaviour
{
    [SerializeField]
    Image character;

    [SerializeField]
    Text nickname;

    public void SetIntroCharacter(string ncik, EPlayerColor playerColor)
    {
        var matInst = Instantiate(character.material);
        character.material = matInst;

        nickname.text = ncik;
        character.material.SetColor("_PlayerColor", PlayerColor.GetColor(playerColor));
    }
}
