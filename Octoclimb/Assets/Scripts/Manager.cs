using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    private GameObject player;
    [Tooltip("Startting position of player."), SerializeField] private Vector2 startPos;
    [Tooltip("Camera"), SerializeField] private GameObject cam;
    [Tooltip("Camera's speed variable"), SerializeField] private float cameraSpeed;
    [Tooltip("Camera Offset"), SerializeField] private Vector2 offset;
    [Tooltip("Blobs' spawn area width"), SerializeField] private float blobWidth;
    [Tooltip("Blobs' distance between each other in Y axis"), SerializeField] private float blobSpace;

    private List<GameObject> blobList = new List<GameObject>();


    void Start()
    {
        CreatePlayer();
        blobList.Add(Instantiate(Resources.Load<GameObject>("Prefabs/Blob"), new Vector3(0, -3.25f, 0f), Quaternion.identity));
    }

    void CreatePlayer()
    {
        //Creates player from Resources/Prefabs/ folder
        player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"), startPos, Quaternion.identity);
    }

    void GenerateBlob()
    {
        blobList.Add(Instantiate(Resources.Load<GameObject>("Prefabs/Blob"), new Vector3(Random.Range(-blobWidth, blobWidth), blobList[blobList.Count-1].transform.position.y + blobSpace), Quaternion.identity));
    }

    void Update()
    {
        if (player.transform.position.y < cam.transform.position.y - offset.y - 5) 
        {
            SceneManager.LoadScene("Start");
        }
        //Remove old blobs
        if (blobList[0].transform.position.y - player.transform.position.y +10 < 0)
        {
            Destroy(blobList[0]);
            blobList.Remove(blobList[0]);
        }
        if (blobList[blobList.Count-1].transform.position.y - player.transform.position.y < 10)
        {
            GenerateBlob();
        }

        cam.transform.Translate(new Vector2(0f, Mathf.Clamp((player.transform.position.y - cam.transform.position.y + offset.y) * Time.deltaTime * cameraSpeed, -1f * cameraSpeed, 1f * cameraSpeed)));
    }
}

