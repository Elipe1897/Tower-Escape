using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]  // coden funkar inte om du inte har en kamera - Leo s 
public class CameraTrack : MonoBehaviour
{
    public List<Transform> targets; // A variable for the targets list - Leo S

    public Vector3 offset;   // A Vector 3 variable - Leo s 

  
    void LateUpdate() // It makes the camera follow the centerpoint between the players and you can choose the offset of the center position outside the script in unity so that you can have the camera exactly where you want it- Leo S
    {

        if (targets.Count == 0) 
        {
            return;  
        }
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = newPosition; // 

    }
    Vector3 GetCenterPoint() // It takes the positions of the players and calculates where the center point between them is - Leo S
    {
        if(targets.Count == 1)   
        {
            return targets[0].position; 
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position); 
        }
        return bounds.center;    
    }
    
}
