using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 _direction;
    Transform _transform;
    Camera _camera;
    
    //We set values in a Init method. Virtual, so we can extend it later :)
    public virtual Projectile Init(Vector3 direction){
        this._direction = direction;
        this.Rotate();
        /*
        Your Code here
        */
        return this;
    }

    void Start()
    {
        this._transform = this.transform;
        this._camera = Camera.main;
        this.Rotate();
        Destroy(gameObject, 15f);
    }

    void Update()
    {
        this._transform.position += this._direction*Time.deltaTime;
    }

    
    void Rotate(){
        Vector3 pos = this._transform.position + this._direction;
        float AngleRad = Mathf.Atan2(pos.y - this._transform.position.y, pos.x - this._transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this._transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }
}
