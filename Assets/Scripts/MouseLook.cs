using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 90f;
    public Transform Player, Target;


    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");

        var movement = new Vector3(0f, 0f, horizontal).normalized;
        
        Player.transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);
        Target.transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);
        
    }
}
