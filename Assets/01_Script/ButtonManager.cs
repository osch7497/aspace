using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    public int craftingMaterialIndex;
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
            int value = Random.Range(0, 10);
            if (value < 3)
                GameManager.instance.data.resources[9]++;
        }
        else if (craftingMaterialIndex % 3 == 1 && craftingMaterialIndex < 9 && GameManager.instance.data.resources[craftingMaterialIndex] >= 2)
        {
            GameManager.instance.data.resources[craftingMaterialIndex] -= 2;
            GameManager.instance.data.resources[craftingMaterialIndex + 1]++;
            int value = Random.Range(0, 10);
            if (value < 3)
                GameManager.instance.data.resources[10]++;
        }
        else
        {
            return;
        }
        UIManager.instance.UpdateMaterial();
        UIManager.instance.UpdateCraftTableUI(craftingMaterialIndex);
    }
}