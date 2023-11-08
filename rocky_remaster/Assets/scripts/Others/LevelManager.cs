using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public CharacterController2D controller;
    public string sceneName;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("buttonName").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.fuel_number == 0)
        {
            button.gameObject.SetActive(true);
        }
    }
    public void changeScene()
    {
        print("cacat");
        SceneManager.LoadScene(sceneName);

    }
    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
