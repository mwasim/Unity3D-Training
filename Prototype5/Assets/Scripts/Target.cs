using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int _pointValue;
    [SerializeField] ParticleSystem _explosionParticle;

    private Rigidbody _targetRb;
    private GameManager _gameManager;

    private float _minSpeed = 12f, _maxSpeed = 16f;
    private float _maxTorque = 10;
    private float _xPosRange = 4;
    private float _ySpawnPos = -6;

    // Start is called before the first frame update
    void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        _gameManager = FindObjectOfType<GameManager>();

        _targetRb.AddForce(RandomForce, ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque, RandomTorque, RandomTorque);

        transform.position = RandomSpawnPosition;
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
        _gameManager.UpdateScore(_pointValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private Vector3 RandomForce => Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    private float RandomTorque => Random.Range(-_maxTorque, _maxTorque);
    private Vector3 RandomSpawnPosition => new Vector3(Random.Range(-_xPosRange, _xPosRange), _ySpawnPos);
}
