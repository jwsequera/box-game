using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace Jugador
{
    
public class logicBoxCharacter : MonoBehaviour
{

    Controles controles;
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;
    public bool isAnimating;
    public bool isBlocking;
    public string trigger;
    public bool isBot;
    public float hp;
    public float maxHp;
    public float danoPuno;
    public Image barraVida;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isAnimating = false;

        controles = new Controles("localhost", 4321);
        UnityEngine.Debug.Log("hp / maxhp: (Jugador): "+ ( hp / maxHp));

        //variables para recibir dano
        // maxHp = 1000;
        // hp = 1000;
        // danoPuno = 5;
    }

    // Update is called once per frame
    void Update()
    {   

        ActualizarBarraVida();

        UnityEngine.Debug.Log("ESTOY RECIBIENDO LA ACCION: " + controles.action);
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
        
        if ((controles.action == "I_LeadJab" && !isAnimating) || Input.GetKeyDown(KeyCode.B) && !isAnimating){
            
            Animating("I_LeadJab"); //Golpe Con izquierda
            // UnityEngine.Debug.Log("EJECUTANDO jab izq");
        }
        
        if (controles.action == "Cross" && !isAnimating){
            Animating("BodyJabCross"); //Golpe Con Derecha
            UnityEngine.Debug.Log("EJECUTANDO ");
        }
        
        // if (controles.action == "Left Hook" && !isAnimating){
        //     Animating("LeadJab"); //Golpe Con izquierda
        //     UnityEngine.Debug.Log("EJECUTANDO ");
        // }
        
        // if (controles.action == "Right Hook" && !isAnimating){
        //     Animating("LeadJab"); //Golpe Con izquierda
        //     UnityEngine.Debug.Log("EJECUTANDO ");
        // }
        
        // if (controles.action == "Left Upper" && !isAnimating){
        //     Animating("LeadJab"); //Golpe Con izquierda
        //     UnityEngine.Debug.Log("EJECUTANDO ");
        // }
        
        // if (controles.action == "Right Upper" && !isAnimating){
        //     Animating("LeadJab"); //Golpe Con izquierda
        //     UnityEngine.Debug.Log("EJECUTANDO ");
        // }

        else if ((controles.action == "D_LeadJab" && !isAnimating) || Input.GetKeyDown(KeyCode.N) && !isAnimating){
            
            Animating("D_LeadJab"); //Golpe Con izquierda
            // UnityEngine.Debug.Log("EJECUTANDO jab der");
        }

        else if ((controles.action == "I_UpperCut" && !isAnimating) || Input.GetKeyDown(KeyCode.G) && !isAnimating){
            
            Animating("I_UpperCut"); //Golpe Con izquierda
            // UnityEngine.Debug.Log("EJECUTANDO I_UpperCut");
        }

        else if ((controles.action == "D_UpperCut" && !isAnimating) || Input.GetKeyDown(KeyCode.H) && !isAnimating){
            
            Animating("D_UpperCut"); //Golpe Con izquierda
            // UnityEngine.Debug.Log("EJECUTANDO I_UpperCut");
        }
        else if ((controles.action == "I_Hook" && !isAnimating) || Input.GetKeyDown(KeyCode.J) && !isAnimating){
            
            Animating("I_Hook"); //Golpe Con izquierda
            // UnityEngine.Debug.Log("EJECUTANDO I_Hook");
        }
        else if ((controles.action == "D_Hook" && !isAnimating) || Input.GetKeyDown(KeyCode.K) && !isAnimating){
            
            Animating("D_Hook"); //Golpe Con izquierda
            // UnityEngine.Debug.Log("EJECUTANDO D_Hook");
        }

        else if (Input.GetKeyDown(KeyCode.L) && !isAnimating){
            Blocking();
            // UnityEngine.Debug.Log("Bloqueando");
        }

        // UnityEngine.Debug.Log("Estado de Animacion: " + isAnimating);
    }

    private void Animating(string trigger){
        anim.SetTrigger(trigger);
        // UnityEngine.Debug.Log("Ejecutando " + trigger);
        isAnimating = true;
    }

    private void Blocking(){
        anim.SetTrigger("BodyBlock");
        // UnityEngine.Debug.Log("Bloqueando");
        isAnimating = true;
    }

    private void notAnimating(){ //se ejecuta al casi finalizar la animacion de JabCross
        isAnimating = false;
    }

    private void NotBlocking() {
        isBlocking = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "BotManoDerecha"){
            if(anim != null){
                isAnimating = true;
                anim.Play("receiveLeadJab");
                if (GetRandomNum(0, 11) >= 8){
                hp -= danoPuno * 2; 
                }
                else {
                    hp -= danoPuno;
                }
            }
        }

        else if(other.gameObject.tag == "BotManoIzquierda"){
            if(anim != null){
                isAnimating = true;
                anim.Play("ReceiveLeadJab");
                if (GetRandomNum(0, 11) >= 8){
                
                // UnityEngine.Debug.Log("Di un Conazo durisimo");
                hp -= danoPuno * 2; 
                }
                else {
                    // UnityEngine.Debug.Log("Di un conazo suave");
                    hp -= danoPuno;
                }
            }
        }

        if (hp <= 0){
            Animating("knockout");
        }
    }
    private int GetRandomNum(int min, int max){
        System.Random rand = new();
        int num = rand.Next(min, max); //creara un random entre 0 y 10
        
        return num;
    }
    
    public void ActualizarBarraVida(){
        barraVida.fillAmount = hp / maxHp;
        // UnityEngine.Debug.Log("Barra vida Personaje" + barraVida.fillAmount);
    }

    public void RecibirMasDano(){
        danoPuno = danoPuno * 1.1f;
        hp = hp * 1.1f;
    }

}

}