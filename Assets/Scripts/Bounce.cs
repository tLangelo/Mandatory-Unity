using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Rigidbody body;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Player ply = other.gameObject.GetComponent<Player>();
            if (ply is not null)
            {
                /*var deltaPos = body.transform.position - ply.Position;
                deltaPos.y = 0;
                var forward = deltaPos.normalized;
                body.AddForce(forward * ply.Speed, ForceMode.Impulse);
                */
                
            }
        }
    }
}
