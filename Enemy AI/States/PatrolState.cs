using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIdex;
    public float waitTimer;
    public override void Enter()
    {

    }
    public override void Performe()
    {
        PatrolCycle();
    }
     
    public override void Exit()
    {

    }

    public void PatrolCycle() 
    {
        if (enemy.Agent.remainingDistance < 0.2f) {
            waitTimer += Time.deltaTime;
            if (waitTimer > .75f)
            {

                if (waypointIdex < enemy.path.waypoints.Count - 1)
                {
                    waypointIdex++;
                }
                else
                {
                    waypointIdex = 0;
                }
                enemy.Agent.SetDestination(enemy.path.waypoints[waypointIdex].position);
                waitTimer = 0;
            }
        }
    }

}

