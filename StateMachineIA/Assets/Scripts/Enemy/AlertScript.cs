using UnityEngine;
using UnityEngine.AI;

public class AlertScript 
{

    public static float sphereRaduis = 0.5f;
    
    public static void BusquedaTarget(NavMeshAgent agente, Transform player,GameObject Raycaster, StateMachine.estados estado)
    {
        RaycastHit hit;
        agente.isStopped = true;
        agente.updateRotation = true;
        agente.transform.Rotate(Vector3.up); //hacer que el enemigo rote sobre el eje y

        //agente.transform.RotateAroundLocal(Vector3.up,StateMachine.rotationSpeed * Time.deltaTime); -> el rotateAroundLocal esta obsoleto pero sigue funcionando, hace lo mismo que Rotate

        if(Physics.Raycast(Raycaster.transform.position,Raycaster.transform.forward,out hit, 10f))
        {
            //casteo un raycast desde el enemigo si encuentra al jugador con tag player el enemigo se queda mirandolo
            //y activamos la variable playerVisto a true, condicionante para cambiar de estado
            if(hit.collider.gameObject.tag == "Player")
            {
                agente.transform.LookAt(hit.transform.position);
                StateMachine.playerVisto = true;
            }
        }
    }
}
