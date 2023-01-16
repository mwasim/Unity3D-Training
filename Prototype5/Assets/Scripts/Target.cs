using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _targetRb;

    private float _minSpeed = 12f, _maxSpeed = 16f;
    private float _maxTorque = 10;
    private float _xPosRange = 4;
    private float _ySpawnPos = -6;

    // Start is called before the first frame update
    void Start()
    {
        _targetRb = GetComponent<Rigidbody>();

        _targetRb.AddForce(RandomForce, ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque, RandomTorque, RandomTorque);

        transform.position = RandomSpawnPosition;
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private Vector3 RandomForce => Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    private float RandomTorque => Random.Range(-_maxTorque, _maxTorque);
    private Vector3 RandomSpawnPosition => new Vector3(Random.Range(-_xPosRange, _xPosRange), _ySpawnPos);
}
