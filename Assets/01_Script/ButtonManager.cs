using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    public int craftingMaterialIndex;
    public int craftingItemIndex;
    public GameObject MakeOneThingPanel;
    public GameObject MakeTwoThingPanel;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PutingMaterial(int index)
    {
        craftingMaterialIndex = index;
        UIManager.instance.UpdateCraftTableUI(index);
    }
    public void Crafting()
    {
        if (craftingMaterialIndex % 3 == 0 && craftingMaterialIndex < 9 && GameManager.instance.data.resources[craftingMaterialIndex] >= 2)
        {
            GameManager.instance.data.resources[craftingMaterialIndex] -= 2;
            GameManager.instance.data.resources[craftingMaterialIndex + 1]++;
            int value = UnityEngine.Random.Range(0, 10);
            if (value < 3)
            {
                GameManager.instance.data.resources[9]++;
                UIManager.instance.makeTwoThing.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = UIManager.instance.craftTableData.materials[craftingMaterialIndex + 1].transform.GetChild(1).GetComponent<Image>().sprite;
                UIManager.instance.makeTwoThing.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = UIManager.instance.craftTableData.materials[9].transform.GetChild(1).GetComponent<Image>().sprite;
                MakeTwoThingPanel.SetActive(true);
            }
            else
            {
                UIManager.instance.makeOneThing.transform.GetChild(0).GetComponent<Image>().sprite = UIManager.instance.craftTableData.materials[craftingMaterialIndex + 1].transform.GetChild(1).GetComponent<Image>().sprite;
                MakeOneThingPanel.SetActive(true);
            }
        }
        else if (craftingMaterialIndex % 3 == 1 && craftingMaterialIndex < 9 && GameManager.instance.data.resources[craftingMaterialIndex] >= 2)
        {
            GameManager.instance.data.resources[craftingMaterialIndex] -= 2;
            GameManager.instance.data.resources[craftingMaterialIndex + 1]++;
            int value = UnityEngine.Random.Range(0, 10);
            if (value < 3)
            {
                GameManager.instance.data.resources[10]++;
                UIManager.instance.makeTwoThing.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = UIManager.instance.craftTableData.materials[craftingMaterialIndex + 1].transform.GetChild(1).GetComponent<Image>().sprite;
                UIManager.instance.makeTwoThing.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = UIManager.instance.craftTableData.materials[10].transform.GetChild(1).GetComponent<Image>().sprite;
                MakeTwoThingPanel.SetActive(true);
            }
            else
            {
                UIManager.instance.makeOneThing.transform.GetChild(0).GetComponent<Image>().sprite = UIManager.instance.craftTableData.materials[craftingMaterialIndex + 1].transform.GetChild(1).GetComponent<Image>().sprite;
                MakeOneThingPanel.SetActive(true);
            }
        }
        else
        {
            return;
        }
        UIManager.instance.UpdateMaterial();
        UIManager.instance.UpdateCraftTableUI(craftingMaterialIndex);
    }
    public void PutingItem(int index)
    {
        craftingItemIndex = index;
        UIManager.instance.UpdateItemTableUI(index);
    }
    public void CraftingItem()
    {
        GameManager.instance.data.items[craftingItemIndex]++;
        GameManager.instance.data.resources[UIManager.instance.itemTableData.eachItemMaterials[craftingItemIndex].firstMaterialIndex]--;
        GameManager.instance.data.resources[UIManager.instance.itemTableData.eachItemMaterials[craftingItemIndex].secondMaterialIndex]--;
        UIManager.instance.UpdateItem();
        UIManager.instance.UpdateItemTableUI(craftingItemIndex);
        UIManager.instance.UpdateMaterial();
    }
}