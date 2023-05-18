using UnityEngine;
using UnityEngine.SceneManagement;

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

        private void OnEnable()
        {
            HeadColliderHandler.HeadCollidedWithGround += ReloadGame;
        }

        private void OnDisable()
        {
            HeadColliderHandler.HeadCollidedWithGround -= ReloadGame;
            InputController.Dispose();
        }

        private void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}