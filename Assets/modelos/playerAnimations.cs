using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour
{
    private Animator animator;
    private Vector3 actualPosition;
    private bool isWalking;

    void Start()
    {
        animator = GetComponent<Animator>();
        actualPosition = transform.position;
    }

    void Update()
    {

        if (transform.position != actualPosition)
        {
            isWalking = true;
            actualPosition = transform.position;
        }
        else { 
            isWalking= false;
        }
        animator.SetBool("isWalking", isWalking);
        Debug.Log(isWalking.ToString());
    }
}
