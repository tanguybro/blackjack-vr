using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    public float _speed = 10.0f;
    private float _angle = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _angle += _speed * Time.deltaTime;
        //Transform t = this.GetComponent<Transform>();
        //this.gameObject.transform
        //this.transform

        _angle += 1.0f;
        this.transform.localRotation = Quaternion.Euler(0.0f,_angle, 0.0f);
    }
}
