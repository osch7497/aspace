using UnityEngine;
using UnityEngine.UI;

public class ItemPickUpScript : MonoBehaviour{
    public int ResourceIndex;
    public Vector2 ResourcePickUpRange;
    public Transform gatherUIFolder;
    public GameObject gatherUIFolderPrefab;
    public Collider HitBox;
    public MeshRenderer Renderer;
    public VariousSFX pickUpSFX;
    private Vector3 talantedRotationForce;
    public void Start()
    {
        HitBox = GetComponent<Collider>();
        Renderer = GetComponent<MeshRenderer>();
        talantedRotationForce = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f));

    }
    public int gather()
    {
        HitBox.enabled = false;
        Renderer.enabled = false;
        GameObject uiprefab = Instantiate(gatherUIFolderPrefab, gatherUIFolder);
        int returnResouces = (int)UnityEngine.Random.Range(ResourcePickUpRange.x, ResourcePickUpRange.y);   
        uiprefab.transform.GetChild(0).GetComponent<Text>().text = $"{transform.name} +{returnResouces}";
        pickUpSFX.Play(Camera.main.GetComponent<AudioSource>());
        transform.GetChild(0).GetComponent<ParticleSystem>().Emit(15);
        return returnResouces;
        
    }
    public void Update(){
        transform.Rotate(talantedRotationForce * Time.deltaTime);
    }
}
