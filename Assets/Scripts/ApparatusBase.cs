using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparatusBase : MonoBehaviour
{
    public virtual void startBehvaior()
    {

    }

    public virtual void updateBehavior()
    {

    }

    private void Update()
    {
        updateBehavior();
    }

    private void Start()
    {
        startBehvaior();
    }

    public virtual void triggerEnterBehavior(Collider2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEnterBehavior(collision);
    }

    public virtual void triggerStayBehavior(Collider2D collision)
    {
        float incAngle = collision.transform.eulerAngles.z;
        if (incAngle > 179 && incAngle < 181)
        {
            reflection180(collision);
        }
        else if (incAngle > -1 && incAngle < 1 || incAngle > 359 && incAngle < 361)
        {
            reflection000(collision);
        }
        else if (incAngle > 89 && incAngle < 91)
        {
            reflection090(collision);
        }
        else if (incAngle > 269 && incAngle < 271)
        {
            reflection270(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    protected virtual void reflection180(Collider2D collision) { }
    protected virtual void reflection000(Collider2D collision) { }
    protected virtual void reflection090(Collider2D collision) { }
    protected virtual void reflection270(Collider2D collision) { }

}
