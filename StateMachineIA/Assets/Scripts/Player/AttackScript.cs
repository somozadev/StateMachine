using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    //Trigger cuando colisiona el jugador con el tag enemigo se destruye el jugador
    void OnTriggerStay(Collider collision)
    {
            if(collision.CompareTag("Enemy"))
            Destroy(collision.transform.parent.parent.gameObject);
        
    }

}
