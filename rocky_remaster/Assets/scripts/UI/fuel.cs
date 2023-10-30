using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fuel_text;
    public CharacterController2D playermovement;
    // Start is called before the first frame update
    void Awake()
    {
        playermovement.onBoost += OnBoost;
       
    }
    
    private void OnBoost(int fuel_number)
    {
        //animator.SetBool("isJumping", true);
        fuel_text.text = fuel_number.ToString();
    }

    // Update is called once per frame
    void Update()
    {
            
        
    }
}
