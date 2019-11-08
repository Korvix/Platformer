using Platformer.GameSystem;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class GameTime : Resettable
    {
        private float time;

        private new void Awake()
        {
            base.Awake();
            GameContext.Instance.GameRule.RegisterGameTime(this);
        }

        private void Update()
        {
            time += Time.deltaTime;
        }

        public float GetTime()
        {
            return time;
        }

        public override void Reset()
        {
            time = 0f;
        }
    }
}