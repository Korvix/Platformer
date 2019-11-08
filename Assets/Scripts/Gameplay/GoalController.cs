using Platformer.GameSystem;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class GoalController : Resettable
    {
        [SerializeField]
        private PlayerType playerType;
        private PlayerInfo playerInfo;
        private PlayerMovementController playerMovementController;
        private GameRule gameRule;
        private bool activated;

        private new void Awake()
        {
            base.Awake();
            gameRule = GameContext.Instance.GameRule;
            gameRule.AddGoalController(this);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            playerInfo = collision.GetComponent<PlayerInfo>();
            if (playerInfo && playerInfo.GetPlayerType() == playerType)
            {
                activated = true;
                playerMovementController = collision.GetComponent<PlayerMovementController>();
                gameRule.CheckControllers();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            playerInfo = collision.GetComponent<PlayerInfo>();
            if (playerInfo && playerInfo.GetPlayerType() == playerType)
            {
                activated = false;
            }
        }

        public void TurnOffPlayerMovement()
        {
            playerMovementController.enabled = false;
        }

        public bool IsActivated()
        {
            return activated;
        }

        public override void Reset()
        {
            activated = false;
            playerMovementController.enabled = true;
        }
    }
}