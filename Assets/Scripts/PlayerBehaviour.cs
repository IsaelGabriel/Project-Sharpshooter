using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : SignalHandler
{
    
    /// Player view
    public Transform head;
    private float headAngle = 0f;


    /// Movement
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpPower = 200f;
    private bool grounded = true;
    [SerializeField] private Rigidbody rb;

    /// Shooting
    [SerializeField] private Transform bulletSpawn; /// Bullet Spawnpoint
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletCooldown = 0.75f;
    private float bulletCooldownCount = 0f;

    void Update()
    {
        if(Cursor.visible) return;
        if(Time.timeScale <= 0f) return;
        Move();
        ManageCamera();
        Shoot();
    }

    /// Handle all player movement.
    void Move()
    {
        float moveMult = (Input.GetAxis("Horizontal") != 0f && Input.GetAxis("Vertical") != 0f)? 0.7f : 1f; /// Makes sure diagonal movement doesn't give an advantage to the player.

        transform.position += transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime * moveMult;
        transform.position += transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * moveMult;
        
       
        if(grounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * jumpPower);
            SendSignal("PlayerJump");
        }
    }

    /// Handles player view using mouse input.
    void ManageCamera()
    {
        transform.Rotate(new Vector3(0f,Input.GetAxis("Mouse X") * GameManager.mouseSensitivity * Time.deltaTime, 0f));
        headAngle += (Input.GetAxis("Mouse Y") * -GameManager.mouseSensitivity * Time.deltaTime);
        headAngle = Mathf.Clamp(headAngle,-90f,80f); /// Limits player view's x rotation.
        head.eulerAngles = new Vector3(headAngle, head.eulerAngles.y,head.eulerAngles.z);
    }

    void Shoot()
    {
        if(bulletCooldownCount > 0f)
        {
            bulletCooldownCount -= Time.deltaTime;
            return;
        }

        if(Input.GetButton("Fire1"))
        {
            var newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = bulletSpawn.position;
            newBullet.transform.rotation = bulletSpawn.rotation;
            bulletCooldownCount = bulletCooldown;
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

}
