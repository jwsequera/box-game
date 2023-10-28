using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using recibirGolpesLogica;

public class MovimientoEnemigo : MonoBehaviour
{

    public bool blocking;
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public static bool atacando;
    public bool isAnimating;
    public bool timer;

    // Start is called before the first frame update
    void Start()
    {
        //  ani = GetComponent<Animator>();
        //  target = GameObject.Find("boxCharacter");   
        ani.SetBool("walk", true);
        isAnimating = GameObject.Find("boxCharacter (1)").GetComponent<EnemieBoxCharacterLogic>().anim;
        InvokeRepeating("SetTimer", 0f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        isAnimating = GameObject.Find("boxCharacter (1)").GetComponent<EnemieBoxCharacterLogic>().isAnimating;   
        ComportamientoEnemigo();
        AtaqueEnemigo();
    }

    public void ComportamientoEnemigo(){
      Debug.Log("Puedo buscar: "+ (Vector3.Distance(transform.position, target.transform.position) > 1));
      Debug.Log("Puedo atacar: " + atacando);

      if(Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando){
            ani.SetBool("walk", true);
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            Debug.Log("ESTOY BUSCANDO");
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
            //desactivamos la animacion de busqueda
            ani.SetBool("finding", false);
            //activamos la animacion de caminar
            
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
      }
      else {
        ani.SetBool("walk", false);
        atacando = true;

        //abajo debe ir la funcion para generar golpes aleatoriamente
      }
    }

    public void AtaqueEnemigo(){
      if (atacando && !isAnimating && timer) {
        // Debug.Log("Estoy Atacando");
        int accion = GetRandomNum(0, 8);
        switch (accion)
        {
          
          case 1:
            EjecutarAccion("I_LeadJab");
            break;
          case 2:
            EjecutarAccion("D_LeadJab");
            break;
          case 3:
            EjecutarAccion("I_Hook");
            break;
          case 4:
            EjecutarAccion("D_Hook");
            break;
          case 5:
            EjecutarAccion("I_UpperCut");
            break;
          case 6:
            blocking = true;
            EjecutarAccion("BodyBlock");
            break;
          case 7:
            EjecutarAccion("D_UpperCut");
            break;
          default:
            break;
        }
      }
    }

    private void EjecutarAccion(string accion){
      isAnimating = true;
      GameObject.Find("boxCharacter (1)").GetComponent<EnemieBoxCharacterLogic>().isAnimating = true;
      ani.SetTrigger(accion);  
      timer = false;
    }

    private void NotAttacking(){
      Debug.Log("ESTOY DESACTIVANDO EL ATAQUE CONO");
      atacando = !atacando;
    }
    private void NotBlocking(){
      blocking = false;
    }

    public void SetTimer(){
      timer = true;
    }
       private int GetRandomNum(int min, int max){
        System.Random rand = new();
        int num = rand.Next(min, max);
        
        return num;
    }

    public void Aparicion(){
      EjecutarAccion("aparicion");
    }

  public void Walking(){
    Debug.Log("Activando Walk");
    ani.SetBool("walk", true);
  }

}
