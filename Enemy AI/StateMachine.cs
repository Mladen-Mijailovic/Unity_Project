using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    //property for patrol state
    public PatrolState patrolState;
    public void Initialise() 
    {
        patrolState = new PatrolState();
        changeState( patrolState );
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null) 
        {
            activeState.Performe();
        }
    }
    public void changeState(BaseState newState) 
    {
        //check if activeState != null
        if (activeState != null) 
        {
            activeState.Exit();
        }
        //change to a new state
        activeState = newState;

        if (activeState != null) 
        {
            //setup new state
            activeState.stateMachine = this;
            //assign state enemy class
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();

        }
    }
}
