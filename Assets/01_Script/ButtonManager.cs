using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
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
        UIManager.instance.UpdateCraftTableUI(index);
    }
}