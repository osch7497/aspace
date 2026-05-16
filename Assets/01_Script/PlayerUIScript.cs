using UnityEngine;
using UnityEngine.UI;

public class PlayerUIScript : MonoBehaviour
{
    private GameObject FieldUI;
    private GameObject ItemIndicateUI;
    public PlayerScript playerscript; 
    void Start()
    {
        FieldUI = transform.GetChild(0).gameObject;
        ItemIndicateUI = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 3; i++) {
            Debug.Log($"{i} refresh");
            ItemIndicateUI.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = $"{playerscript.BagPackResource[i]}";
        }
    }
}
