using System;
using UnityEngine;
using UnityEngine.U2D;

namespace Gisha.HillClimb
{
    [ExecuteInEditMode]
    public class ProceduralEnvironmentGenerator : MonoBehaviour
    {
        [SerializeField] private SpriteShapeController _shapeController;

        [SerializeField] private float levelLength = 30f;
        [SerializeField] private float xMultiplier = 2f;
        [SerializeField] private float yMultiplier = 2f;
        [SerializeField, Range(0f, 1f)] private float smoothness = 0.5f;
        [SerializeField] private float noiseStep = 0.5f;
        [SerializeField] private float bottom = 10f;

        private Vector3 _lastPos;

        private void OnValidate()
        {
            _shapeController.spline.Clear();
            GenerateTerrain();
        }

        private void GenerateTerrain()
        {
            for (int i = 0; i < levelLength; i++)
            {
                _lastPos = transform.position +
                           new Vector3(i * xMultiplier, Mathf.PerlinNoise(0, i * noiseStep) * yMultiplier);
                _shapeController.spline.InsertPointAt(i, _lastPos);

                if (i != 00 && Math.Abs(i - (levelLength - 1)) > 0.1f)
                {
                    _shapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                    _shapeController.spline.SetLeftTangent(i, Vector3.left * xMultiplier * smoothness);
                    _shapeController.spline.SetRightTangent(i, Vector3.right * xMultiplier * smoothness);
                }
            }

            _shapeController.spline.InsertPointAt((int) levelLength,
                new Vector3(_lastPos.x, transform.position.y - bottom));
            _shapeController.spline.InsertPointAt((int) levelLength + 1,
                new Vector3(transform.position.x, transform.position.y - bottom));
        }
    }
}