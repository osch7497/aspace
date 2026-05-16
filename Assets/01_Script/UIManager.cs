using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[Serializable]
public class CraftTableData
{
    public GameObject[] materials = new GameObject[11];
    public GameObject[] tableMaterials = new GameObject[3];
}
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public CraftTableData craftTableData;
    private void Awake()
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
    }
    public void UpdateMaterialByIndex(int index)
    {
        craftTableData.materials[index].transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GameManager.instance.data.resources[index].ToString();
    }
    public void UpdateCraftTableUI(int index)
    {
        craftTableData.tableMaterials[0].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        craftTableData.tableMaterials[1].transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        craftTableData.tableMaterials[2].transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        if (index % 3 == 0 && index < 9)
        {
            craftTableData.tableMaterials[0].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = craftTableData.materials[index].transform.GetChild(1).GetComponent<Image>().sprite;
            craftTableData.tableMaterials[1].transform.GetChild(2).gameObject.GetComponent<Image>().sprite = craftTableData.materials[index + 1].transform.GetChild(1).GetComponent<Image>().sprite;
            craftTableData.tableMaterials[2].transform.GetChild(2).gameObject.GetComponent<Image>().sprite = craftTableData.materials[9].transform.GetChild(1).GetComponent<Image>().sprite;
        }
        else if(index % 3 == 1 && index < 9)
        {
            craftTableData.tableMaterials[0].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = craftTableData.materials[index].transform.GetChild(1).GetComponent<Image>().sprite;
            craftTableData.tableMaterials[1].transform.GetChild(2).gameObject.GetComponent<Image>().sprite = craftTableData.materials[index + 1].transform.GetChild(1).GetComponent<Image>().sprite;
            craftTableData.tableMaterials[2].transform.GetChild(2).gameObject.GetComponent<Image>().sprite = craftTableData.materials[10].transform.GetChild(1).GetComponent<Image>().sprite;

        }
        else if(index < 11)
        {
            craftTableData.tableMaterials[0].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = craftTableData.materials[index].transform.GetChild(1).GetComponent<Image>().sprite;
            craftTableData.tableMaterials[1].transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            craftTableData.tableMaterials[2].transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

    }
}