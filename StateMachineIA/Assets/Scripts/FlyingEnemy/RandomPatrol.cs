using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPatrol 
{

//Función adscrita al resto de enemigos secuaces, éstos siguen al enemigo líder si están más lejos de 8 unidades,
//si se acerca más de 8 unidades, el nuevo destino es el secuaz mismo, por lo que se queda quieto, si además de 
//acercarse a más de 8 unidades no tiene camino por recorrer, lo alejamos dándole un destino aleatorio nuevo.
public static void FollowLeader(NavMeshAgent agente, GameObject lider)
{
    if(Vector3.Distance(agente.transform.position,lider.transform.position) >8f)
    agente.destination = lider.transform.position;
    if(Vector3.Distance(agente.transform.position,lider.transform.position) <=8f)
    agente.destination = agente.transform.position;
    if(Vector3.Distance(agente.transform.position,lider.transform.position) <=8f && !agente.pathPending)
        agente.destination = RandomPointInBox(new Vector3(-276.5f,10.53614f,48.00449f),new Vector3(37.70092f,37.70092f,37.70092f));
}

//Función adscrita solamente al enemigo líder, le da un destino en función de RandomPointInBox() con los parámetros
//del tamaño de la escena
public static void RandomPatrolFunction(NavMeshAgent agente)
    {
        agente.isStopped = false;
        if(!agente.pathPending && agente.remainingDistance <= 0.1f)
        {
            agente.autoBraking = false;
            agente.destination = RandomPointInBox(new Vector3(-276.5f,10.53614f,48.00449f),new Vector3(37.70092f,37.70092f,37.70092f));
            
        }

    }

    //Función que devuelve una posición aleatoria (en vector3) de área dada
    private static Vector3 RandomPointInBox(Vector3 center, Vector3 size) 
    {
            
             return center + new Vector3(
                (Random.value - 0.5f) * size.x,
                (Random.value - 0.5f) * size.y,
                (Random.value - 0.5f) * size.z
             );
         }
}
