using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;



public class gun_function : MonoBehaviour
{
    private Transform aimTransform;
    // Start is called before the first frame update
    private void Start()
    {
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
   private void Update()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);
    }
}
