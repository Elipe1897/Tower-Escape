using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]  // coden funkar inte om du inte har en kamera - Leo s 
public class CameraTrack : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;   // vector 3 variable - Leo s 

  
    void LateUpdate()
    {

        if (targets.Count == 0) // tittar om target �r 0 - Leo s 
        {
            return;  // skickar tillbaks v�rdet - Leo s 
        }
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = newPosition; // 

    }
    Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)   // om arry target �r 1 
        {
            return targets[0].position;  // skickar tillbaks postion 1 i target - Leo s 
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position); // 
        }
        return bounds.center;     // skickar tillbaks v�rdet p� bounds - Leo s 
    }
    
}
