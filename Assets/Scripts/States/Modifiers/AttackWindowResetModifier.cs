using Assets.Scripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.State.Modifiers
{
    public class AttackWindowResetModifier : StateModifier<Player>
    {
        public override void EnterModify(Player entity)
        {

        }

        public override void ExitModify(Player entity)
        {

        }

        public override void UpdateModify(Player entity)
        {
            if (entity.AttackWindowTimer > 0) entity.AttackWindowTimer -= Time.deltaTime;
        }
    }
}