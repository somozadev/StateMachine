using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoWaypoint : MonoBehaviour
{

    //función exclusiva para dibujar en el editor los waypoints de cada enemigo

    public GameObject padre;
    void OnDrawGizmos()
    {
        if(padre.name == "Enemy1")
            Gizmos.color = Color.green;
        if(padre.name == "Enemy2")
            Gizmos.color = Color.blue;
        if(padre.name == "Enemy3")
            Gizmos.color = Color.yellow;
        
        Gizmos.DrawWireSphere(this.transform.position,0.1f);
    }
}
