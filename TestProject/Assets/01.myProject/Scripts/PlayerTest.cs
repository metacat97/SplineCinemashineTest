using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerTest : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed = 10f;

    Rigidbody myRigid;

    private void Awake()
    {
        myRigid = GetComponent<Rigidbody>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    private void FixedUpdate()
    {
        Run();
    }
    // Update is called once per frame
    void Update()
    {
        Jump();        
    }
    private void Run()
    {
        Vector3 nextVec = new Vector3(inputVec.x * speed,0f,inputVec.y * speed);
        myRigid.velocity = transform.TransformDirection(nextVec);
    }
    void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        inputVec = value.Get<Vector2>();
    }

    void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigid.velocity = Vector3.zero;
            myRigid.AddForce(Vector3.up * 100f,ForceMode.Impulse);
        }
        else
        {
            myRigid.AddForce(Vector3.down,ForceMode.Impulse);
        }
    }
}
