using UnityEngine;
using UnityEngine.UI;

public class ItemPickUpScript : MonoBehaviour{
    public int ResourceIndex;
    public Vector2 ResourcePickUpRange;
    public Transform gatherUIFolder;
    public GameObject gatherUIFolderPrefab;
    public int gather(){
        GameObject uiprefab = Instantiate(gatherUIFolderPrefab, gatherUIFolder);
        int returnResouces = (int)UnityEngine.Random.Range(ResourcePickUpRange.x, ResourcePickUpRange.y);   
        uiprefab.transform.GetChild(0).GetComponent<Text>().text = $"{transform.name} +{returnResouces}";
        return returnResouces;
    }
}
