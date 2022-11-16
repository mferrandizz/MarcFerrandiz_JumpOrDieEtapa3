using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{


    private Rigidbody2D rBody;
    private GameManager gameManager;

    
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
