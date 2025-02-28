using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public GameObject boolCubeObj;
    public GameObject triggerCubeObj;
    public GameObject pointLight;

    Animator boolCubeToggle;
    Animator floatLightToggle;

    public bool cubeBool;
    public float cubeFloat;

    // Start is called before the first frame update
    void Start()
    {
        boolCubeToggle = boolCubeObj.GetComponent<Animator>();

        floatLightToggle = pointLight.GetComponent<Animator>();

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

        floatLightToggle.SetFloat("Float", cubeFloat);

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
        }
        else if (cubeFloat >= -1 && cubeFloat <= 1 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Cube is now Green!");
        }
        else if (cubeFloat >= 2 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Cube is now Blue!");
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
