using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    private bool canmove = true;
    public float movespeed = 30f;
    public float bordersize = 10f;
    public float scrollspeed = 5f;
    public float minY = 10f;
    public float maxY = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            canmove = !canmove;
        if (!canmove)
            return;
        if(Input.GetKey("w") || Input.mousePosition.y >=Screen.height - bordersize )
        {
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= bordersize)
        {
            transform.Translate(Vector3.back * movespeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - bordersize)
        {
            transform.Translate(Vector3.right * movespeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <=  bordersize)
        {
            transform.Translate(Vector3.left * movespeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll *1000* scrollspeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

   
}
