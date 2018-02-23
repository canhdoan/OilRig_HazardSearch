using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationSpeedRandomizer : MonoBehaviour
{
	void Start ()
    {
        GetComponent<Animator>().speed *= Random.Range(.5f, 1f);
	}
}
