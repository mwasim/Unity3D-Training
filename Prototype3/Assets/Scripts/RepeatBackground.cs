using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 _startPos;
    private float _repeatWidth;

    //private PlayerController _palyerController;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;

        //_palyerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //bool isGameOver = _palyerController != null ? _palyerController.IsGameOver : false;

        //if (transform.position.x < _startPos.x - _repeatWidth && isGameOver == false)
        if (transform.position.x < _startPos.x - _repeatWidth)
        {
            transform.position = _startPos;
        }
    }
}
