using Gisha.HillClimb.Player;
using Gisha.HillClimb.World;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gisha.HillClimb.Core
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
            WinBeam.PlayerEnteredWinBeam += ReloadGame;
        }

        private void OnDisable()
        {
            HeadColliderHandler.HeadCollidedWithGround -= ReloadGame;
            WinBeam.PlayerEnteredWinBeam -= ReloadGame;
            InputController.Dispose();
        }

        private void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}