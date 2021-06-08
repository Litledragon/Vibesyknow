using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundMechanic : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, Vector3.zero, out hit))
            {
                hit.transform.GetComponent<SoundAffectedEntity>().Push();
            }
        }        
        
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, Vector3.zero, out hit))
            {
                hit.transform.GetComponent<SoundAffectedEntity>().Pull();
            }
        }
    }
}