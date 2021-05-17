using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

    public float speed;
    public Renderer rend;

    
    void Update() {
        rend.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);
        
    }
}
