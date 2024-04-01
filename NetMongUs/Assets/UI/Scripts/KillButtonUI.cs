using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillButtonUI : MonoBehaviour
{
    [SerializeField]
    Button killButton;

    [SerializeField]
    Text cooldownText;

    InGameCharacterMover targetPlayer;

    public void Show(InGameCharacterMover player)
    {
        gameObject.SetActive(true);
        targetPlayer = player;
    }

    void Update()
    {
        if(targetPlayer != null)
        {
            if(!targetPlayer.isKillable)
            {
                cooldownText.text = targetPlayer.KillCooldown > 0 ? ((int)targetPlayer.KillCooldown).ToString() : "";
                killButton.interactable = false;
            }
            else
            {
                cooldownText.text = "";
                killButton.interactable = true;
            }
        }
    }

    public void OnClickKillButton()
    {
        targetPlayer.Kill();
    }
}
