using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAScript : MonoBehaviour {
    // Defined by prefabs
    public float moveSpeed;
    public float attackRange;
    public int attackPoints;
    public float killThreshold;

    private GameObject castle;
    private Vector3 castlePos;

    public float rotateSpeed = 2f;
    private float sqrAttackRange;

    private float attackCooldown = 1f;

    private Animator animator;

    private Vector3 destination;
    private Vector3 rotateDir;

    public float jumpPowerGround = 60f;
    public float jumpPowerOtherIA = 100;

    [SerializeField]
    GameObject deadParticleEffect;

    // Use this for initialization
    void Start()
    {
        castle = GameObject.FindWithTag("Castle");
        castlePos = castle.transform.position;
        sqrAttackRange = attackRange + (castle.transform.localScale.x * castle.transform.localScale.x);//(castle.transform.localScale.x+transform.localScale.x)* (castle.transform.localScale.x+ transform.localScale.x);

        // StartCoroutine("Attack");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        RotateAndMove();
    }

    public void RotateAndMove()
    {
        rotateDir = Vector3.RotateTowards(transform.forward,
                castlePos - transform.position,
                Time.deltaTime * rotateSpeed,
                1.0F);

        transform.rotation = Quaternion.LookRotation(rotateDir);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

        if (!IsInAttackRange())
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, castlePos, step);

        }
        else
        {
            Attack();
            GameObject.Instantiate(deadParticleEffect, transform.position, deadParticleEffect.transform.rotation);
            Destroy(gameObject);
        }
    }

    /*public IEnumerator Attack()
    {
        while (true)
        {
            if ((transform.position - castlePos).sqrMagnitude < sqrAttackRange)
            {

            }
            else
            {

            }
            yield return new WaitForSeconds(attackCooldown);
        }
    }*/

    public void Attack()
    {
        Manager.pv--;
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Debug.lo
        if(collision.gameObject.tag == "IA")
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpPowerOtherIA, 0));
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpPowerGround, 0));
        }
    }

    private bool IsInAttackRange()
    {
        return ((transform.position - castlePos).sqrMagnitude < sqrAttackRange);
    }
}
