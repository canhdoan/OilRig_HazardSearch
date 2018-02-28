using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveHandAnimations : MonoBehaviour
{
    private Valve.VR.InteractionSystem.Hand m_parentHand;
    private Animator m_animator;

    void Start ()
    {
        m_parentHand = GetParentHand(gameObject);
        m_animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        m_animator.SetBool("Pointing", m_parentHand.GetStandardInteractionButton());
	}

    private Valve.VR.InteractionSystem.Hand GetParentHand(GameObject childObject)
    {
        Valve.VR.InteractionSystem.Hand parentHand = childObject.GetComponentInParent<Valve.VR.InteractionSystem.Hand>();

        if (parentHand != null)
            return parentHand;

        else
            return GetParentHand(childObject.transform.parent.gameObject);
    }
}
