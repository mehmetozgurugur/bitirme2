using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Touch touch;
    [Range(20, 40)]
    public int speedModifier;

// Update is called once per frame
public void Update()
{
        if (Variables.firsttouch == 1 && speedballforward == false)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorback.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorforward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }


        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (firsttouchcontrol == false)
                    {
                        Variables.firsttouch = 1;
                        uimanager.FirstTouch();
                        firsttouchcontrol = true;
                    }

                }

            }
            else if (touch.phase == TouchPhase.Moved)
            {

                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                          transform.position.y,
                          touch.deltaPosition.y * speedModifier * Time.deltaTime);

                    if (firsttouchcontrol == false)
                    {
                        Variables.firsttouch = 1;
                        uimanager.FirstTouch();
                        firsttouchcontrol = true;
                    }

                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }

        }
    }
}
