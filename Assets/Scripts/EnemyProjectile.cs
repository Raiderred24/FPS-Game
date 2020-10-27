using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : BaseProjectile{

    Vector3 m_direction;
    bool m_fired;
    GameObject m_launcher;
    GameObject m_target;
    int m_damage;

    void Update()
    {
        if(m_fired)
        {
            transform.position += m_direction * (speed * Time.deltaTime);
        }
    }

    public override void FireProjectile(GameObject launcher, GameObject target, int damage, float attackspeed)
    {
        // Auto-Generated on Tab --> throw new System.NotImplementedException();
        if(launcher && target)
        {
            m_direction = (target.transform.position - launcher.transform.position).normalized;
            m_fired = true;
            m_launcher = launcher;
            m_target = target;
            m_damage = damage;

            Destroy(gameObject, 10f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_target)
        {
            other.gameObject.GetComponent<PlayerMovement>().healthBar(m_damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
