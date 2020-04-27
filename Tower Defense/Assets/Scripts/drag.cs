using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    public string PlayerTag = "Player";
    public float grabrange = 1f;
    private GameObject Player;
    public bool cangrab;
    public bool grabbing = false;
    public Camera came;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag(PlayerTag);
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (distanceToPlayer < grabrange)
        {
            cangrab = true;
            

        }
        
        if (distanceToPlayer > grabrange)
        {
            cangrab = false;
        }
        if (cangrab == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = came.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                 {
                   if (hit.collider.tag == "drag")
                    {
                        Debug.Log("grabbing");
                        grab();
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && grabbing ==true)
        {
            drop();
        }
    }
    void grab()
    {
        transform.parent = Player.transform;
        grabbing = true;
    }
    void drop()
    {
        transform.parent = null;
        grabbing = false;
    }
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, grabrange);
    }
}
    
