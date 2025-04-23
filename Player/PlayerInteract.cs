using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputMenager inputMenager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputMenager = GetComponent<InputMenager>();
    }

    // Update is called once per frame
    void Update()
    {
        //brisanje poruka
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance, mask)) {
            if (hitInfo.collider.GetComponent<Interactable>() != null) {
                Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptPoruka);
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

                playerUI.UpdateText(interactable.promptPoruka);

                if (inputMenager.onFoot.Interact.triggered) {
                    interactable.BaseInteract();
                }
            }
        };
    }
}
