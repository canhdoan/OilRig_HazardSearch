using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonHold : MonoBehaviour
{
    private Button m_button;
    public float m_holdTime;
    private float m_timer;
    public bool m_rapidReset;

	void Start ()
    {
        m_button = GetComponent<Button>();
	}
	
	void Update ()
    {
		
	}
}
