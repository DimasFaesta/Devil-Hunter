using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class GerakanTPS : NetworkBehaviour
{

    public DataKarakter _dataKarakter = new DataKarakter()
    {
        kecepatan = 2,
        Health = 10,
    };

    private CharacterController Movemen;
    private Vector2 _arahJalan;
    private Vector2 _arahAim;

    [SerializeField]
    private LayerMask layer;

    private bool _isAiming;
    private bool _dashInAir;
    public bool _isDashing;
    private bool _isWithMouse;

    float gravitasi;

    void Start()
    {
        Movemen = GetComponent<CharacterController>();
        if (isLocalPlayer)
        {
            GetComponent<PlayerInput>().enabled = true;
            GetComponent<CharacterController>().enabled = true;
            Camera.main.GetComponent<cameraFollow>().player = transform;
        }
        else
        {
            
        }
    }

    void Update()
    {
        _dataKarakter.score += 1 * Time.deltaTime;
        napak();
        if (_dataKarakter.Health <= 1)
        {
            NetworkClient.Send(new PlayerStats()
            {
                data = _dataKarakter
                
            });

            Destroy(gameObject);
        }
        Movemen.Move(DirectionBasedCamera(_arahJalan) * _dataKarakter.kecepatan * Time.deltaTime);
    }

    public void GetMoveValue(InputAction.CallbackContext callbackContext)
    {

        _arahJalan.x = callbackContext.ReadValue<Vector2>().x;
        _arahJalan.y = callbackContext.ReadValue<Vector2>().y;
        

        if (!_isAiming)
            Rotasi(_arahJalan);
    }

    public void GetLoncatValue(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
            Loncat();
    }

    public void GetDashValue(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Vector3 arahdash = DirectionBasedCamera(_arahJalan);
            arahdash.y = 0;

            Dash(arahdash);
        }
    }

    private void Dash(Vector3 arahdash)
    {
        if (_isDashing||_dashInAir)
            return;

        if(!napak())
            _dashInAir = true;

        _isDashing = true;
        int a = 1; // INI SUPAYA BISA PAKE DOTWEEN SEBAGAI UPDATE

        DOTween.To(() => a, x => a = x, 2, .2f)
           .OnUpdate(() =>
           {
               Movemen.Move(arahdash * 7 * Time.deltaTime);
               gravitasi = 0;
           }).OnComplete(() =>
           {
               DOTween.To(() => a, x => a = x, 6, .1f).OnComplete(() => {


                   _isDashing = false;
               });
           }
       );
    }

    //private IEnumerator Dash(Vector3 arahdash)
    //{
    //    _isDashing = true;

    //    float time = 0;
    //    float durasi = .6f;
    //    float interval = .1f;

    //    while (time <= durasi)
    //    {
    //        Movemen.Move(arahdash * 2 );
    //        yield return new WaitForSeconds(interval);
    //        time += interval;
    //    }


    //    _isDashing = false;
    //}

    public void GetAimValue(InputAction.CallbackContext callbackContext)
    {
        _arahAim = callbackContext.ReadValue<Vector2>();

        if (_arahAim != Vector2.zero)
            _isAiming = true;
        else
            _isAiming = false;

        Rotasi(_arahAim);

    }



    bool napak()
    {
        if (Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - .8f, transform.position.z), .3f, layer))
        {
            if (_dashInAir)
            {
                _isDashing = false;
                _dashInAir = false;
            }
            return true;
        }
        else
        {
            gravitasi -= 9 * Time.deltaTime;

            //_isJump = true;
            return false;
        }
    }

    void Rotasi(Vector2 input)
    {
        if (input != Vector2.zero)
        {
            transform.eulerAngles = new Vector3(0, AngleBasedCamera(input), 0);
        }
    }

    private Vector3 DirectionBasedCamera(Vector2 input)
    {
        //agar arah jalan player sesuai dari prespektif kamera. 
        float X = (((Mathf.Cos(Camera.main.transform.eulerAngles.y * Mathf.Deg2Rad)) * input.x) +
        (Mathf.Sin(Camera.main.transform.eulerAngles.y * Mathf.Deg2Rad) * input.y));

        float Z = (-((Mathf.Sin(Camera.main.transform.eulerAngles.y * Mathf.Deg2Rad)) * input.x) +
             (Mathf.Cos(Camera.main.transform.eulerAngles.y * Mathf.Deg2Rad) * input.y));

        return new Vector3(X, gravitasi, Z);
    }

    private float AngleBasedCamera(Vector2 input)
    {
        //agar arah jalan player sesuai dari prespektif kamera. 
        float X = (((Mathf.Cos(Camera.main.transform.eulerAngles.y * Mathf.Deg2Rad)) * input.x) +
        (Mathf.Sin(Camera.main.transform.eulerAngles.y * Mathf.Deg2Rad) * input.y));

        float Z = (-((Mathf.Sin(Camera.main.transform.eulerAngles.y * Mathf.Deg2Rad)) * input.x) +
             (Mathf.Cos(Camera.main.transform.eulerAngles.y * Mathf.Deg2Rad) * input.y));

        return Mathf.Atan2(X, Z) * Mathf.Rad2Deg;
    }

    private void Loncat()
    {
        if (napak())
        {
            gravitasi = 3;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp")
        {
            other.GetComponent<IPowerUp>().GetPower(this);
        }
    }
}
