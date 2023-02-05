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
<<<<<<< Updated upstream
=======
    }

    public GameObject BouncerBullet;
    private Transform aimTransform;
    private Animator aimAnimator;
    public Transform aimGunEndPointTransform;

    public void FireBullet()
    {
      
        GameObject Bang_BouncerBullet = Instantiate(BouncerBullet, aimGunEndPointTransform.position, Quaternion.identity);

>>>>>>> Stashed changes
    }
    public void Start(){
        aimTransform = transform.Find("Gun");
        aimGunEndPointTransform = aimTransform.Find("GunEndPointPosition");
    }
    public float speed = 5f;
    private void Update() {
    
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);


<<<<<<< Updated upstream
    public GameObject BouncerBullet;
    private Transform aimTransform;
    private Animator aimAnimator;
    public Transform aimGunEndPointTransform;

    public void FireBullet()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        GameObject Bang_BouncerBullet = Instantiate(BouncerBullet, aimGunEndPointTransform.position, Quaternion.identity);

    }
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
            FireBullet();
        

=======
 
        HandleShooting();
  
    }
 
    private void HandleShooting() { 
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        

>>>>>>> Stashed changes
        }
    }

}
