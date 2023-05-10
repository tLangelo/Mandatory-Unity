using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;

    private Rigidbody _body;
    private Vector3 _movementVec;
    private Player _ply;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _ply = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        _movementVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        if (_ply)
        {
            _body.velocity += _movementVec * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(_movementVec);
        }
        
    }
}
