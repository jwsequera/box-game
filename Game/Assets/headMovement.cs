using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMovement : MonoBehaviour
{   
    public float velocidad = 1f;
    private GameObject head;
    private Transform headTransform;
    // Start is called before the first frame update
    void Start()
    {
        head = GameObject.Find("Wolf3D_Head");
        headTransform = head.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la entrada del teclado o cualquier otro método para controlar el movimiento
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Calcular el desplazamiento en la dirección horizontal
        float desplazamiento = movimientoHorizontal * velocidad * Time.deltaTime;

        // Obtener la referencia al componente Transform de la cabeza
        Transform transformCabeza = transform;

        // Mover la cabeza en la dirección horizontal
        transformCabeza.Translate(Vector3.right * desplazamiento);
    }
}
