using UnityEngine;
using System.Collections;

public class CameraSetup : MonoBehaviour
{
    public Transform target;            // La posición que seguirá la cámara
    public float smoothing = 5f;        // La velocidad con la que seguirá la cámara

    Vector3 offset;                     // El offset inicial de la cámara

    void Start ()
    {
        // Calcular el offset 
        offset = transform.position - target.position;
    }

    void FixedUpdate ()
    {
        //Crea una posición de donde está apuntando la cámara en base al offset del objetivo
        Vector3 targetCamPos = target.position + offset;

        //Interpolación suave entre la posición actual de la cámara y la posición de su objetivo
        transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
