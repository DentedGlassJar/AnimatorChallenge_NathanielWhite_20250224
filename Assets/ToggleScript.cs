using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public GameObject boolCubeObj;
    public GameObject pointLightObj;
    public GameObject triggerDoorObj;

    Animator boolCubeToggle;
    Animator floatLightToggle;
    Animator triggerDoorToggle;

    public bool cubeBool;
    public float cubeFloat;

    private bool isSpacePressed;

    // Start is called before the first frame update
    void Start()
    {
        boolCubeToggle = boolCubeObj.GetComponent<Animator>();

        floatLightToggle = pointLightObj.GetComponent<Animator>();

        triggerDoorToggle = triggerDoorObj.GetComponent<Animator>();

        cubeBool = false;

        isSpacePressed = false;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            triggerDoorToggle.SetTrigger("Trigger");
            Debug.Log("Trigger has been pressed!");
        }
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
