using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] GameObject _powerupIndicator;

    public bool _isGameOver = false;

    private Rigidbody _playerRb;
    private GameObject _focalPoint;

    private bool _hasPowerup;
    private float _powerStength = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        var forwardInput = Input.GetAxis("Vertical");

        //forward direction of the focalPoint
        _playerRb.AddForce(_focalPoint.transform.forward * _speed * forwardInput);

        _powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        //if player falls game is over
        if(transform.position.y < -10)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            _hasPowerup = true;
            _powerupIndicator.SetActive(true);            

            Destroy(other.gameObject);

            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);

        _hasPowerup = false;
        _powerupIndicator.SetActive(false);
        //Debug.Log("POWER UP DEACTIVATED...");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && _hasPowerup)
        {
            var enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            var awayFromPlayerDirection = collision.gameObject.transform.position - transform.position;

            //Debug.Log($"Collided with: {collision.gameObject.name} with powerup set to : {_hasPowerup}");

            enemyRb.AddForce(awayFromPlayerDirection * _powerStength, ForceMode.Impulse);
        }
    }
}
