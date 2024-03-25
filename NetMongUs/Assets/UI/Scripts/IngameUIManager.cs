using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUIManager : MonoBehaviour
{
    public static IngameUIManager Instance;

    [SerializeField]
    IngameIntroUI ingameIntroUI;

    public IngameIntroUI IngameIntroUI { get { return ingameIntroUI; } }

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
