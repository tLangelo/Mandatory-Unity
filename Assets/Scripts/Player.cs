
using System;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  public float speed = 10.0f;
  public float sprintMultiplier = 2.0f;
  public float jumpHeight = 2.0f;
  private bool isGrounded = true;
  
  private Rigidbody _rb;
  private CharacterController _cc;
  private Vector3 _lastMovementDirection = Vector3.back;
  
  public AudioClip ballHitSound;
  private AudioSource _audioSource;

  void Start()
  {
    _rb = GetComponent<Rigidbody>();
    _cc = GetComponent<CharacterController>();
    _audioSource = GetComponent<AudioSource>();
  }

  void Update()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    

    // Only move along x and z axes
    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    // Apply gravity manually
    if (!_cc.isGrounded)
    {
      movement.y += Physics.gravity.y * Time.deltaTime;
    }

    float currentSpeed = speed;
    if (Input.GetKey(KeyCode.LeftShift))
    {
      currentSpeed *= sprintMultiplier;
    }

    _cc.Move(movement.normalized * currentSpeed * Time.deltaTime);

    if (Input.GetButtonDown("Jump") && isGrounded)
    {
      _rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
      isGrounded = false;
    }

    // Face movement direction
    if (movement.magnitude > Mathf.Epsilon)
    {
      _lastMovementDirection = Vector3.ProjectOnPlane(movement, Vector3.up).normalized;
    }

    transform.forward = _lastMovementDirection;
  }

  void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Ground"))
      {
        isGrounded = true;
      }

      if (collision.gameObject.CompareTag("Ball"))
      {
        _audioSource.PlayOneShot(ballHitSound);
      }
    }
  
}

