using UnityEngine;
//Ovu klasu ce nasledjivati klase koje sluze za interakciju
public abstract class Interactable : MonoBehaviour
{
    //Dodaje ili uklanja InteractionEvents komponente za neki GameObject
    public bool useEvents;
    [SerializeField]
    //ovo ce se prikazivati igracu kada gleda na objekat sa kojim moze da interaktuje
    public string promptPoruka;


    public virtual string OnLook() {
        return promptPoruka;
    }
    public void BaseInteract() {
        if (useEvents) {
            GetComponent<InteractionEvent>().onInteract.Invoke();
        }
        Interact();
    }
    protected virtual void Interact() { }
}
