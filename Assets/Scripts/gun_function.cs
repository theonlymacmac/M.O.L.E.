using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class gun_function : MonoBehaviour{

    public event EventHandler <OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }

    private Transform aimTransform;
    private Animator aimAnimator;
    public Transform aimGunEndPointTransform;

    public void Start(){
        aimTransform = transform.Find("Gun");
        aimAnimator = aimTransform.GetComponent<Animator>();
        aimGunEndPointTransform = aimTransform.Find("GunEndPointPosition");
    }

    private void Update() {        
        HandleAiming();
        HandleShooting();
    }
   private void HandleAiming() {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();       
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
       // Debug.Log(angle);
    }
    private void HandleShooting() { 
        if (Input.GetMouseButtonDown(0))
        {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        

        }
    }

}
