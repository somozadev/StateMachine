using UnityEngine;
using UnityEngine.AI;

public class PursuitScript 
{
    public static void Pursuit(NavMeshAgent agente, Transform player)
    {
        agente.isStopped = false;
        agente.destination = player.position; //asignar el nuevo destino en la posición del jugador
        
    }
}
