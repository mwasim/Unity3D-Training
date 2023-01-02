using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _speed = 20; //move 20 meters per second
    [SerializeField] private int _turnSpeed = 10; //move 20 meters per second

    private float _horizontalInput,  _forwardInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.fixedDeltaTime * _speed * _forwardInput);

        //transform.Translate(Vector3.right * Time.fixedDeltaTime * _turnSpeed * _horizontalInput);

        //Using  rotate method  will take the turn  like a real car
        var direction = Vector3.up; //TO Y AXIS - For example select the vehicle in the scene view choose Y pivot and  rotating on Y axis shows the right direction to take turn
        var angleToRotate = Time.fixedDeltaTime * _turnSpeed * _horizontalInput; //we're moving in delta time at the speed of turnspeed and moving on angle created on pressing horizontal input
        transform.Rotate(direction, angleToRotate);
    }

    // Update is called once per frame
    void Update()
    {
        //Move the vehicle forward
        //transform.Translate(0, 0, 1);
        //transform.Translate(Vector3.forward); //equivalent

        //control the speed
        //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }
}
