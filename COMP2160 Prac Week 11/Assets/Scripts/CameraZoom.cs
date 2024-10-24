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
    private float zoomSpeed = 5;


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
        Debug.Log(zoomAction.ReadValue<float>());

        if(cam.orthographic)
        {
            cam.orthographicSize = orthographicCameraZoomRange;
        } else {
            cam.fieldOfView = perspectiveCameraZoomRange;
        }
        transform.Translate(Vector3.down * zoomAction.ReadValue<float>() * zoomSpeed * Time.deltaTime, Space.World);
    }
}
//Needs to readValue into from the InputAction