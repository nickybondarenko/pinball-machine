using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;
    //This one is connected to the Input keys: if a or d are pressed, flipper works. Codes for the keys: LFlipper, RFlipper
    public string inputName;

    HingeJoint hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }


    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

        //Check if the button is pressed
        if (Input.GetAxis(inputName) == 1)
        {
            spring.targetPosition = pressedPosition;
        }
        else
        {
            spring.targetPosition = restPosition;
        }

        hinge.spring = spring;
        hinge.useLimits = true;

    }
}
