using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Manager : MonoBehaviour
{
    private GameObject player;
    [Tooltip("Startting position of player."), SerializeField] private Vector2 startPos;
    [Tooltip("Camera"), SerializeField] private GameObject camera;
    [Tooltip("Camera's speed variable"), SerializeField] private float cameraSpeed;


    void Start()
    {
        CreatePlayer();
    }

    void CreatePlayer()
    {
        //Creates player from Resources/Prefabs/ folder
        player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"), startPos, Quaternion.identity);
    }

    void Update()
    {
        camera.transform.Translate(new Vector2(0f, Mathf.Clamp((player.transform.position.y - camera.transform.position.y) * Time.deltaTime * cameraSpeed, -1f * cameraSpeed, 1f * cameraSpeed)));
    }
}

