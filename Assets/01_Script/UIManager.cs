using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

[Serializable]
public class CraftTableData
{
    public GameObject[] materials = new GameObject[11];
    public GameObject[] tableMaterials = new GameObject[3];
}
[Serializable]
public class ItemTableData
{
    public GameObject[] items = new GameObject[5];
    public GameObject[] itemMaterials = new GameObject[2];
    public ShowMaterial[] eachItemMaterials = new ShowMaterial[5];
    public GameObject hugeIcon;
}
[Serializable]
public class ShowMaterial
{
    public GameObject firstMaterial;
    public int firstMaterialIndex;
    public GameObject secondMaterial;
    public int secondMaterialIndex;
}
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public CraftTableData craftTableData;
    public ItemTableData itemTableData;
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
    private void Start()
    {
        for(int i = 0; i < craftTableData.materials.Length; i++)
        {
            UpdateMaterialByIndex(i);
        }
        craftTableData.tableMaterials[0].transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = "";
        craftTableData.tableMaterials[1].transform.GetChild(1).gameObject.GetComponent<Text>().text = "";
        craftTableData.tableMaterials[2].transform.GetChild(1).gameObject.GetComponent<Text>().text = "";

    }
    public void UpdateMaterialByIndex(int index)
    {
        craftTableData.materials[index].transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GameManager.instance.data.resources[index].ToString();
    }
    public void UpdateMaterial()
    {
        for (int i = 0; i < craftTableData.materials.Length; i++)
        {
            UpdateMaterialByIndex(i);
        }
    }
    public void UpdateCraftTableUI(int index)
    {
        craftTableData.tableMaterials[0].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        craftTableData.tableMaterials[1].transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        craftTableData.tableMaterials[2].transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        if (index % 3 == 0 && index < 9)
        {
            craftTableData.tableMaterials[0].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = craftTableData.materials[index].transform.GetChild(1).GetComponent<Image>().sprite;
            craftTableData.tableMaterials[0].transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GameManager.instance.data.resources[index].ToString() + "/2";
            craftTableData.tableMaterials[1].transform.GetChild(2).gameObject.GetComponent<Image>().sprite = craftTableData.materials[index + 1].transform.GetChild(1).GetComponent<Image>().sprite;
            craftTableData.tableMaterials[1].transform.GetChild(1).gameObject.GetComponent<Text>().text = GameManager.instance.data.resources[index + 1].ToString();
            craftTableData.tableMaterials[2].transform.GetChild(2).gameObject.GetComponent<Image>().sprite = craftTableData.materials[9].transform.GetChild(1).GetComponent<Image>().sprite;
            craftTableData.tableMaterials[2].transform.GetChild(1).gameObject.GetComponent<Text>().text = GameManager.instance.data.resources[9].ToString();
        }
        else if(index % 3 == 1 && index < 9)
        {
            craftTableData.tableMaterials[0].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = craftTableData.materials[index].transform.GetChild(1).GetComponent<Image>().sprite;
            craftTableData.tableMaterials[0].transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GameManager.instance.data.resources[index].ToString() + "/2";
            craftTableData.tableMaterials[1].transform.GetChild(2).gameObject.GetComponent<Image>().sprite = craftTableData.materials[index + 1].transform.GetChild(1).GetComponent<Image>().sprite;
            craftTableData.tableMaterials[1].transform.GetChild(1).gameObject.GetComponent<Text>().text = GameManager.instance.data.resources[index + 1].ToString();
            craftTableData.tableMaterials[2].transform.GetChild(2).gameObject.GetComponent<Image>().sprite = craftTableData.materials[10].transform.GetChild(1).GetComponent<Image>().sprite;
            craftTableData.tableMaterials[2].transform.GetChild(1).gameObject.GetComponent<Text>().text = GameManager.instance.data.resources[10].ToString();

        }
        else if(index < 11)
        {
            craftTableData.tableMaterials[0].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = craftTableData.materials[index].transform.GetChild(1).GetComponent<Image>().sprite;
            craftTableData.tableMaterials[1].transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            craftTableData.tableMaterials[2].transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            craftTableData.tableMaterials[0].transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = GameManager.instance.data.resources[index].ToString();
        }
    }
    public void UpdateItemTableUI(int index)
    {
        itemTableData.hugeIcon.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        itemTableData.itemMaterials[0].transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        itemTableData.itemMaterials[1].transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        itemTableData.hugeIcon.GetComponent<Image>().sprite = itemTableData.items[index].transform.GetChild(1).GetComponent<Image>().sprite;
        itemTableData.itemMaterials[0].transform.GetChild(1).GetComponent<Image>().sprite = itemTableData.eachItemMaterials[index].firstMaterial.GetComponent<Image>().sprite;
        itemTableData.itemMaterials[0].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = GameManager.instance.data.resources[itemTableData.eachItemMaterials[index].firstMaterialIndex].ToString();
        itemTableData.itemMaterials[1].transform.GetChild(1).GetComponent<Image>().sprite = itemTableData.eachItemMaterials[index].secondMaterial.GetComponent<Image>().sprite;
        itemTableData.itemMaterials[1].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = GameManager.instance.data.resources[itemTableData.eachItemMaterials[index].secondMaterialIndex].ToString();
    }
}