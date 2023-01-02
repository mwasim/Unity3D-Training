using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _palyer;
    [SerializeField] private Vector3 _cameraOffset = new Vector3(0, 10, -20);


    //LateUpdate to add smoothness
    private void LateUpdate()
    {
        transform.position = _palyer.transform.position + _cameraOffset;
    }

    //private void FixedUpdate()
    //{
    //    //transform.position = _palyer.transform.position + _cameraOffset;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
