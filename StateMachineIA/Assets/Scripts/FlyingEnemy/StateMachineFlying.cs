using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachineFlying : MonoBehaviour
{
    public enum Estados  {estadoPatrulla, estadoDisparo} //enum con los diferentes estados 
    
    //todas las variables necesarias
    #region REFERENCES

    public GameObject lider;
    public NavMeshAgent agente; 
    public Transform player;
    public Estados estadoActual = Estados.estadoPatrulla;
    public GameObject laser;
    public float fireRate = 3f;
    private float timepassed;
    #endregion



    public void Update()
    {

        //switch con los diferentes estados
        switch(estadoActual) 
        {
            //en el caso de patrulla, diferenciamos según el tag si se trata del enemigo líder o el secuaz,
            //dependiendo de cual sea llamaremos a una u otra función de la clase RandomPatrol
            case Estados.estadoPatrulla:
            if(this.gameObject.tag !="Leader")
                RandomPatrol.FollowLeader(agente, lider);
            RandomPatrol.RandomPatrolFunction(agente);
            break;
            
            //en estado disparo llamaremos a la función de EstadoDisparo()
            case Estados.estadoDisparo:
            EstadoDisparo();
            break;

        }


        timepassed += Time.deltaTime;

        //si la distancia entre el jugador y el enemigo es menor o igual a 6 unidades pasamos a estado disparo
        if(Vector3.Distance(this.transform.position,player.position) <= 6f)
            estadoActual = Estados.estadoDisparo;

        //si es superior a 6 unidades pasamos a estado patrulla
        else
            estadoActual = Estados.estadoPatrulla;
    }

    //Dado que para instanciar necesitamos una clase que herede de monobehaivour en lugar de crar una clase separada
    //para estado disparo haremos una función en StateMachineFlying : Monobehaivour.
    public void EstadoDisparo()
    {
        //Hacemos que el enemigo deje de moverse y un contador de tiempo real comparandolo con la variable fireRate
        //para que cada 3sg en este caso (en función del valor de la variable FireRate) se instanciará una bala.
        agente.isStopped = true;
        
        if(timepassed >= fireRate)
            {
                timepassed = 0;
                GameObject instancia = Instantiate(laser, new Vector3(this.transform.position.x,this.transform.position.y-0.4f,this.transform.position.z) ,Quaternion.identity);
                instancia.GetComponent<Rigidbody>().AddForce(Vector3.down);
            }
    }
    void OnDrawGizmos()
    {
        //dibuja en el editor una línea desde el enemigo hasta el suelo.
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(this.transform.position,this.transform.position + Vector3.down * 6f);
       

    }
}
