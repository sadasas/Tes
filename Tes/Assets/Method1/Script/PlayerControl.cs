using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    private float distoGround;

    public LayerMask ground;
    public float jumpForce;
    public float lerp;
    public float speed;

    private bool colapse = false;

    [SerializeField]
    private Transform Hand;

    public List<ScriptableItem> itemList = new List<ScriptableItem>();

    private void Awake()
    {
        distoGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public bool Grounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distoGround + 0.1f, ground);
    }

    private void Update()
    {
        movement = new Vector3(0, 0, Input.GetAxis("Horizontal"));
        movement.Normalize();

        if (Input.GetMouseButton(1))
        {
            AttackSpell(0);
            colapse = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded())
            {
                rb.AddForce(transform.up * jumpForce);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
        if (movement.magnitude > 0.1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), lerp);
        }
    }

    private void AttackSpell(int index)
    {
        Debug.Log("Attack Spell");

        if (!colapse)
        {
            GameObject go = Instantiate(itemList[index].prefab, Hand.position, Quaternion.identity);

            go.transform.Translate(transform.forward * 100 * Time.deltaTime, Space.World);
        }
    }
}