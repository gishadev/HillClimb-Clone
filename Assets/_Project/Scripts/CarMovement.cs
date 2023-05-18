using System;
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

        private void Update()
        {
            _hInput = Input.GetAxisRaw("Horizontal");
        }

        private void FixedUpdate()
        {
            frontWheelBody.AddTorque(-_hInput * movementSpeed * Time.fixedDeltaTime);
            backWheelBody.AddTorque(-_hInput * movementSpeed * Time.fixedDeltaTime);
            carBody.AddTorque(_hInput * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}