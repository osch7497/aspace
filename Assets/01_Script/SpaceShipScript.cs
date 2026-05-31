using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

public class SpaceShipScript : MonoBehaviour
{
    public float Speed;
    public float gravity;
    public SplineAnimate spline;
    public GameObject[] OrePrefabs;
    public Transform ResourceFolder;
    // Update is called once per frame]
    public void SummonOre(int count){
        for(int i = 0; i < count; i++){
            int spawnedOre = Random.Range(0, OrePrefabs.Length);
            GameObject newOre = Instantiate(OrePrefabs[spawnedOre], ResourceFolder);
            newOre.name = OrePrefabs[spawnedOre].name;
            newOre.transform.position = transform.position + transform.forward * 200f + transform.right * Random.Range(-25f,25f) + transform.up * Random.Range(-25f, 25f);
        }
    }
    float lastOreSummon;
    void Update()
    {
        spline.MaxSpeed = Speed;
        if (lastOreSummon <= Time.time) {
            SummonOre(3);
            lastOreSummon = Time.time + Random.Range(0.3f,5f);
        }    
    }
}