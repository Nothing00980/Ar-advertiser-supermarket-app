using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkoutanim : MonoBehaviour
{
    public Animator animator;


    public void TriggerAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("exit");
        }
    }
}
