using UnityEngine;

namespace Gisha.HillClimb.Player
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform targetToFollow;
        [SerializeField] private float followSpeed = 1f;

        private void Update()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            Vector3 newPosition =
                new Vector3(targetToFollow.position.x, targetToFollow.position.y, transform.position.z);
            transform.position =
                Vector3.Lerp(transform.position, newPosition, Time.deltaTime * followSpeed);
        }
    }
}