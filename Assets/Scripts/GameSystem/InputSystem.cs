using UnityEngine;

namespace Platformer.GameSystem
{
    public class InputSystem : MonoBehaviour
    {
        private InputData inputData;

        private void Start()
        {
            inputData = GameContext.Instance.InputData;
        }

        private void Update()
        {
            inputData.leftKeyPressed = Input.GetKey(KeyCode.LeftArrow);
            inputData.rightKeyPressed = Input.GetKey(KeyCode.RightArrow);
            inputData.upKeyPressed = Input.GetKey(KeyCode.UpArrow);
            inputData.upKeyDown = Input.GetKeyDown(KeyCode.UpArrow);
            inputData.upKeyUp = Input.GetKeyUp(KeyCode.UpArrow);
            inputData.downKeyPressed = Input.GetKey(KeyCode.DownArrow);
        }
    }
}