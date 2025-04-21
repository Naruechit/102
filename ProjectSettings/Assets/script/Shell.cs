using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float shellSpeed = 20f;

    private PlayerController _player;
    
    private Vector3 _direction;
    private bool _refleced = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        
        _direction = transform.forward;
        
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * shellSpeed * Time.deltaTime;
        
        transform.LookAt(transform.position + _direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_refleced)
        {
            var contact = collision.contacts[0];
            var reflectedVector = Vector3.Reflect(_direction, contact.normal);
            
            _direction = reflectedVector;
            _refleced = true;
        }

        else
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Target"))
        {
            _player.SetScore();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
