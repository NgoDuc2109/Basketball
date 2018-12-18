using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour {
    public Animator anim;

    public void end()
    {
        anim.Play("Move");
    }
}
