using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermove : MonoBehaviour
{
    //public CharacterController mycharactercontroller;
    public float sideways;
    public float forward;
    public float xmouse;
    public float ymouse;
    //public Transform upperbody;
    public float rotationvalue;
    Animator myanimator;
    Rigidbody myrigidbody;
    public Joystick myjoystick;
    public float zvalue;
    public float xvalue;
    // Start is called before the first frame update
    void Start()
    {
        myanimator = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        sideways = myjoystick.Horizontal;
        //forward = Input.GetAxisRaw("Vertical");
        forward = myjoystick.Vertical;
        //Debug.DrawRay();
        //////////////////////////////////////////
        if (forward != 0)
        {
            if (forward >= 0 && forward <= 0.9f)
            {
                if (zvalue <= 0.1f)
                {
                    zvalue += Time.deltaTime;
                }
            }
            if (forward <= 0 && forward >= -0.9f)
            {
                if (zvalue >= -0.1f)
                {
                    zvalue -= Time.deltaTime;
                }
            }
            if(forward>0.9f )
            {
                zvalue = 1f;
            }
        }
        else
        if(forward==0)
        {
            zvalue = 0f;
        }
        ////////////////////////////////////////////////

        if (sideways != 0)
        {
            if (sideways >= 0 && sideways <= 1)
            {
                if (xvalue <= 1f)
                {
                    xvalue += Time.deltaTime;
                }
            }
            if (sideways <= 0 && sideways >= -1)
            {
                if (xvalue >= -1f)
                {
                    xvalue -= Time.deltaTime;
                }
            }
            //if (forward > 0.9f)
            //{
            //    xvalue = 1f;
            //}
        }
        else if (sideways == 0)
        {
            xvalue = 0f;
        }
        if (sideways != 0 && forward != 0)
        {
            myrigidbody.velocity = new Vector3(sideways, myrigidbody.velocity.y, forward);
        }
        else
        {
            myrigidbody.velocity = Vector3.zero;
        }
        myanimator.SetFloat("movez",zvalue);
        myanimator.SetFloat("movex", xvalue);
      
        
    }

}
