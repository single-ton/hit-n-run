﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour
{
    private float baseSpeed = 3.0f;
    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = baseSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float y = baseSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        if (transform.position.x + x > 16.5||transform.position.x + x < -15)
            return;
        if (transform.position.y + y > 10 || transform.position.y + y < -10)
            return;
            
        transform.Translate(x, y, 0, Space.World);
        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2) transform.position).normalized;
        transform.right = -direction;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.right = direction;
            newBullet.transform.position = this.transform.position + transform.right * -1f;
        }
    }
    
}