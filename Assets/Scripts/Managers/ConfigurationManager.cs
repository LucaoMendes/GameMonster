using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationManager : MonoBehaviour
{
    public static ConfigurationManager Instance;

    private enum ConfigPrefs{
        UP_BUTTON,
        DOWN_BUTTON,
        LEFT_BUTTON,
        RIGHT_BUTTON
    }

    private readonly static KeyCode DEFAULT_UP_BUTTON = KeyCode.W;
    private readonly static KeyCode DEFAULT_DOWN_BUTTON = KeyCode.S;
    private readonly static KeyCode DEFAULT_LEFT_BUTTON = KeyCode.A;
    private readonly static KeyCode DEFAULT_RIGHT_BUTTON = KeyCode.D;



    [Header("Configurações de Teclas")]
    [SerializeField] private KeyCode upButton = DEFAULT_UP_BUTTON;
    [SerializeField] private KeyCode downButton = DEFAULT_DOWN_BUTTON;
    [SerializeField] private KeyCode leftButton = DEFAULT_LEFT_BUTTON;
    [SerializeField] private KeyCode rightButton = DEFAULT_RIGHT_BUTTON;

    public KeyCode UpButton { get => upButton; set {
        upButton = value;
        SaveKeyboardPrefs();
    }}
    public KeyCode DownButton { get => downButton; set {
        downButton = value;
        SaveKeyboardPrefs();
    }}
    public KeyCode LeftButton { get => leftButton; set {
        leftButton = value;
        SaveKeyboardPrefs();
    }}
    public KeyCode RightButton { get => rightButton; set {
        rightButton = value;
        SaveKeyboardPrefs();
    }}

    
    void Awake()
    {
        Instance = this;
        LoadKeyboardPrefs();
    }

    public void LoadKeyboardPrefs(){
        if(PlayerPrefs.HasKey(ConfigPrefs.UP_BUTTON.ToString()))
            upButton = (KeyCode) PlayerPrefs.GetInt(ConfigPrefs.UP_BUTTON.ToString());
        else{
            upButton = DEFAULT_UP_BUTTON;
            PlayerPrefs.SetInt(ConfigPrefs.UP_BUTTON.ToString(), (int) upButton);
        }

        if(PlayerPrefs.HasKey(ConfigPrefs.DOWN_BUTTON.ToString()))
            downButton = (KeyCode) PlayerPrefs.GetInt(ConfigPrefs.DOWN_BUTTON.ToString());
        else{
            downButton = DEFAULT_DOWN_BUTTON;
            PlayerPrefs.SetInt(ConfigPrefs.DOWN_BUTTON.ToString(), (int) downButton);
        }

        if(PlayerPrefs.HasKey(ConfigPrefs.LEFT_BUTTON.ToString()))
            leftButton = (KeyCode) PlayerPrefs.GetInt(ConfigPrefs.LEFT_BUTTON.ToString());
        else{
            leftButton = DEFAULT_LEFT_BUTTON;
            PlayerPrefs.SetInt(ConfigPrefs.LEFT_BUTTON.ToString(), (int) leftButton);
        }

        if(PlayerPrefs.HasKey(ConfigPrefs.RIGHT_BUTTON.ToString()))
            rightButton = (KeyCode) PlayerPrefs.GetInt(ConfigPrefs.RIGHT_BUTTON.ToString());
        else{
            rightButton = DEFAULT_RIGHT_BUTTON;
            PlayerPrefs.SetInt(ConfigPrefs.RIGHT_BUTTON.ToString(), (int) rightButton);
        }
    }

    public void SaveKeyboardPrefs(){
        PlayerPrefs.SetInt(ConfigPrefs.UP_BUTTON.ToString(), (int) upButton);
        PlayerPrefs.SetInt(ConfigPrefs.DOWN_BUTTON.ToString(), (int) downButton);
        PlayerPrefs.SetInt(ConfigPrefs.LEFT_BUTTON.ToString(), (int) leftButton);
        PlayerPrefs.SetInt(ConfigPrefs.RIGHT_BUTTON.ToString(), (int) rightButton);
        SavePrefs();
    }

    public void SavePrefs(){
        PlayerPrefs.Save();
    }  

    void OnValidate()
    {
        bool showWarning = false;

        if(upButton == downButton){
            if(upButton == DEFAULT_UP_BUTTON)
                downButton = DEFAULT_DOWN_BUTTON;
            else
                upButton = DEFAULT_UP_BUTTON;

            showWarning = true;
        }

        if(upButton == leftButton){
            if(upButton == DEFAULT_UP_BUTTON)
                leftButton = DEFAULT_LEFT_BUTTON;
            else
                upButton = DEFAULT_UP_BUTTON;
            
            showWarning = true;
        }

        if(upButton == rightButton){
            if(upButton == DEFAULT_UP_BUTTON)
                rightButton = DEFAULT_RIGHT_BUTTON;
            else
                upButton = DEFAULT_UP_BUTTON;

            showWarning = true;
        }

        if(downButton == leftButton){
            if(downButton == DEFAULT_DOWN_BUTTON)
                leftButton = DEFAULT_LEFT_BUTTON;
            else
                downButton = DEFAULT_DOWN_BUTTON;

            showWarning = true;
        }

        if(downButton == rightButton){
            if(downButton == DEFAULT_DOWN_BUTTON)
                rightButton = DEFAULT_RIGHT_BUTTON;
            else
                downButton = DEFAULT_DOWN_BUTTON;

            showWarning = true;
        }

        if(rightButton == leftButton){
            if(rightButton == DEFAULT_RIGHT_BUTTON)
                leftButton = DEFAULT_LEFT_BUTTON;
            else
                rightButton = DEFAULT_RIGHT_BUTTON;

            showWarning = true;
        }

        if(showWarning)
            Debug.LogWarning("Teclas de movimento não podem ser iguais. Teclas resetadas para as padrões.");

        SaveKeyboardPrefs();
    }


}
