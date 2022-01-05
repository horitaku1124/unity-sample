using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        GameObject gameControl = GameObject.Find("GameController");
        GameControl gameScript = gameControl.GetComponent<GameControl>();
        gameScript.stopGame();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
