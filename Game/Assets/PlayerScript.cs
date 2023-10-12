using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Obtén la transformación del hueso que quieres mover.
        // Por ejemplo, estamos obteniendo el hueso del brazo derecho.
        Transform brazoDerecho = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
        Console.WriteLine(brazoDerecho);

        // Ahora puedes mover el hueso como quieras. Por ejemplo, puedes rotarlo.
        brazoDerecho.Rotate(0, Time.deltaTime * 5, 0);
    }
}
