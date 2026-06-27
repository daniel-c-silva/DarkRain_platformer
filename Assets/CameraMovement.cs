using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Obj_player; // * call player
    public float smoothCamSpd = 0.005f; // * speed at which it goes after the player
    private Vector3 offSet; // * distance between player and camera


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
        Vector3 targetPosition = Obj_player.transform.position + offSet; // * we want to constantly be equal to the player's + the offset distance
        
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothCamSpd); // * but instead of reaching at the same speed we lerp into it using the lerp built in along with the speed we defined

        transform.position = smoothPosition; // * finally our(camera) position must be equal to that of smoothPos (we just defined paramaters above.)
    }
}
