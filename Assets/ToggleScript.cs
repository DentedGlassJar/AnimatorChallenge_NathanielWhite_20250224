using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScript : MonoBehaviour
{
    public GameObject cubeObj;
    Animator cubeToggle;

    bool cubeBool;

    // Start is called before the first frame update
    void Start()
    {
        cubeToggle = cubeObj.GetComponent<Animator>();

        cubeBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cubeToggle.GetBool("Rotate") == false && Input.GetKeyDown(KeyCode.Tab))
        {
            cubeBool = true;
        }

        if (cubeToggle.GetBool("Rotate") == true && Input.GetKeyDown(KeyCode.Tab))
        {
            cubeBool = false;
        }

        if (cubeBool == true)
        {
            cubeToggle.SetBool("Rotate", true);
        }
        else
        {
            cubeToggle.SetBool("Rotate", false);
        }
    }
}
