using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
#region Singleton
    private static ScoreManager _instance;

    public static ScoreManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<ScoreManager>();
            
            return _instance;
        }
    }

    private void Awake()
    {
        if (instance != this) Destroy(gameObject);
    }
#endregion


#region Attributes

    private int currentScore;

    public int m_currentScore
    {
        get { return currentScore; }

        set
        {
            currentScore = value;

            foreach(UnityEngine.UI.Text textBox in m_scoreTextBoxes)
            {
                textBox.text = currentScore.ToString();
            }
        }
    }

    public UnityEngine.UI.Text[] m_scoreTextBoxes;

 #endregion
}
