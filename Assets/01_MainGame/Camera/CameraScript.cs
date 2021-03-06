using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stone {

public class CameraScript : MonoBehaviour
{

    //Размер в пикселях для отображения
    private float sceneHigh = Const.CellSizePx * (Const.MapSize );

    private Camera _camera;

    private float PreviusAspect;
    private float unitsPerPixel;


    public GameObject Background;

    void Start()
    {
        PreviusAspect = 0;
        _camera = GetComponent<Camera>();
        float s = Const.CellSizePx * (Const.MapSize - 1);
        Camera.main.transform.position = new Vector3(s / 2f, -s / 2f, -10);

    }


    void Update()
    {
        if (PreviusAspect != Camera.main.aspect)
        {

            Debug.Log("--Camera resaize-- "+ Camera.main.aspect);

            PreviusAspect = Camera.main.aspect;

            //float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;
            //float desiredHalfwidth = 0.5f * unitsPerPixel * Screen.width;

            //if (desiredHalfHeight > desiredHalfwidth)
            //{
            //    _camera.orthographicSize = desiredHalfHeight;
            //}
            //else
            //{
            //    _camera.orthographicSize = desiredHalfwidth;
            //}

            if (Camera.main.aspect > 1)
            {
                _camera.orthographicSize = sceneHigh / 2;
            }
            else
            {
                _camera.orthographicSize = sceneHigh / 2 / Camera.main.aspect;
            }
            
            
            Background.transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);

            //Background.transform.localScale=new Vector3(Camera.main.orthographicSize*2, Camera.main.aspect * Camera.main.orthographicSize*  2, 1);
            float f1 = Camera.main.orthographicSize * 2;
            float f2 = Camera.main.aspect * Camera.main.orthographicSize * 2;

            Background.transform.localScale = new Vector3(f1>f2?f1:f2, f1 > f2 ? f1 : f2, 1);

            
        }
    }
}
                 
}