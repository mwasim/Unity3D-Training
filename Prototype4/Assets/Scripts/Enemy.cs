using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _enemyRb;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //var direction = _player.transform.position - transform.position; //With this the greater the distance, the greater will be the magnitude.
        //Take make the magnitude same, we normalize it,  so that same amount of force is applied regardless of the distance of the enemy from the player
        var lookDirection = (_player.transform.position - transform.position).normalized;

        _enemyRb.AddForce(lookDirection * _speed);
    }
}
