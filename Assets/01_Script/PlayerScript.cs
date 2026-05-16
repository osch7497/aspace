using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public Transform cam;//cam
    public LayerMask ItemLayer;
    public GameObject ItemUI;
    public int[] BagPackResource;
    private newInputSystem inputs;
    private float nowrotate;
    Rigidbody rb;// rigidbody
    private void Awake() {
        nowrotate = 0f;
        inputs = new newInputSystem();
        BagPackResource = new int[3];
    }
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable(){inputs.Enable(); }
    private void OnDisable() { inputs.Disable(); }
    // Update is called once per frame
    void Update(){
        Vector2 MouseMove = inputs.Player.Look.ReadValue<Vector2>();
        Vector3 Move = inputs.Player.Move.ReadValue<Vector2>();
        Move = new Vector3(Move.x, inputs.Player.VerticalMove.ReadValue<float>(), Move.y) * moveSpeed;

        Debug.Log(MouseMove);// - 화면 움직임 
        nowrotate += -MouseMove.y;
        if(Mathf.Abs(nowrotate) <= 80f)
            cam.Rotate(-MouseMove.y, 0, 0);//- 상하 -  [-]가 붙은 이유는 위를 볼려면 카메라의 x축을 위로 돌려야함 ( 각도를 더 줄여야한다 )
        else
            if(nowrotate > 0f) { 
                cam.Rotate(-MouseMove.y - (nowrotate - 80f), 0, 0);//- 상하 -  [-]가 붙은 이유는 위를 볼려면 카메라의 x축을 위로 돌려야함 ( 각도를 더 줄여야한다 )
                nowrotate = 80f;
            }
            else if (nowrotate < 0f) { 
                cam.Rotate(-MouseMove.y - (nowrotate - -80f), 0, 0);//- 상하 -  [-]가 붙은 이유는 위를 볼려면 카메라의 x축을 위로 돌려야함 ( 각도를 더 줄여야한다 )
                nowrotate = -80f;
            }

            transform.Rotate(0, MouseMove.x, 0);//- 좌우 -

        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, transform.forward * Move.z + transform.right * Move.x + transform.up * Move.y, Time.deltaTime * 10f);
        RaycastHit ray;
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 10f);
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out ray, 10f, ItemLayer)){
            ItemUI.SetActive(true);
            ItemUI.transform.GetChild(0).GetComponent<Text>().text = $"{ray.collider.name} 줍기";
            ItemUI.transform.position = Camera.main.WorldToScreenPoint(ray.collider.transform.position + Vector3.up);
            if (Input.GetKeyDown(KeyCode.E)){
                ItemPickUpScript ips = ray.collider.GetComponent<ItemPickUpScript>();
                BagPackResource[ips.ResourceIndex] += (int)Random.Range(ips.ResourcePickUpRange.x, ips.ResourcePickUpRange.y);
                Debug.Log($"resource {ips.ResourceIndex}+");
            }
        }
        else{
            ItemUI.SetActive(false);
        }
    }
}
