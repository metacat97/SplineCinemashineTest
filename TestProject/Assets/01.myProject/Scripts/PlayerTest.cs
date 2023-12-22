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
            Debug.Log("들어옴");
            npc = other.GetComponent<IInteractableNpc>();
            isInteract = true;
        }
    }

 
    private void OnTriggerExit(Collider other)
    {
            Debug.Log("나감");
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
        Debug.Log("플레이어 위치에서 실행됨");
            npc.ChangeNpcState(NpcState.Glued);
        
    }

    private void HitNpc()
    {
            // Ray를 생성하고 스크린 좌표를 월드 좌표로 변환
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            // Raycast를 수행하고 NPC 태그를 가진 오브젝트에만 반응
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Npc"))
            {
                // 특정 메서드 실행 (예: NPC 클릭 시 호출할 메서드)
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
