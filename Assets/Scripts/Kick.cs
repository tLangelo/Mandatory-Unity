using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public float kickForce = 10f;
    public float attachDistance = 2f;
    public Transform kickOrigin;
    public Transform ballAttachPoint;
    private bool _hasBall;
    
    public AudioClip ballHitSound;
    private AudioSource _audioSource;

    private Rigidbody ballRigidbody;

    void Start()
    {
        ballRigidbody = null;
        _hasBall = false;
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball") && !_hasBall)
        {
            ballRigidbody = other.gameObject.GetComponent<Rigidbody>();
            ballRigidbody.isKinematic = false;
            ballRigidbody.transform.SetParent(ballAttachPoint);
            ballRigidbody.transform.localPosition = Vector3.zero;
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
            _hasBall = true;
        }
    }

    

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ballRigidbody != null)
        {
            ballRigidbody.isKinematic = false;
            ballRigidbody.transform.SetParent(null);
            ballRigidbody.AddForce(kickOrigin.forward * kickForce, ForceMode.Impulse);
            _audioSource.PlayOneShot(ballHitSound);
            _hasBall = false;
            //ballRigidbody = null;
        }
    }
}
