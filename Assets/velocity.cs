using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocity : MonoBehaviour
{

    void Update()
    {
        transform.position += transform.position * 20 * Time.deltaTime;
    }

}
