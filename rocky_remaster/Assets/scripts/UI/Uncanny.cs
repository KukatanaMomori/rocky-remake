using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Uncanny : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uncanny_text;
    //public FullScreenPassRendererFeature distortFeature;
    public int uncanny_number;
    public int max_uncanny;
    public Material Material;
    private float addFloat = 1f;

    // Start is called before the first frame update
    void Awake()
    {
       
    }

    private void OnDestroy()
    {
        Material.SetFloat("_distort", 1);
    }

    private void Start()
    {
        //Material = distortFeature.passMaterial;
    }

    //ADDS UNCANNY
    public void AddUncanny()
    {
        addFloat+=0.01f;
        Material.SetFloat("_distort", addFloat);
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
