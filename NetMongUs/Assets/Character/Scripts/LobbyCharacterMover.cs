﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LobbyCharacterMover : CharacterMover
{
    public void CompleteSpawn()
    {
        if (hasAuthority)
        {
            isMoveable = true;
        }
    }
}
