using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Collider : MonoBehaviour
{
    private TilemapRenderer _col;
    // Start is called before the first frame update
    void Start()
    {
        _col = GameObject.Find("Tilemap Collider").GetComponent<TilemapRenderer>();
        _col.enabled = false;
    }
}
