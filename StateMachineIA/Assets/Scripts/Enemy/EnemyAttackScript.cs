using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{

    //si en enemigo colisiona con el jugador con tag player el jugador es destruido
    void OnCollisionEnter(Collision collision)
    {
            if(collision.gameObject.name == ("player"))
            Destroy(collision.transform.gameObject);
        
    }
}
