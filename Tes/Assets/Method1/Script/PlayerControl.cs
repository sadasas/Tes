using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;

    private Rigidbody rb;
    private Vector3 movement;
    private float distoGround;

    public LayerMask ground;
    public float jumpForce;

    [Range(0f, 1f)]
    public float lerp;

    public float gravityWorld = -9.8f;
    public float speed;
    public float rangePelor;
    public float TweenTime;
    public float countdown;
    public ScriptableHealt health;

    private bool colapse = false;
    private GameObject pelor;

    [SerializeField]
    private Transform Hand;

    public List<ScriptableItem> itemList = new List<ScriptableItem>();

    private void Awake()
    {
        instance = this;
        distoGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Start()
    {
        Physics.gravity = new Vector3(0, gravityWorld, 0);
        rb = GetComponent<Rigidbody>();
    }

    public bool Grounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distoGround + 0.1f, ground);
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        movement = new Vector3(0, 0, Input.GetAxis("Horizontal"));
        movement.Normalize();

        if (Input.GetMouseButton(1))
        {
            colapse = false;
            AttackSpell(0);
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

        if (!colapse && countdown <= 0)
        {
            pelor = Instantiate(itemList[index].prefab, Hand.position, Quaternion.identity);
            LeanTween.moveLocal(pelor, transform.forward * rangePelor, TweenTime);
            colapse = true;
            countdown = 2;
        }
    }

    public void DestroyPelor()
    {
        StopAllCoroutines();
        Destroy(pelor);
    }

    public void AddDamage(GameObject Target)
    {
        Target.GetComponent<EnemyControl>().health.AddDamage(itemList[0].damage);
    }
}