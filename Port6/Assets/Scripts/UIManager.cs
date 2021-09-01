using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public event Action onStart;

    public bool is_menu_called
    {
        get;
        private set;
    }

    public bool flag_start_game
    {
        get;
        private set;
    }


    public Text text_Score;
    public Text text_Combo;
    public GameObject menu;
    public GameObject canvas_onGame;
    public GameObject dancing_girls;
    private AudioSource audiosource;


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

        audiosource = GetComponent<AudioSource>();

        dancing_girls.SetActive(false);
        canvas_onGame.SetActive(false);

        flag_start_game = false;
        onStart += () => audiosource.Play();

    }

    public void AddScore(int score)
    {
        this.score += score;
        text_Score.text = "" + this.score;
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
        audiosource.Pause();
        ControlDancingPart();
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        is_menu_called = false;
        ControlDancingPart();
        audiosource.Play();
    }

    private void ControlDancingPart()
    {
        Animator[] animators = dancing_girls.GetComponentsInChildren<Animator>();
        float speed_animation = 0f;

        if (is_menu_called) speed_animation = 0f;
        else speed_animation = 1f;

        Debug.Log(animators.Length);

        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].speed = speed_animation;
        }

    }




    public void QuitApp()
    {
        Application.Quit();
    }

    public void ResetCombo()
    {
        text_Combo.text = "" + (combo = 0);
    }


    public void StartGame()
    {
        flag_start_game = true;
        dancing_girls.SetActive(true);
        canvas_onGame.SetActive(true);
        menu.SetActive(is_menu_called = false);
        onStart();        
    }




}
