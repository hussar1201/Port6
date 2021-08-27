using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool is_menu_called
    {
        get;
        private set;
    }
    public Text text_Score;
    public Text text_Combo;
    public GameObject menu;

    public int score
    {
        get;
        private set;
    }

    public int combo
    {
        get;
        private set;
    }


    private static UIManager m_instance;

    public static UIManager instance
    {
        get
        {
            if (m_instance == null) m_instance = FindObjectOfType<UIManager>();
            return m_instance;
        }
    }

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        menu.SetActive(false);
    }

    public void AddScore(int score)
    {
        this.score += score;
        text_Score.text = "" + score;
        AddCombo();
    }

    private void AddCombo()
    {
        text_Combo.text = "" + (++combo);
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        is_menu_called = true;
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        is_menu_called = false;
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    
    public void ResetCombo()
    {
        text_Combo.text = "" + (combo=0);
    }




}
