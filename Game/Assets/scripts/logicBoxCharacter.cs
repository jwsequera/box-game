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
    public bool isBlocking;
    public string trigger;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isAnimating = false;

        //desactivamos colliders para evitar falsos golpes
        DesactivarManoDerecha();
        DesactivarManoIzquierda();
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


        if (Input.GetKeyDown(KeyCode.H) && !isAnimating){
            Animating("BodyJabCross"); //golpe con derecha
        }

        if (Input.GetKeyDown(KeyCode.G) && !isAnimating){
            Animating("BodyJabCrossMirror"); //golpe con izquierda
            Debug.Log("EJECUTANDO COMBOPUNCH");
        }

        if (Input.GetKeyDown(KeyCode.N) && !isAnimating){
            Animating("LeadJabMirror"); //golpe con derecha
            Debug.Log("EJECUTANDO LeadJab");
        }
        
        if (Input.GetKeyDown(KeyCode.B) && !isAnimating){
            Animating("LeadJab"); //Golpe Con izquierda
            Debug.Log("EJECUTANDO LeadJabMirror");
        }

        if (Input.GetKeyDown(KeyCode.L) && !isAnimating){
            Blocking();
            Debug.Log("Bloqueando");
        }

        Debug.Log("Estado de Animacion: " + isAnimating);
    }

    private void Animating(string trigger){
        anim.SetTrigger(trigger);
        Debug.Log("Ejecutando " + trigger);
        isAnimating = true;
    }

    private void Blocking(){
        anim.SetTrigger("BodyBlock");
        Debug.Log("Bloqueando");
        isAnimating = true;
    }

    private void notAnimating(){ //se ejecuta al casi finalizar la animacion de JabCross
        isAnimating = false;
    }

    private void NotBlocking() {
        isBlocking = false;
    }

    private void ActivarManoIzquierda(){
        GameObject objeto = GameObject.FindGameObjectWithTag("ManoIzquierda");
        Collider collider = objeto.GetComponent<Collider>();
        collider.enabled = true;
    }
    private void DesactivarManoIzquierda(){
        GameObject objeto = GameObject.FindGameObjectWithTag("ManoIzquierda");
        Collider collider = objeto.GetComponent<Collider>();
        collider.enabled = false;
    }
    private void ActivarManoDerecha(){
        GameObject objeto = GameObject.FindGameObjectWithTag("ManoDerecha");
        Collider collider = objeto.GetComponent<Collider>();
        collider.enabled = true;
    }
    private void DesactivarManoDerecha(){
        GameObject objeto = GameObject.FindGameObjectWithTag("ManoIzquierda");
        Collider collider = objeto.GetComponent<Collider>();
        collider.enabled = false;
    }
}
