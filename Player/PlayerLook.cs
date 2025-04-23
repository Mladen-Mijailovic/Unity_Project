using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    private float yRotation = 0f;

    public float xSensetivity = 30f;
    public float ySensetivity = 30f;

    public float topClamp = -80f;
    public float bottomClamp = 50f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ProcessLook(Vector2 input) {
        float mouseX = input.x;
        float mouseY = input.y;

        //racuna rotaciju kamere
        xRotation -= (mouseY * Time.deltaTime) * ySensetivity;
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        //primena rotacije
        cam.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);

        //rotacije levo i desno
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensetivity);
    }
}
