using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possession : MonoBehaviour
{

    private Team _team;
    private Player _ply;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _team = GetComponentInParent<Team>();
        _ply = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<Ball>())
            GainPossession();
    }

    private void GainPossession()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
