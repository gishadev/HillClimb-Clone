using System;
using Gisha.HillClimb.Core;
using UnityEngine;

namespace Gisha.HillClimb
{
    public class HeadColliderHandler : MonoBehaviour
    {
        public static event Action HeadCollidedWithGround;

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.collider.CompareTag(Constants.GROUND_NAME))
                HeadCollidedWithGround?.Invoke();
        }
    }
}