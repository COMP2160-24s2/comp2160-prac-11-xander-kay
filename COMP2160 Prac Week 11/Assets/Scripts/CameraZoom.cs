using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    [Range(5,10)]
    [SerializeField] private float orthographicCameraZoomRange;
    [Range(50,120)]
    [SerializeField] private float perspectiveCameraZoomRange;

    [SerializeField] private Camera cam;

    #region Actions
        private Actions actions;
        private InputAction zoomAction;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        actions = new Actions();
        zoomAction = actions.camera.zoom;
        cam = Camera.main;
        
        
    }
    void OnEnable(){
        zoomAction.Enable();
        actions.camera.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        if(cam.orthographic)
        {
            cam.orthographicSize = orthographicCameraZoomRange;
        } else {
            cam.fieldOfView = perspectiveCameraZoomRange;
        }
        cam.transform(zoomAction.x,zoomAction.y,0);
    }
}
//Needs to readValue into from the InputAction