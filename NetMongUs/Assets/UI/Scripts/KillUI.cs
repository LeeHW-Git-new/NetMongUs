using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillUI : MonoBehaviour
{
    [SerializeField]
    Image imposterImg;

    [SerializeField]
    Image crewmatelImg;

    [SerializeField]
    Material material;

    public void Open(EPlayerColor imposter, EPlayerColor crewmate)
    {
        AmongUsRoomPlayer.MyRoomPlayer.myCharacter.IsMoveable = false;

        Material inst1 = Instantiate(material);
        imposterImg.material = inst1;
        Material inst2 = Instantiate(material);
        crewmatelImg.material = inst2;

        gameObject.SetActive(true);

        imposterImg.material.SetColor("_PlayerColor", PlayerColor.GetColor(imposter));
        crewmatelImg.material.SetColor("_PlayerColor", PlayerColor.GetColor(crewmate));

        Invoke("Close", 3f);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        AmongUsRoomPlayer.MyRoomPlayer.myCharacter.IsMoveable = true;
    }
}
