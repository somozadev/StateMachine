using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    public enum estados {estadoPatrulla, estadoPersecuccion, estadoAlerta} //creamos un enum con los diferentes estados

    
    //Todas las variables y referencias utilizadas
    #region REFERENCES
    public static estados estado = estados.estadoPatrulla;
    public estados estadoActual;
    public AlertScript alert;
    
    public GameObject[] waypoints;
    public NavMeshAgent agent;
    public Transform player;
    
    public EnemyStats stats;
    public static EnemyStats enemyStats;

    public static float rotationSpeed;
    public  float rotationspeed;

    public static RaycastHit hit;
    public GameObject raycaster;

    public bool playerVision;
    public static bool playerVisto;
 

    #endregion

    public void Start()
    {
        rotationSpeed = rotationspeed;
        agent.angularSpeed = 300f;
        playerVisto = false; 
        playerVision = false;

        
    }
      public void Update()
    {

        //switch para cambiar de estados llamando a la función necesaria de los scripts de cada estado
        switch(estadoActual) 
        {
            case (estados.estadoPatrulla):
            PatrolScript.Patrullar(waypoints,agent);
            break;
            case (estados.estadoPersecuccion):
            PursuitScript.Pursuit(agent,player);
            
            break;
            case (estados.estadoAlerta):
            AlertScript.BusquedaTarget(agent, player, raycaster,estadoActual);
            playerVision = playerVisto; //igualamos una variable estatica cogida de la clase AlertScript a una local
            break;
        }

        if(playerVisto)
        {
            estadoActual = estados.estadoPersecuccion; //si la variable local es true pasamos a estado persecucción
            
        }
        //si el jugador está entre el rango de detección y el rango de persecucción del enemigo y el enemigo no lo está viendo
        //pasar a estado alerta
        if(Vector3.Distance(this.transform.position,player.transform.position) <= stats.detectionRange 
        && Vector3.Distance(this.transform.position,player.transform.position) > stats.persecutteRange && !playerVisto
        && estadoActual!=estados.estadoPersecuccion)
        {
            estadoActual = estados.estadoAlerta;
        }
        //Si el jugador está dentro del rango de persecucción se pasa a estado persecucción
        else if(Vector3.Distance(this.transform.position,player.transform.position) <= stats.persecutteRange)
        {
            estadoActual = estados.estadoPersecuccion;
        }
        //Si el jugador está más lejos que el rango de detección pasamos a estado patrulla, reseteando además
        //la booleana que nos dice si ha visto el enemigo al jugador
        else if(Vector3.Distance(this.transform.position,player.transform.position) > stats.detectionRange)
        {
            playerVisto = false; 
            playerVision = playerVisto;
            estadoActual = estados.estadoPatrulla;

        }
    
    }



    
    
    
    
    
    
    void OnDrawGizmos()
    {
        //Dibuja en el editor los rangos de detección, de persecucción además de el raycast del enemigo
        
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position,stats.detectionRange);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position,stats.persecutteRange);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(raycaster.transform.position, raycaster.transform.position + transform.forward * (stats.detectionRange-1));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(raycaster.transform.position + transform.forward * (stats.detectionRange-1),0.5f);

    }

     

    

    
}
