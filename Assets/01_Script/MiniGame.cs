using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    public Slider slider;
    public float duration = 2f;
    private float timer = 0f;
    public float safeAreaSizeRate= 60;
    public bool isSafeArea = false;
    public GameObject handle;
    public GameObject safeArea;

    private void Start()
    {
        safeArea.GetComponent<RectTransform>().sizeDelta = new Vector2(safeAreaSizeRate * 10, 25);
    }

    void Update()
    {
        if (isSafeArea)
        {
            Debug.Log("Safe Area!");
        }
        timer += Time.deltaTime;

        float t = Mathf.PingPong(timer, duration) / duration;

        slider.value = Mathf.SmoothStep(0f, 1f, t);
        if(slider.value * 100 >= (100-safeAreaSizeRate)/2 && slider.value * 100 <= 100 - (100 - safeAreaSizeRate) / 2)
        {
            isSafeArea = true;
            handle.GetComponent<Image>().color = Color.green;
        }
        else
        {
            isSafeArea = false;
            handle.GetComponent<Image>().color = Color.white;
        }
    }
    public void PushStopButton()
    {
        if (isSafeArea)
        {

        }
    }
}
