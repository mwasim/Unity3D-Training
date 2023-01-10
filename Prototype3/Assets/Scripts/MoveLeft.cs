using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 30;
    private float _leftBound = -15f;

    private PlayerController _palyerController;

    // Start is called before the first frame update
    void Start()
    {
        _palyerController = FindObjectOfType<PlayerController>();
    }

    private void FixedUpdate()
    {
        bool isGameOver = _palyerController != null ? _palyerController.IsGameOver : false;

        if (isGameOver == false)
        {
            //if speed key is pressed, speed is increased twice
            var movementSpeed = Input.GetKeyDown(KeyCode.S) ? _speed * 2 : _speed;

            transform.Translate(Vector3.left * Time.fixedDeltaTime * movementSpeed);
        }

        if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
