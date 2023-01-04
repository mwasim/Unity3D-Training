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
            transform.Translate(Vector3.left * Time.fixedDeltaTime * _speed);
        }

        if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
