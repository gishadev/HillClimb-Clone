using UnityEngine;

namespace Gisha.HillClimb.World
{
    public class ParallaxBG : MonoBehaviour
    {
        [SerializeField] private Transform target;

        [Header("Layer Setting")]
        [SerializeField]
        private float[] layerSpeeds;

        [SerializeField] private GameObject[] layerObjects;

        private float[] _startPos;
        private float _boundSizeX;
        private float _sizeX;
        private GameObject _layerZero;

        private void Start()
        {
            if (target == null)
                target = Camera.main.transform;

            _startPos = new float[layerObjects.Length];
            _boundSizeX = layerObjects[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
            _sizeX = layerObjects[0].transform.localScale.x;
            for (int i = 0; i < layerObjects.Length; i++)
                _startPos[i] = target.position.x;
        }

        private void Update()
        {
            for (int i = 0; i < layerObjects.Length; i++)
            {
                float temp = target.position.x * (1 - layerSpeeds[i]);
                float distance = target.position.x * layerSpeeds[i];
                layerObjects[i].transform.position = new Vector2(_startPos[i] + distance, transform.position.y);

                if (temp > _startPos[i] + _boundSizeX * _sizeX)
                    _startPos[i] += _boundSizeX * _sizeX;
                else if (temp < _startPos[i] - _boundSizeX * _sizeX) _startPos[i] -= _boundSizeX * _sizeX;
            }
        }
    }
}