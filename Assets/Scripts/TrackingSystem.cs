using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 30f;
    public GameObject m_target = null;
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookingRotation;
    void Update()
    {
        if (m_target)
        {
            if (m_lastKnownPosition != m_target.transform.position)
            {
                m_lastKnownPosition = m_target.transform.position;
                m_lookingRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
            }
            if (transform.rotation != m_lookingRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookingRotation, speed * Time.deltaTime);
            }
        }
    }
    public void SetTarget(GameObject target)
    {
        m_target = target;
    }
}
