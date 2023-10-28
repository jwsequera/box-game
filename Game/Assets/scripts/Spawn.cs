using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform posRespawn;
    public Transform posBot;
    public GameObject Bot;

    public void UseRespawn(){
        posBot.position = posRespawn.position;
        // Bot.GetComponent<Renderer>().enabled = true;
        // Bot.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        Debug.Log("SE SUPONE QUE DEBO RESPAWNEAR");
    }

    //esta funcion sera utilizada para ocultar el bot
    public void OcultarBot(){
       Bot.transform.localScale = new Vector3(0, 0,0);
    }
}
