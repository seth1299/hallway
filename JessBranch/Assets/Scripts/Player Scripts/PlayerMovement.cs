﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [Tooltip("This is the Character Controller component that is attached to this Player game object.")]
  public CharacterController controller;

  [Tooltip("This is the speed at which the player moves. It is very unclear how this unit is measured in, so arbitrary values are used for it.")]
  public float speed;

  private Rigidbody rb;

  void Start()
  {
    rb = gameObject.GetComponent<Rigidbody>();
  }

  void Update()
  {
      float x = Input.GetAxis ("Horizontal");
      float z = Input.GetAxis ("Vertical");

      
      Vector3 move = transform.right * x + transform.forward * z;
      controller.SimpleMove(move * speed * Time.deltaTime);
      

      /*
      if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
      {
        Vector3 tempVec = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
        rb.MovePosition(tempVec);
      }
      */
  }
}