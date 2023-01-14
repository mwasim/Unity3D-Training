using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;

    [SerializeField] private float _zBound = -10f;

    private Rigidbody _rbObject;

    // Start is called before the first frame update
    void Start()
    {
        _rbObject = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rbObject.AddForce(Vector3.forward * -_speed);

        if (transform.position.z < _zBound) Destroy(gameObject);
    }
}
