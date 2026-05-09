using System;
using System.IO;
using UnityEngine;
[Serializable]
public class PlayerData{
    public int[] resources = new int[11];
    public int[] upgrades = new int[5] {1,1,1,1,0};
    public int checkPoint;
}
public class GameManager : MonoBehaviour
{
    public PlayerData data;
    public void Awake(){
    }
    public void Save(){
        File.WriteAllText(Path.Combine(Path.GetTempPath(),"save"),JsonUtility.ToJson(data));
        Debug.Log($"{Path.Combine(Path.GetTempPath(), "save")} saved {JsonUtility.ToJson(data)}");
    }
    public void load(){
        string rawsave = File.ReadAllText(Path.Combine(Path.GetTempPath(), "save"));
        data = JsonUtility.FromJson<PlayerData>(rawsave);
        Debug.Log($"loaded context = {rawsave}");
    }
}
