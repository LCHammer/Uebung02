using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Transform _transform;
    Camera _camera;
    public int _speed;
    public Projectile prefab;
    private float _coolDownTime = 1;
    private float _fireTime = 0;

    void Start()
    {
        this._transform = transform;
        this._camera = Camera.main;
    }

    //Standard UpdateLoop (once per Frame)
    void Update()
    {
        
        this.Rotate();
        if (Input.GetKey(KeyCode.W))
        {
            this._transform.position += new Vector3(0, 1, 0) * _speed* Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this._transform.position += new Vector3(-1, 0, 0) * _speed* Time.deltaTime;
        }if (Input.GetKey(KeyCode.S))
        {
            this._transform.position += new Vector3(0, -1, 0) * _speed* Time.deltaTime;
        }if (Input.GetKey(KeyCode.D))
        {
            this._transform.position += new Vector3(1, 0, 0) * _speed* Time.deltaTime;
        }
           if (Input.GetMouseButtonDown(0) && Time.time > _fireTime)   
        {
            _fireTime = Time.time + _coolDownTime;

            Vector2 mousePos = this._camera.ScreenToWorldPoint(Input.mousePosition);
            Projectile p = Instantiate(prefab, this._transform.position, Quaternion.identity);
            p.Init(new Vector3(mousePos.x - this._transform.position.x, mousePos.y - this._transform.position.y, 0));
            Destroy(p, 5.0f);
        }
    }

        

    void Rotate(){
        Vector2 mousePos = this._camera.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - this._transform.position.y, mousePos.x - this._transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        this._transform.rotation = Quaternion.Euler(0, 0, angleDeg - 90);//diese -90 sind nötig für Sprites, die nach oben zeigen. Nutzen Sie andere Assets, könnte es sein, dass die das anpassen müssen
        
    }
}
