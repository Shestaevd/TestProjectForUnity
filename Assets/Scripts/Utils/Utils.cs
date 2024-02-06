using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class Utils
    {
        public class UnityUtils
        {
            public bool IsColliderTouchingGround(Collider2D collider, LayerMask lm, float extraRaycastRange = 0.1f)
            {
                return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, extraRaycastRange, lm).collider != null;
            }

            public T GetChildComponentByName<T>(GameObject gm, string name) where T : Component
            {
                foreach (T component in gm.GetComponentsInChildren<T>(true))
                {
                    if (component.gameObject.name == name)
                    {
                        return component;
                    }
                }
                return null;
            }
        }

        public static UnityUtils Unity = new UnityUtils();
    }
}