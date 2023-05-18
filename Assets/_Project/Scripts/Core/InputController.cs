using System;
using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

namespace Gisha.HillClimb.Core
{
    public class InputController : IInputController
    {
        public event Action<Vector2> ScreenTouchDown;
        public event Action<Vector2> ScreenTouchUp;

        public void Init()
        {
            EnhancedTouch.EnhancedTouchSupport.Enable();
            EnhancedTouch.TouchSimulation.Enable();

            EnhancedTouch.Touch.onFingerDown += OnFingerDown;
            EnhancedTouch.Touch.onFingerUp += OnFingerUp;
        }

        public void Dispose()
        {
            EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
            EnhancedTouch.Touch.onFingerUp -= OnFingerUp;

            EnhancedTouch.EnhancedTouchSupport.Disable();
            EnhancedTouch.TouchSimulation.Disable();
        }

        private void OnFingerUp(EnhancedTouch.Finger finger)
        {
            Vector2 screenPos = new Vector2(finger.screenPosition.x / Screen.width,
                finger.screenPosition.y / Screen.height);
            ScreenTouchUp?.Invoke(screenPos);
        }

        private void OnFingerDown(EnhancedTouch.Finger finger)
        {
            Vector2 screenPos = new Vector2(finger.screenPosition.x / Screen.width,
                finger.screenPosition.y / Screen.height);
            ScreenTouchDown?.Invoke(screenPos);
        }
    }
}