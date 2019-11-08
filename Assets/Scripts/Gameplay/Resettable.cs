using Platformer.GameSystem;
using UnityEngine;

namespace Platformer.Gameplay
{
    public abstract class Resettable : MonoBehaviour
    {
        protected void Awake()
        {
            GameContext.Instance.GameCondition.AddResettable(this);
        }

        public abstract void Reset();
    }
}