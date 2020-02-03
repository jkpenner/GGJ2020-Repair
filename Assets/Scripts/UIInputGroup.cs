using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputGroup : MonoBehaviour {
    [SerializeField] GameObject keyboard;
    [SerializeField] GameObject gamepad;
    public bool IsUsingKeyboard { get; private set; }

    private void Awake() {
        IsUsingKeyboard = Gamepad.current == null;
        UpdateGameUI(IsUsingKeyboard);
    }

    
    private void Update()
    {
        if ((Gamepad.current == null) != IsUsingKeyboard)
        {
            UpdateGameUI(Gamepad.current == null);
        }
    }

    private void UpdateGameUI(bool isUsingKeyboard)
    {
        this.IsUsingKeyboard = isUsingKeyboard;
        if (this.IsUsingKeyboard)
        {
            keyboard.SetActive(true);
            gamepad.SetActive(false);
        }
        else
        {
            keyboard.SetActive(false);
            gamepad.SetActive(true);
        }
    }
}
