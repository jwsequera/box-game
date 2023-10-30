using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Jugador;

namespace recibirGolpesLogica
{
    public class EnemieBoxCharacterLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp;
    public float maxHp;
    public int danoPuno;
    public Animator anim;
    public bool isAnimating;
    public Image barraVida;
    public Spawn systemRespawn; 
    public AudioSource punch;
    public AudioSource KO;

    public bool isKnockout;
    // Start is called before the first frame update
    void Start()
    {
        isKnockout = false;
        anim = GetComponent<Animator>();
        isAnimating = false;

        AudioSource[] audios = GetComponents<AudioSource>();  
        punch = audios[0];
        KO = audios[1];
        // maxHp = 100;
        // hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Vida bot: " + (hp / maxHp));
        ActualizarBarraVida();
    }

    private void OnTriggerEnter(Collider other) {
        
        // Debug.Log(other.gameObject.name);
        
        if(isKnockout){
            return;
        }

        if(other.gameObject.tag == "ManoDerecha"){
            punch.Play();
            if(anim != null){
                anim.Play("receiveLeadJab");
                isAnimating = true;
                if (GetRandomNum(0, 11) >= 8){
                hp -= danoPuno * 2; 
                }
                else {
                    hp -= danoPuno;
                }
            }
        }

        if(other.gameObject.tag == "ManoIzquierda"){
            punch.Play();
            if(anim != null){
                isAnimating = true;
                anim.Play("receiveLeadJab");
                if (GetRandomNum(0, 11) >= 8){
                // Debug.Log("Di un Conazo durisimo");
                hp -= danoPuno * 2; 
                }
                else {
                    // Debug.Log("Di un conazo suave");
                    hp -= danoPuno;
                }
            }
        }

    if (hp <= 0){
        KO.Play();
        anim.SetTrigger("knockout");
    }
    }
    private void notAnimating(){ //se ejecuta al casi finalizar la animacion de JabCross
        isAnimating = false;
    }

    private int GetRandomNum(int min, int max){
        System.Random rand = new();
        int num = rand.Next(min, max); //creara un random entre 0 y 10
        
        return num;
    }
    public void ActualizarBarraVida(){
        barraVida.fillAmount = hp / maxHp;
    }

    public void SubirNivel(){
        maxHp = maxHp * 1.1f;
        hp = maxHp;
        
    }
    public void notKnockout(){
        isKnockout = false;
    }
}

}