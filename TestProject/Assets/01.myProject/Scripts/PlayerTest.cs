using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTest : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed = 10f;

    private bool isControl = true;

    private bool isInteract = false;
    public IInteractableNpc npc = default;
   
    Rigidbody myRigid;

    private void Awake()
    {
        myRigid = GetComponent<Rigidbody>(); 
        isControl = true;
    }
  
    private void FixedUpdate()
    {
        Run();
    }
    private void Update()
    {
        PushInteract();
        HitNpc();
        Jump();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Npc"))
        {
            Debug.Log("����");
            npc = other.GetComponent<IInteractableNpc>();
            isInteract = true;
        }
    }

 
    private void OnTriggerExit(Collider other)
    {
            Debug.Log("����");
        if (other.CompareTag("Npc"))
        {
            npc = null;
            isInteract = false;
        }
        
    }
    
    private void PushInteract()
    {
        if(npc != null && isInteract)
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                isInteract = false;
                isControl = false;
                npc.InteractNpc();
            }
        }
    }
    private void ShotGlued()
    {
        Debug.Log("�÷��̾� ��ġ���� �����");
            npc.ChangeNpcState(NpcState.Glued);
        
    }

    private void HitNpc()
    {
            // Ray�� �����ϰ� ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            // Raycast�� �����ϰ� NPC �±׸� ���� ������Ʈ���� ����
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Npc"))
            {
                // Ư�� �޼��� ���� (��: NPC Ŭ�� �� ȣ���� �޼���)
                ShotGlued();
            }
        }
    }
 
    public void ChangeDialogueState()
    {
        isInteract = true;
        isControl = true;
    }

    private void Run()
    {
        if (isControl)
        {
            Vector3 nextVec = new Vector3(inputVec.x,0f,inputVec.y).normalized;
            transform.position += nextVec * speed * Time.deltaTime;
        }
        //myRigid.velocity = transform.TransformDirection(nextVec);
    }
    void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        inputVec = value.Get<Vector2>();
    }
    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && isControl)
        {
            myRigid.velocity = Vector3.zero;
            myRigid.AddForce(Vector3.up * 5f,ForceMode.Impulse);
        }
        else
        {
            myRigid.AddForce(Vector3.down,ForceMode.Force);
        }
    }
}
