using System;
using System.Collections.Generic;
using System.Linq;

public class PlayerStatus
{

    public static PlayerStatus Instance = new PlayerStatus();
    
    public int NowScore;
    public int NowLevel;
    public List<GimmickKind> FoundKindList = new List<GimmickKind>();

    public void Reset()
    {
        NowScore = 0;
        FoundKindList.Clear();
    }

    public void Add(GimmickKind kind)
    {
        if (FoundKindList.Contains(kind)) { return; }
        FoundKindList.Add(kind);
        NowScore += GimmickDataList.Instance.DataList[(int)kind].score;
    }

    internal string CreateReport()
    {
        string report = "";
        foreach (var kind in FoundKindList)
        {
            GimmickData data = GimmickDataList.Instance.DataList[(int)kind];
            if (data.score != 0)
            {
                report += $"{data.report}\n";
            }
        }
        return report;
    }
}