public abstract class BaseState 
{
    //instance of enemy class
    public Enemy enemy;
    //instance of statemachine class
    public StateMachine stateMachine;
    public abstract void Enter();
    public abstract void Performe();
    public abstract void Exit();
}