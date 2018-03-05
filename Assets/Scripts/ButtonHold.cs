using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(UIElement))]
public class ButtonHold : MonoBehaviour
{
    private UIElement m_button;
    public Image m_loadingImage;
    private Color m_loadingImageColor;

    public float m_holdTime;
    private float m_timer;

    public bool m_rapidReset;

    public UnityEngine.Events.UnityEvent m_onHeldClick;
    

	void Start ()
    {
        m_button = GetComponent<UIElement>();
        m_loadingImageColor = m_loadingImage.color;
        m_timer = 0;

        m_button.onHandClick.RemoveAllListeners();
        m_button.onHandClick.AddListener(StartHoldTimer);
	}
	
	void Update ()
    {
        if(m_timer > 0)
        {
            m_timer -= m_rapidReset ? m_timer : Time.deltaTime;
        }

        UpdateLoadingImageColor();
	}

    private void UpdateLoadingImageColor()
    {
        m_loadingImageColor.a = m_timer / m_holdTime;
        m_loadingImage.color = m_loadingImageColor;
    }

    public void StartHoldTimer(Hand hand)
    {
        StartCoroutine(_HoldTimer(hand));
    }

    public IEnumerator _HoldTimer(Hand hand)
    {
        while(hand.GetStandardInteractionButton())
        {
            m_timer += Time.deltaTime;

            if(m_timer >= m_holdTime)
            {
                m_onHeldClick.Invoke();
            }

            yield return null;
        }
    }
}
