using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 15.0f;
    [SerializeField] private float _leftLimit = -10.0f, _rightLimit = 10.0f, _upLimit, _downLimit;    

    [SerializeField] private GameObject _projectilePrefab;

    private float _horizontalInput, _verticalInput;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        //Horizontal limits
        if (transform.position.x < _leftLimit) transform.position = new Vector3(_leftLimit, transform.position.y, transform.position.z);
        else if (transform.position.x > _rightLimit) transform.position = new Vector3(_rightLimit, transform.position.y, transform.position.z);

        //Vertical limits
        if (transform.position.z < _downLimit) transform.position = new Vector3(transform.position.x, transform.position.y, _downLimit);
        else if (transform.position.z > _upLimit) transform.position = new Vector3(transform.position.x, transform.position.y, _upLimit);

        _horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * _horizontalInput * Time.fixedDeltaTime * _speed);

        _verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * _verticalInput * Time.fixedDeltaTime * _speed);   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_projectilePrefab, transform.position, _projectilePrefab.transform.rotation);
        }        
    }


}
