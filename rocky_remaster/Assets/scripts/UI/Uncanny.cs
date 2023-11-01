using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Uncanny : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uncanny_text;
    public int uncanny_number;
    public int max_uncanny;

    // Start is called before the first frame update
    void Awake()
    {
       
    }

    private void Start()
    {
        
    }

    //ADDS UNCANNY
    public void AddUncanny()
    {
        uncanny_number++;
    }

    //SET UNCANNY UI TEXT
    void Update()
    {

        if (uncanny_number > 0) {
            uncanny_text.text = "Uncanny counter: " + uncanny_number.ToString();
        }

        if (uncanny_number > max_uncanny) {
            uncanny_number = max_uncanny;
        }
    }
}
