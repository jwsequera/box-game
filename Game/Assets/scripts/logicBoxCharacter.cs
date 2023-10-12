using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicBoxCharacter : MonoBehaviour
{

    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;
    public bool isAnimating;
    public string trigger;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);


        if (Input.GetKeyDown(KeyCode.G) && !isAnimating){
            Animating("bodyJabCross");
        }

        if (Input.GetKeyDown(KeyCode.H) && !isAnimating){
            Animating("ComboPunch");
            Debug.Log("EJECUTANDO COMBOPUNCH");
        }

        if (Input.GetKeyDown(KeyCode.L) && !isAnimating){
            Animating("LeadJab");
            Debug.Log("EJECUTANDO LeadJab");
        }
        
        if (Input.GetKeyDown(KeyCode.F) && !isAnimating){
            Animating("ReceivingUppercut");
            Debug.Log("Recibiendo Conazo");
        }

        Debug.Log("Estado de Animacion: " + isAnimating);
    }

    private void Animating(string trigger){
        anim.SetTrigger(trigger);
        Debug.Log("Ejecutando " + trigger);
        isAnimating = true;
    }

    private void notAnimating(){ //se ejecuta al casi finalizar la animacion de JabCross
        isAnimating = false;
    }
}
