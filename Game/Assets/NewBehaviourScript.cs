using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator != null) {
             Debug.Log("Animator encontrado");
        }
        else {
            Debug.Log("Animator no encontrado la ptm");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Obtén la transformación del hueso que quieres mover.
        // En este caso, estamos obteniendo el hueso de la mano derecha.
        Transform manoDerecha = animator.GetBoneTransform(HumanBodyBones.RightHand);

        // Ahora puedes mover el hueso como quieras. Por ejemplo, puedes rotarlo.
        manoDerecha.Rotate(0, Time.deltaTime * 50, 0);
    }
}
