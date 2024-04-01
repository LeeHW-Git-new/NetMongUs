using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUIManager : MonoBehaviour
{
    public static IngameUIManager Instance;

    [SerializeField]
    IngameIntroUI ingameIntroUI;

    public IngameIntroUI IngameIntroUI { get { return ingameIntroUI; } }

    [SerializeField]
    KillButtonUI killButtonUI;
    public KillButtonUI KillButtonUI { get { return killButtonUI; } }

    [SerializeField]
    KillUI killUI;
    public KillUI KillUI { get { return killUI; } }

    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
