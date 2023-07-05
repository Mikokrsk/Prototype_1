using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlayer1 : MonoBehaviour
{
    
    public GameObject Camera;


    // Update is called once per frame
    void LateUpdate()
    {        
        transform.position = transform.position ;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
                Camera.SetActive(true);          
                gameObject.SetActive(false);
        }
    }
}
