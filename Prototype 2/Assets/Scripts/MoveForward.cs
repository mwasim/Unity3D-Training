using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _speed = 40.0f;

    //private void Start()
    //{
    //    Invoke(nameof(AutoDestroy), 1f);
    //}

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * _speed);       
    }

    //private void AutoDestroy()
    //{
    //    Destroy(gameObject);
    //}
}
