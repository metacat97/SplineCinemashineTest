using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Vector3 nextVec = new Vector3(inputVec.x,0f,inputVec.y).normalized;
        //myRigid.velocity = transform.TransformDirection(nextVec);
        transform.position += nextVec * speed * Time.deltaTime;
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
            myRigid.AddForce(Vector3.up * 5f,ForceMode.Impulse);
        }
        else
        {
            myRigid.AddForce(Vector3.down,ForceMode.
                Force);
        }
    }
}
