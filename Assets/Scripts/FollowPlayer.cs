using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
    
    public GameObject Camera;


    // Update is called once per frame
    void LateUpdate()
    {        
        transform.position = transform.position ;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Camera.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
