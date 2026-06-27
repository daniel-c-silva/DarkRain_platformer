using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Obj_player; // * call player
    public float smoothCamSpd = 0.005f; // * speed at which it goes after the player
    private Vector3 offSet; // * distance between player and camera
    private Vector3 velocity = Vector3.zero; // * add this line


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offSet = transform.position - Obj_player.transform.position; // * the offset is defined at the start as the difference between both object's pos
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    // ! late update is called after update functions so our player movement does not fight with the camera lerp. or else itd look shaky!!!! DONT change!!!1

void LateUpdate()
{
    Vector3 targetPosition = Obj_player.transform.position + offSet;
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothCamSpd);
}
}
