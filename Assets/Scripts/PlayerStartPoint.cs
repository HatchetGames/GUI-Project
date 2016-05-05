using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStartPoint : MonoBehaviour
{
    private PlayerController thePlayer;
    private CameraFollow theCamera;

    public Vector2 startDirection;

    public string pointName;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
            thePlayer.lastMove = startDirection;

            theCamera = FindObjectOfType<CameraFollow>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
    }

    void Update()
    {

    }
}
