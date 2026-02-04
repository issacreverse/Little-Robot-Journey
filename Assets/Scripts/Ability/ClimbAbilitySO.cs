using UnityEngine;

public class ClimbAbilitySO : AbilitySO
{
    public override void OnEquip(Robot robot) => robot.climb.canClimb = true;
    public override void OnUnequip(Robot robot) => robot.climb.canClimb = false;
}
