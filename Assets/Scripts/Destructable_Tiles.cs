using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Destructable_Tiles : MonoBehaviour{

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Bullet"){
            if(gameObject.tag == "Destructable"){
                Debug.Log("HIT");
                Destroy(gameObject);
            }
        }
    }


    
    // [SerializeField] private LayerMask tileLayer;
    // [SerializeField] private float raycastLength = 1f;
    // [SerializeField] private float fireRate = 0.5f;

    // public Tilemap destructableTilemap;
    // public Tilemap rootTilemap;
    // private float timeSinceLastDig = 0f;

    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Debug.Log("Yes");
    //         if (Time.time >= timeSinceLastDig + fireRate)
    //         {
    //             timeSinceLastDig = Time.time;
    //             Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //             Vector2 rayDirection = (mousePosition - (Vector2)transform.position).normalized;
    //             RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, raycastLength, tileLayer);
    //             if (hit.collider != null &&)
    //             {
    //                 Vector3 hitPosition = hit.point;
    //                 destructableTilemap.SetTile(destructableTilemap.WorldToCell(hitPosition), null);
    //             }
    //         }
    //     }
    // }
}