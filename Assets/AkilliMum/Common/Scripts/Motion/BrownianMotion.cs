using AkilliMum.Math;
using UnityEngine;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace AkilliMum.Motion
{
    [AddComponentMenu("Akilli Mum/Motion/Brownian Motion")]
    public class BrownianMotion : MonoBehaviour
    {
        #region Editable Properties

        [SerializeField] bool _enablePositionNoise = true;
        [SerializeField] bool _enableRotationNoise = true;

        [SerializeField] float _positionFrequency = 0.2f;
        [SerializeField] float _rotationFrequency = 0.2f;

        [SerializeField] float _positionAmplitude = 0.5f;
        [SerializeField] float _rotationAmplitude = 10.0f;

        [SerializeField] Vector3 _positionScale = Vector3.one;
        [SerializeField] Vector3 _rotationScale = new Vector3(1, 1, 0);

        [SerializeField, Range(0, 8)] int _positionFractalLevel = 3;
        [SerializeField, Range(0, 8)] int _rotationFractalLevel = 3;

        #endregion

        #region Public Properties And Methods

        public bool enablePositionNoise {
            get { return _enablePositionNoise; }
            set { _enablePositionNoise = value; }
        }

        public bool enableRotationNoise {
            get { return _enableRotationNoise; }
            set { _enableRotationNoise = value; }
        }

        public float positionFrequency {
            get { return _positionFrequency; }
            set { _positionFrequency = value; }
        }

        public float rotationFrequency {
            get { return _rotationFrequency; }
            set { _rotationFrequency = value; }
        }

        public float positionAmplitude {
            get { return _positionAmplitude; }
            set { _positionAmplitude = value; }
        }

        public float rotationAmplitude {
            get { return _rotationAmplitude; }
            set { _rotationAmplitude = value; }
        }

        public Vector3 positionScale {
            get { return _positionScale; }
            set { _positionScale = value; }
        }

        public Vector3 rotationScale {
            get { return _rotationScale; }
            set { _rotationScale = value; }
        }

        public int positionFractalLevel {
            get { return _positionFractalLevel; }
            set { _positionFractalLevel = value; }
        }

        public int rotationFractalLevel {
            get { return _rotationFractalLevel; }
            set { _rotationFractalLevel = value; }
        }

        public void Rehash()
        {
            for (var i = 0; i < 6; i++)
                _time[i] = Random.Range(-10000.0f, 0.0f);
        }

        #endregion

        #region Private Members

        const float _fbmNorm = 1 / 0.75f;

        Vector3 _initialPosition;
        Quaternion _initialRotation;
        float[] _time;

        #endregion

        #region MonoBehaviour Functions

        // ReSharper disable once UnusedMember.Local
        void Start()
        {
            _time = new float[6];
            Rehash();
        }

        // ReSharper disable once UnusedMember.Local
        void OnEnable()
        {
            _initialPosition = transform.localPosition;
            _initialRotation = transform.localRotation;
        }

        // ReSharper disable once UnusedMember.Local
        void Update()
        {
            var dt = Time.deltaTime;

            if (_enablePositionNoise)
            {
                for (var i = 0; i < 3; i++)
                    _time[i] += _positionFrequency * dt;

                var n = new Vector3(
                    Perlin.Fbm(_time[0], _positionFractalLevel),
                    Perlin.Fbm(_time[1], _positionFractalLevel),
                    Perlin.Fbm(_time[2], _positionFractalLevel));

                n = Vector3.Scale(n, _positionScale);
                n *= _positionAmplitude * _fbmNorm;

                transform.localPosition = _initialPosition + n;
            }

            if (_enableRotationNoise)
            {
                for (var i = 0; i < 3; i++)
                    _time[i + 3] += _rotationFrequency * dt;

                var n = new Vector3(
                    Perlin.Fbm(_time[3], _rotationFractalLevel),
                    Perlin.Fbm(_time[4], _rotationFractalLevel),
                    Perlin.Fbm(_time[5], _rotationFractalLevel));

                n = Vector3.Scale(n, _rotationScale);
                n *= _rotationAmplitude * _fbmNorm;

                transform.localRotation =
                    Quaternion.Euler(n) * _initialRotation;
            }
        }

        #endregion
    }
}
