using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float speed = 10f; // 1秒間で進む距離
    private Rigidbody mainRigidbody;
    private Vector3 defPos;
    private Vector3 curPos;
    private float direction;
    private Vector3 moveVec;
    private int tunedCount;
    private GameControl gameScript;
   
    void Start()
    {
        mainRigidbody = GetComponent<Rigidbody>();
        defPos = transform.position;
        curPos = new Vector3(defPos.x, defPos.y, defPos.z);
        direction = (float)(Math.PI * -0.5);
        moveVec = new Vector3(0, 0, -1);
        tunedCount = 0;

        GameObject gameControl = GameObject.Find("GameController");
        gameScript = gameControl.GetComponent<GameControl>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (tunedCount >= 3) {
            direction += (float)(Math.PI * 0.5);
        } else {
            direction += (float)(Math.PI * -0.5);
        }
        float x = (float)(Math.Sin(direction));
        float z = (float)(Math.Cos(direction));
        moveVec = new Vector3(x, 0, z);
        tunedCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameScript.isPlayingGame()) {
            float stepSpeed = speed * Time.deltaTime;
            curPos.x += moveVec.x * stepSpeed;
            curPos.y += moveVec.y * stepSpeed;
            curPos.z += moveVec.z * stepSpeed;
            mainRigidbody.MovePosition(new Vector3(curPos.x, curPos.y, curPos.z));
        }
    }
}
