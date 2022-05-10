using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed=5f,walk;
    public Rigidbody2D rb;
    public Animator _animator;
    public Joystick joystick;
    public InventoryObject _inventory;
    public bool isRight = true, isLeft = false;
    Vector2 movement;
    public GameObject inventory,melee;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < _inventory.Container.Count; i++)
        {
            if (_inventory.Container[i].id == 3 )
            {
                melee.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        walk = 0;
        _animator.SetFloat("speed", walk);
        //movement.x = Input.GetAxisRaw("Horizontal");
        movement.x = joystick.Horizontal;
        Debug.Log(movement.x);
        //movement.y = Input.GetAxisRaw("Vertical");
        movement.y = joystick.Vertical;
        for (int i = 0; i < _inventory.Container.Count; i++)
        {
            if (_inventory.Container[i].id == 3)
            {
                melee.SetActive(true);
            }
        }
        if (movement.x >0) {
            
            if (isRight == false)
            {
                isRight = true;
                isLeft = false;
                Flip();
            }
            walk = 5f;
            _animator.SetFloat("speed", walk);
        }
        if (movement.x <0)
        {
            if (isLeft == false)
            {
                isLeft = true;
                isRight = false;
                Flip();
            }
            walk = 5F;
            _animator.SetFloat("speed", walk);
        }
        if (movement.y != 0)
        {
            walk = 5F;
            _animator.SetFloat("speed", walk);
            
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            inventory.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventory.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            _inventory.Load();
        }
    }
    void Flip()
    {
        transform.Rotate(0f, 180f, 0);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<Item>();
        if (item)
        {
            _inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
            melee.SetActive(true);
        }
    }
    private void OnApplicationQuit()
    {
        _inventory.Container.Clear();
    }
}
