using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public GameObject boolCubeObj;
    public GameObject floatCubeObj;
    public GameObject triggerCubeObj;

    public GameObject BlueLightObj;
    public GameObject GreenLightObj;
    public GameObject YellowLightObj;

    Animator boolCubeToggle;
    Animator floatLightToggle;

    public bool cubeBool;
    public float cubeFloat;

    // Start is called before the first frame update
    void Start()
    {
        boolCubeToggle = boolCubeObj.GetComponent<Animator>();

        cubeBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        TriggerUpdate();

        FloatUpdate();

        BoolUpdate();
    }

    public void TriggerUpdate()
    {

    }



    public void FloatUpdate()
    {
        cubeFloat += Input.mouseScrollDelta.y;

        if (cubeFloat <= -5)
        {
            cubeFloat = -5;
        }

        if (cubeFloat >= 5)
        {
            cubeFloat = 5;
        }

        if (cubeFloat <= -2 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Cube is now Yellow!");

            BlueLightObj.SetActive(false);
            YellowLightObj.SetActive(false);
            GreenLightObj.SetActive(true);
        }
        else if (cubeFloat >= -1 && cubeFloat <= 1 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Cube is now Green!");

            BlueLightObj.SetActive(false);
            YellowLightObj.SetActive(true);
            GreenLightObj.SetActive(false);
        }
        else if (cubeFloat >= 2 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Cube is now Blue!");

            BlueLightObj.SetActive(true);
            YellowLightObj.SetActive(false);
            GreenLightObj.SetActive(false);
        }
    }
    public void BoolUpdate()
    {
        if (boolCubeToggle.GetBool("Rotate") == false && Input.GetKeyDown(KeyCode.Tab))
        {
            cubeBool = true;
        }

        if (boolCubeToggle.GetBool("Rotate") == true && Input.GetKeyDown(KeyCode.Tab))
        {
            cubeBool = false;
        }

        if (cubeBool == true)
        {
            boolCubeToggle.SetBool("Rotate", true);
        }
        else
        {
            boolCubeToggle.SetBool("Rotate", false);
        }
    }
}
