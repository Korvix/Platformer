using UnityEngine;

namespace Platformer.Gameplay
{
    public class PlayerInfo : Resettable
    {
        [SerializeField]
        private PlayerType playerType;
        private Vector3 startPosition;

        private new void Awake()
        {
            base.Awake();
            startPosition = transform.position;
        }

        public PlayerType GetPlayerType()
        {
            return playerType;
        }

        public override void Reset()
        {
            transform.position = startPosition;
        }
    }
}