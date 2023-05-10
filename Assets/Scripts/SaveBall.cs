using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBall : MonoBehaviour
{
    public AudioClip saveSound;
    private AudioSource _audioSource;
    
    public Transform ball;
    public Vector3 resetPos;
    public Rigidbody ballRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _audioSource.PlayOneShot(saveSound);
            
            ball.position = resetPos;
            
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
