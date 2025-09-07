using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class RankingEntry : IComparable<RankingEntry>
{
    public string name;
    public float time;
    public RankingEntry(string name, float time) => (this.name, this.time) = (name, time);
    public int CompareTo(RankingEntry other)
    {
        int result = time.CompareTo(other.time);
        return result != 0 ? result : name.CompareTo(other.name);
    }
}

[Serializable]
public class RankingListWrapper { public List<RankingEntry> entries = new(); }

public class Ranking : Singleton<Ranking>
{
    public Text rankingText;
    public string playerName;
    public float playerTime;

    private const int MaxEntries = 5;
    private string FilePath => Path.Combine(Application.persistentDataPath, "Ranking.json");

    private SortedSet<RankingEntry> rankings = new();

    private void Start() => Load();

    public void Load()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            var wrapper = JsonUtility.FromJson<RankingListWrapper>(json);
            rankings = new SortedSet<RankingEntry>(wrapper.entries);
        }
        UpdateUI();
    }

    public void Save()
    {
        rankings.Add(new RankingEntry(playerName, playerTime));
        while (rankings.Count > MaxEntries) rankings.Remove(rankings.Max);
        File.WriteAllText(FilePath, JsonUtility.ToJson(new RankingListWrapper { entries = rankings.ToList() }));
        UpdateUI();
    }

    private void UpdateUI()
    {
        rankingText.text = "";
        var list = rankings.Take(MaxEntries).ToList();
        for (int i = 0; i < MaxEntries; i++)
        {
            if (i < list.Count)
            {
                var e = list[i];
                int min = Mathf.FloorToInt(e.time / 60), sec = Mathf.FloorToInt(e.time % 60);
                rankingText.text += $"{i + 1}위: {e.name}   {min:00}:{sec:00}\n";
            }
            else rankingText.text += $"{i + 1}위: 입력된 정보가 없음\n";
        }
    }
}
