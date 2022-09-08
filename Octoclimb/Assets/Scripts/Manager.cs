using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Manager : MonoBehaviour
{
    private GameObject player;
    [Tooltip("Startting position of player."), SerializeField] private Vector2 startPos;

    void Start()
    {
        
        print(player);
    }

    void CreatePlayer()
    {
        //Creates player from Resources/Prefabs/ folder
        player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"), startPos, Quaternion.identity);
    }

    void Update()
    {
    }
}

