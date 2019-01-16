using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : RespawnableObject
{
    [HideInInspector]
    public Rigidbody2D rb;

    [HideInInspector]
    public float damage;

    [HideInInspector]
    public float duration;

    public override void Initialise()
    {
        rb.velocity = Vector2.zero;
    }

    public void Initialise(float damage, float duration)
    {
        Initialise();
        this.damage = damage;
        this.duration = duration;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
        UpdateDuration();
    }

    private void UpdateRotation()
    {
        if (rb.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void UpdateDuration()
    {
        duration -= Time.deltaTime;
        if (duration <= 0.0f)
        {
            ObjectPool.instance.AddProjectileToQueue(this);
            gameObject.SetActive(false);
        }
    }
}