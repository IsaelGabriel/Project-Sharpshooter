using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : SignalHandler
{

    public float mouseSensitivity = 70f;

    public Transform head;
    private float headAngle = 0f;
    private Rigidbody rb;


    //Movement
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpPower = 200f;
    [HideInInspector] public bool grounded = true;
    private float moveMult = 1f;

    //Shooting
    public Transform bulletSpawn;
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Cursor.visible) return;
        Move();
        ManageCamera();
        Shoot();
    }

    void Move()
    {
        moveMult = (Input.GetAxis("Horizontal") != 0f && Input.GetAxis("Vertical") != 0f)? 0.7f : 1f;

        transform.position += transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime * moveMult;
        transform.position += transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * moveMult;
        
       
        if(grounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * jumpPower);
            //grounded = false;
        }
    }

    void ManageCamera()
    {
        transform.Rotate(new Vector3(0f,Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime, 0f));
        headAngle += (Input.GetAxis("Mouse Y") * -mouseSensitivity * Time.deltaTime);
        headAngle = Mathf.Clamp(headAngle,-90f,80f);
        head.eulerAngles = new Vector3(headAngle, head.eulerAngles.y,head.eulerAngles.z);
    }

    void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            var newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = bulletSpawn.position;
            newBullet.transform.rotation = bulletSpawn.rotation;
        }
    }

    protected override void ReceiveSignal(string signal)
    {
        if(signal.Contains("PlayerGrounded"))
        {
            grounded = (!signal.Contains("!"));
            return;
        }
    }


/*
    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.name == "Ground")
        {
            grounded = true;
        }
    }*/
}
