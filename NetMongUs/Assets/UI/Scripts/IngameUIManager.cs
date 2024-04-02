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

    [SerializeField]
    ReportButtonUI reportButtonUI;
    public ReportButtonUI ReporButtonUI { get { return reportButtonUI; } }

    [SerializeField]
    ReportUI reportUI;
    public ReportUI ReportUI { get { return reportUI; } }

    [SerializeField]
    MeetingUI meetingUI;
    public MeetingUI MeetingUI { get { return meetingUI; } }

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
