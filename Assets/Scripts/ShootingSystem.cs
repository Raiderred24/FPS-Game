using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public float fireRate;
    public int damage;
    public float fieldOfView;
    public GameObject projectile;
    public List<GameObject> projectileSpawns;

    List<GameObject> m_lastProjectiles = new List<GameObject>();
    float m_fireTimer = 0.0f;
    public GameObject m_target;
    void Update()
    {
        if(!m_target)
        {
            return;
        }
        if (m_lastProjectiles.Count <= 0)
        {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(m_target.transform.position - transform.position));

            if (angle < fieldOfView)
            {
                SpawnProjectiles();
            }
        }
        else if (m_lastProjectiles.Count > 0)
        {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(m_target.transform.position - transform.position));

            if (angle > fieldOfView)
            {
                RemoveLastProjectiles();
            }
        }
        //else
        {
            m_fireTimer += Time.deltaTime;

            if(m_fireTimer >= fireRate)
            {
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(m_target.transform.position - transform.position));

                if(angle < fieldOfView)
                {
                    SpawnProjectiles();

                    m_fireTimer = 0.0f;
                }
            }
        }
    }
    void SpawnProjectiles()
    {
        if(!projectile)
        {
            return;
        }

        float targetDistance = Vector3.Distance(m_target.transform.position, this.transform.position);
        if (targetDistance > 50f)
        {
            return;
        }

        this.GetComponent<AudioSource>().Play();

        m_lastProjectiles.Clear();

        for (int i = 0; i < projectileSpawns.Count; i++)
        {
            if(projectileSpawns[i])
            {
                GameObject proj = Instantiate(projectile, projectileSpawns[i].transform.position, Quaternion.Euler(projectileSpawns[i].transform.forward)) as GameObject;
                proj.GetComponent<BaseProjectile>().FireProjectile(projectileSpawns[i], m_target, damage, fireRate);

                m_lastProjectiles.Add(proj);
            }
        }
    }
    public void SetTarget(GameObject target)
    {
        m_target = target;
    }
    void RemoveLastProjectiles()
    {
        while (m_lastProjectiles.Count > 0)
        {
            Destroy(m_lastProjectiles[0]);
            m_lastProjectiles.RemoveAt(0);
        }
    }
}
