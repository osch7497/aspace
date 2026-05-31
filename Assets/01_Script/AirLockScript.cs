using UnityEngine;

public class AirLockScript : MonoBehaviour
{
    private Vector3 opennedPos, closedPos,targetPos;
    public void Awake()
    {
        closedPos = transform.localPosition;
        opennedPos = closedPos - new Vector3(0f,0f, 3.95f);
        targetPos = closedPos;
    }
    private void Update(){
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other){
        targetPos = opennedPos;
    }
    private void OnTriggerExit(Collider other)
    {
        targetPos = closedPos;
    }
}
