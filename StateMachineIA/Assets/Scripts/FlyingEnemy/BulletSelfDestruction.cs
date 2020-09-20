using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSelfDestruction : MonoBehaviour
{

    //este script se incorpora a las balas que instancia este tipo de enemigo en su estadoDisparo
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == ("player"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }
}
