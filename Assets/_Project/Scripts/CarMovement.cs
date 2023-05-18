using UnityEngine;

namespace Gisha.HillClimb
{
    public class CarMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 150f;
        [SerializeField] private float rotationSpeed = 300f;

        [SerializeField] private Rigidbody2D frontWheelBody;
        [SerializeField] private Rigidbody2D backWheelBody;
        [SerializeField] private Rigidbody2D carBody;

        private float _hInput;


        private void Awake()
        {
            GameManager.InputController.ScreenTouchDown += OnScreenTouchDown;
            GameManager.InputController.ScreenTouchUp += OnScreenTouchUp;
        }

        private void OnDisable()
        {
            GameManager.InputController.ScreenTouchDown -= OnScreenTouchDown;
            GameManager.InputController.ScreenTouchUp -= OnScreenTouchUp;
        }

        private void FixedUpdate()
        {
            MoveCar();
        }

        private void OnScreenTouchDown(Vector2 screenPos)
        {
            Debug.Log(screenPos);
            
            if (screenPos.x > 0.5f)
                _hInput = 1f;
            else
                _hInput = -1f;
        }

        private void OnScreenTouchUp(Vector2 screenPos)
        {
            _hInput = 0f;
        }

        private void MoveCar()
        {
            frontWheelBody.AddTorque(-_hInput * movementSpeed * Time.fixedDeltaTime);
            backWheelBody.AddTorque(-_hInput * movementSpeed * Time.fixedDeltaTime);
            carBody.AddTorque(_hInput * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}