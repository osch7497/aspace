using UnityEngine;

public class MoveConnect : MonoBehaviour
{
    Transform target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            target = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
        }
    }
    Vector3 bfp;
    private void Start()
    {
        bfp = transform.position;
    }
    void Update()
    {
        if (target != null) {
            target.transform.position += transform.position - bfp;
        }
        bfp = transform.position;
    }
}
