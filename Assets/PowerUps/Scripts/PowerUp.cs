using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public void RotatePowerUps()
    {
        Vector3 rotate = new Vector3(0f, 100f, 0f);
        transform.Rotate(rotate * Time.deltaTime);
    }

}
