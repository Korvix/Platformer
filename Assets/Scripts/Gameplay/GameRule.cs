using Platformer.GameSystem;
using Platformer.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class GameRule
    {
        private List<GoalController> goalControllers;
        private GameTime gameTime;
        private GameResultController gameResultController;

        public GameRule()
        {
            goalControllers = new List<GoalController>();
            gameResultController = GameContext.Instance.UIContext.GameResultController;
        }

        public void AddGoalController(GoalController goalController)
        {
            goalControllers.Add(goalController);
        }

        public void RegisterGameTime(GameTime gameTime)
        {
            this.gameTime = gameTime;
        }

        public void CheckControllers()
        {
            bool allActivated = true;
            foreach (GoalController goalController in goalControllers)
            {
                if (!goalController.IsActivated())
                {
                    allActivated = false;
                }
            }
            if (allActivated)
            {
                foreach (GoalController goalController in goalControllers)
                {
                    goalController.TurnOffPlayerMovement();
                    Debug.Log("Winner");
                }
                Debug.Log(gameTime.GetTime());
                gameResultController.ShowEndScreen(gameTime.GetTime());
            }
        }
    }
}