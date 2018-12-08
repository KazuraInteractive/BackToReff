using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class drop : Monster
{

    [SerializeField]
    private float speed = -2.0F;

    Vector3 originalPos;

    private Vector3 direction;

    protected override void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        direction = transform.up;
    }

    protected override void Update()
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.y - transform.position.y) < 0.3F) ReceiveDamage();
            else unit.ReceiveDamage();
        }
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.y * 0.5F, 0.1F);

        if (colliders.Length > 0 && colliders.All(y => !y.GetComponent<Character>())) { gameObject.transform.position = originalPos; }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}