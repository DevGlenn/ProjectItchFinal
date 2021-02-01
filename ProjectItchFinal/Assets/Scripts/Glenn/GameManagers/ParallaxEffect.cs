using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, startPos;
    [SerializeField] private GameObject camera;
    [SerializeField] private float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x; // set the start position of the background
        length = GetComponent<SpriteRenderer>().bounds.size.x; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // float temp = (camera.transform.position.x * (1 - parallaxEffect));
        float distance = (camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
       
    }
}
