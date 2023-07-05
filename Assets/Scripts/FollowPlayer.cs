using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject secondCamera;
    public GameObject player;

    void Start()
    {
        mainCamera.SetActive(true);
        secondCamera.SetActive(false);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            secondCamera.SetActive(!secondCamera.active);
            mainCamera.SetActive(!mainCamera.active);
        }
    }
}
