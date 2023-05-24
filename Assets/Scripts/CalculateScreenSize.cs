using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateScreenSize : MonoBehaviour
{
    Camera cam;
    float halfScreenWidthSize,
        halfScreenHeightSize;

    public float ReturnCameraHalfWidth() => halfScreenWidthSize;
    public float ReturnCameraHalfHeight() => halfScreenHeightSize;

    void Start(){
        cam = Camera.main;
        halfScreenHeightSize = cam.orthographicSize;
        halfScreenWidthSize = halfScreenHeightSize * cam.aspect;
    }
}
