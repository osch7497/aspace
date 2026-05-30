using UnityEngine;

public class BreakManager : MonoBehaviour
{
    public static BreakManager instance;
    public bool[] error = new bool[4];
    public GameObject[] systemButton = new GameObject[4];
    public float timer = 0;
    public GameObject errorPrefab;
    public void Awake()
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
    public void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            timer = 0;
            int randFirst = Random.Range(1, 101);
            int randSecond = Random.Range(1, 101);
            int randThird = Random.Range(1, 101);
            if (randFirst <= 3)
            {
                if (!error[0])
                {
                    error[0] = true;
                    var errorButton = Instantiate(errorPrefab, Vector3.zero, Quaternion.identity);
                    errorButton.transform.SetParent(systemButton[0].transform, false);
                }
            }
            if(randSecond <= 2)
            {
                if (!error[1])
                {
                    error[1] = true;
                    var errorButton = Instantiate(errorPrefab, Vector3.zero, Quaternion.identity);
                    errorButton.transform.SetParent(systemButton[1].transform, false);
                }
            }
            if(randThird <= 1)
            {
                if (!error[3])
                {
                    error[3] = true;
                    var errorButton = Instantiate(errorPrefab, Vector3.zero, Quaternion.identity);
                    errorButton.transform.SetParent(systemButton[3].transform, false);
                }
            }
        }
    }
    public void ResolveError(int index)
    {
        error[index] = false;
    }
}