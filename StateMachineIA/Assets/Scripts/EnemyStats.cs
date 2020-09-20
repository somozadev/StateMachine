using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "EnemyStats")] //sirve para habilitar dentro de unity (con el click derecho)
//la creación de un objeto scriptable EnemyStats
public class EnemyStats : ScriptableObject
{
    //clase Scriptable para poder crear objetos en la carpeta Assets, donde guardo variables 
    //específicas de cada enemigo

    public float speed;
    public float detectionRange;
   public float persecutteRange;


}
