using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
            this.transform.rotation = Quaternion.Euler(0, 25 * Time.deltaTime, 0);
           //this.transform.Rotate(Vector3.up, StateMachine.rotationSpeed * Time.deltaTime);
    }

    
}
