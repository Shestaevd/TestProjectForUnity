using Assets.Scripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.State.Modifiers
{
    public class GenericMoveModifier : StateModifier<Player>
    {
        public override void EnterModify(Player entity)
        {

        }

        public override void ExitModify(Player entity)
        {

        }

        public override void UpdateModify(Player entity)
        {
            float input = Input.GetKey(KeyCode.A) == true ? -1f : Input.GetKey(KeyCode.D) == true ? 1f : 0f;

            float targetSpeed = input * entity.Velocity;

            entity.Rigidbody.velocity = new Vector2(targetSpeed, entity.Rigidbody.velocity.y);
        }
    }
}