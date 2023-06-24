using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public LayerMask groundLayer =1<< 7;
    // Start is called before the first frame update
    private void Awake()
    {
        GameManager.Floor = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
