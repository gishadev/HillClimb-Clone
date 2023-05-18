using UnityEngine;

namespace Gisha.HillClimb
{
    public class GameManager : MonoBehaviour
    {
        public static IInputController InputController { get; private set; }

        private void Awake()
        {
            InputController = new InputController();
            InputController.Init();
        }

        private void OnDisable()
        {
            InputController.Dispose();
        }
    }
}