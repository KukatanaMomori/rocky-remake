using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour {

    [SerializeField] TextMeshProUGUI fuel_text;
    public CharacterController2D playermovement;

    void Awake() {
        playermovement.onBoost += OnBoost;
    }
    
    //UPDATE FUEL TEXT NUMBER
    private void OnBoost(int fuel_number) {
        //animator.SetBool("isJumping", true);
        fuel_text.text = fuel_number.ToString();
    }

    void Update() {
            
    }
}