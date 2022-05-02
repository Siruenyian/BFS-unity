using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectNode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHP enemyHP))
        {
            Debug.Log(collision.gameObject.name);
            GameManager.Instance.DecreaseHP(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
