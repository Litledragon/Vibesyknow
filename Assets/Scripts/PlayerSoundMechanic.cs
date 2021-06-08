using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundMechanic : MonoBehaviour
{
    private Vector3 CameraDirection = new Vector3();

    public new Camera camera;

    private void Update()
    {

        //Debug.Log(CameraDirection);

        if (Input.GetMouseButton(0))
        {
            CameraDirection = (Input.mousePosition - camera.WorldToScreenPoint(transform.position)).normalized;
            
            RaycastHit hit;
            if(Physics.Raycast(transform.position, CameraDirection, out hit))
            {
                hit.transform.GetComponent<SoundAffectedEntity>()?.Push();
            }
        }        
        
        else if (Input.GetMouseButton(1))
        {
            CameraDirection = (Input.mousePosition - camera.WorldToScreenPoint(transform.position)).normalized;
            
            RaycastHit hit;
            if(Physics.Raycast(transform.position, CameraDirection, out hit))
            {
                hit.transform.GetComponent<SoundAffectedEntity>()?.Pull();
            }
        }
    }
}