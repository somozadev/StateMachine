using UnityEngine;
using UnityEngine.AI;


public class PatrolScript
{

    static int destination = 0;
    public static void Patrullar(GameObject[] waypoints, NavMeshAgent agente)
    {
        agente.isStopped = false;
        if(destination >= waypoints.Length) //asegurarse que el nuevo waypoint destino esté dentro del array
            destination = 0;
        if(!agente.pathPending && agente.remainingDistance <= 0.1f) //si no queda camino pendiente hasta el destino y la distancia
        //que queda por recorrer es menor de 0.1f asignar nuevo destino
        {
            agente.autoBraking = false;
            agente.destination = waypoints[destination].transform.position;
            destination = (destination + 1) % waypoints.Length;
        }

    }
}
