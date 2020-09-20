using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject player;


    //Script que busca si el jugador ha sido destruido cada frame, si es así se reinicia la escena
    void Awake()
    {
        player = GameObject.Find("player");
    }
    void Update()
    {
        if(player == null)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
