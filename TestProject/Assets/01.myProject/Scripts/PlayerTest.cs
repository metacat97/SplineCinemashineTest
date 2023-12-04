using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTest : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed = 10f;

    private bool isInteract = false;
    private IInteractableNpc npc = default;
    private InteractButton interactButton = default;
    Rigidbody myRigid;

    private void Awake()
    {
        myRigid = GetComponent<Rigidbody>();    
    }
    private void Start()
    {
        speed = 10;
    }

    private void FixedUpdate()
    {
        Run();
    }
    private void Update()
    {
        if (isInteract) return;
        Jump();
        PlayerInteract();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Npc"))
        {
            npc = other.GetComponent<IInteractableNpc>();
            interactButton = other.gameObject.GetComponent<InteractButton>();
            interactButton.SetText(npc.npcName);
            interactButton.isOnPanel = true;
            interactButton.ControlInteractPanel();
        }
    }


    //private void OnTriggerStay(Collider other)
    //{
    //    //if (other.CompareTag("Npc"))
    //    //{
    //    //    IInteractableNpc npc = other.GetComponent<IInteractableNpc>();
    //    //    InteractButton interactButton = other.gameObject.GetComponent<InteractButton>();
    //    //    interactButton.ControlInteractPanel();
    //    //    if (npc != null) 
    //    //    {
    //    //        npc.InteractNpc();
    //    //        if(Input.GetKeyDown(KeyCode.F))
    //    //        {
    //    //            npc.PushButton();
    //    //        }
    //    //    }
    //    //}
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Npc"))
        {
            interactButton.isOnPanel = false;
            interactButton.ControlInteractPanel();
            npc = null;
            interactButton = null; 
            isInteract = false;
        }
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
    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigid.velocity = Vector3.zero;
            myRigid.AddForce(Vector3.up * 5f,ForceMode.Impulse);
        }
        else
        {
            myRigid.AddForce(Vector3.down,ForceMode.Force);
        }
    }

    public void PlayerInteract()
    {
        if(interactButton != null)
        {
            interactButton.ControlInteractPanel();
        }
        if (npc != null)
        {
            npc.InteractNpc();
            if (Input.GetKeyDown(KeyCode.F))
            {
                npc.PushButton();
                isInteract = true;
            }
        }
    }
}
