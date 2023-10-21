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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "ManoDerecha"){
            if(anim != null){
                isAnimating = true;
                anim.Play("ReceivingABigUppercut");
            }
            hp -= danoPuno;
        }

    if (hp <= 0){
        Destroy(gameObject);
    }
    }
    private void notAnimating(){ //se ejecuta al casi finalizar la animacion de JabCross
        isAnimating = false;
    }
}
