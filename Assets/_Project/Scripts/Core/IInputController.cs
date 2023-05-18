using System;
using UnityEngine;

namespace Gisha.HillClimb.Core
{
    public interface IInputController
    {
        event Action<Vector2> ScreenTouchDown;
        event Action<Vector2> ScreenTouchUp;
        void Init();
        void Dispose();
    }
}