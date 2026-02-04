using UnityEngine;

public class Robot : MonoBehaviour
{
   public RobotStats stats;
   public PlayerController movement;
   public RobotCombat combat;
   public RobotClimb climb;
   
   private void Reset()
   {
        stats = GetComponent<RobotStats>();
        movement = GetComponent<PlayerController>();
        combat = GetComponent<RobotCombat>();   
        climb = GetComponent<RobotClimb>();
   }
   void Awake()
   {
        if(stats == null) stats = GetComponent<RobotStats>();
        if(movement == null) movement = GetComponent<PlayerController>();  
        if(combat == null) combat = GetComponent<RobotCombat>();
        if(climb == null) climb = GetComponent<RobotClimb>();
   }
}
