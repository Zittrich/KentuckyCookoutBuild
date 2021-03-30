using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookAnimator : MonoBehaviour
{
    public Animator anim;
    Vector3 prevPos;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if ((transform.position - prevPos).magnitude > 0.001f)
        {
            anim.SetInteger("condition", 1);
        }
        else
        {
            anim.SetInteger("condition", 0);
        }
        prevPos = transform.position;
    }
}
