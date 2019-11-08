using Platformer.UI;

namespace Platformer.GameSystem
{
    public class UIContext
    {
        private GameResultController gameResultController;
        public GameResultController GameResultController { get => gameResultController; }

        public UIContext()
        {
            gameResultController = new GameResultController();                
        }
    }
}
