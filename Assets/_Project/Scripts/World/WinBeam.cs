using System;
using Gisha.HillClimb.Core;
using UnityEngine;

namespace Gisha.HillClimb.World
{
    public class WinBeam : MonoBehaviour
    {
        public static event Action PlayerEnteredWinBeam;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Constants.PLAYER_TAG_NAME))
                PlayerEnteredWinBeam?.Invoke();
        }
    }
}