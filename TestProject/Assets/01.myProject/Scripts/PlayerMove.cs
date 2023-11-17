using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform playerTransform;

    [SerializeField] private Ray myRay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 test = myRay.direction;
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));
            //Debug.Log("여기 들어감?");
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(myRay, out hit))
            {
                
                if(hit.collider.tag == "Ttang") 
                {
                    Debug.Log("여기 들어감?");
                    playerTransform.transform.position = new Vector3(hit.point.x, playerTransform.transform.position.y,hit.point.z);
                    
                    Debug.Log(hit.point);
                }
            }
        }
    }
}
