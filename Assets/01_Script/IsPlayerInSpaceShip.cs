using UnityEngine;

public class IsPlayerInSpaceShip : MonoBehaviour
{
    public GameObject mainUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().enabled = false;
            other.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            mainUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().enabled = true;
            mainUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
