using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    [SerializeField]
    private float moveSpeed = 100f;

    [SerializeField]
    private float flySpeed;

    [SerializeField]
    private float smoothFactor = 0.1f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(0f, 0f, vertical).normalized;

        //animator.SetFloat("Speed", vertical);
       
        controller.Move(transform.forward * moveSpeed * vertical);
        
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * flySpeed *Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, transform.up, Time.deltaTime * smoothFactor);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.down * flySpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, transform.up, Time.deltaTime * smoothFactor);
        }

    }
}
