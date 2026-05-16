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
    public static GameManager instance;
    public PlayerData data;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        for(int i = 0; i < data.resources.Length; i++)
        {
            data.resources[i] = 20;
        }
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
    public void GatherResource(int[] PlayerResources) {
        for (int i = 0; i < 11; i++){
            data.resources[i] += PlayerResources[i];
        }
    }
}
