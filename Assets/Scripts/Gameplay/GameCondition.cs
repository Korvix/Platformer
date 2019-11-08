using System.Collections.Generic;

namespace Platformer.Gameplay
{
    public class GameCondition
    {
        private List<Resettable> resettables;

        public GameCondition()
        {
            resettables = new List<Resettable>();
        }

        public void AddResettable(Resettable resettable)
        {
            resettables.Add(resettable);
        }

        public void Reset()
        {
            foreach (Resettable resettable in resettables)
            {
                resettable.Reset();
            }
        }
    }
}