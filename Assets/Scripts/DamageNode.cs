using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNode : MonoBehaviour
{
    [SerializeField] private float damage = 25f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHP enemyHP))
        {
            Debug.Log(collision.gameObject.name);
            enemyHP.Decrease(damage);
        }
    }

}
