using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieBoxCharacterLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp;
    public int danoPuno;
    public Animator anim;
    public bool isAnimating;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isAnimating = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        Debug.Log(other.gameObject.name);

        if(other.gameObject.tag == "ManoDerecha"){
            if(anim != null){
                isAnimating = true;
                if (GetRandomNum(0, 11) >= 8){
                anim.Play("ReceivingABigUppercut");
                Debug.Log("Di un Conazo durisimo");
                hp -= danoPuno * 2; 
                }
                else {
                    anim.Play("receiveLeadJab");
                    Debug.Log("Di un conazo suave");
                    hp -= danoPuno;
                }
            }
        }

        if(other.gameObject.tag == "ManoIzquierda"){
            if(anim != null){
                isAnimating = true;
                if (GetRandomNum(0, 11) >= 8){
                anim.Play("ReceivingABigUppercut");
                Debug.Log("Di un Conazo durisimo");
                hp -= danoPuno * 2; 
                }
                else {
                    anim.Play("receiveLeadJab");
                    Debug.Log("Di un conazo suave");
                    hp -= danoPuno;
                }
            }
        }

    if (hp <= 0){
        Destroy(gameObject);
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
}
