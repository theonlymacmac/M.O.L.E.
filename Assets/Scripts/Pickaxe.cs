using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pickaxe : MonoBehaviour{

    [SerializeField] private LayerMask tileLayer;
    [SerializeField] private float raycastLength = 1f;

    private void Update(){
        if (Input.GetMouseButtonDown(1)){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePosition - (Vector2)transform.position, raycastLength, tileLayer);
            if(hit.collider != null){
                // Tile break logic here
            }
        }
    }
}
