using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   public float moveSpeed = 10f;
   public float rotateSpeed = 45f;
   
   private Rigidbody _rbgidbody;
   private float _moveInputValue;
   private float _rotateInputValue;
   public Text scoreText;
   private int _score;
   
   private void Start()
   {
      _rbgidbody = GetComponent<Rigidbody>();
      _rbgidbody.isKinematic = false;
      _moveInputValue = 0;
      _rotateInputValue = 0;
      _score = 0;
      scoreText.text = "";
   }

   void Update()
   {
      _moveInputValue = Input.GetAxis("Vertical");
      _rotateInputValue = Input.GetAxis("Horizontal");
   }

   private void FixedUpdate()
   {
      Move();
      Turn();
   }

   private void Move()
   {
      var movement = transform.forward * _moveInputValue * moveSpeed * Time.deltaTime;
      _rbgidbody.MovePosition(transform.position + movement);
   }

   private void Turn()
   {
      var turn = _rotateInputValue * rotateSpeed * Time.deltaTime;
      var turnRotation = Quaternion.Euler(0, turn, 0);
      _rbgidbody.MoveRotation(_rbgidbody.rotation * turnRotation);
   }

   public void SetScore()
   {
      _score++;
      scoreText.text = "Score : " + _score;
      if (_score >= 10)
      {
         scoreText.text = "You Win!";
      }
   }
}
