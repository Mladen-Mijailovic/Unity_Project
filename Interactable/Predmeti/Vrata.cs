using UnityEngine;

public class Vrata : Interactable
{
    [SerializeField]
    private GameObject vrata;
    private bool otvorenaVrata;
    

    protected override void Interact()
    {
        Debug.Log("Interact with " + gameObject.name);
        otvorenaVrata = !otvorenaVrata;
        vrata.GetComponent<Animator>().SetBool("isOpen", otvorenaVrata);
    }
}
