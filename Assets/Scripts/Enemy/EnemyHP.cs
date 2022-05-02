using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class EnemyHP : MonoBehaviour
{
   /* public Image healthBar;
    public TextMeshProUGUI healthText;*/
    public float maxhealth = 100f;
    public float health;
    float lerpSpeed;
    public static Action onhealthChanged;
    private Color initialCol;
    [SerializeField] private Color dmgCol;
    [SerializeField] private MeshRenderer dmgRenderer;
    bool isHitted=false;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        
        //StartCoroutine(SwitchColor());
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = "health: " + health + "%";
        if (health > maxhealth)
        {
            health = maxhealth;
        }
     

        lerpSpeed = 3f * Time.deltaTime;
  /*      HealthFiller();
        ColorChanger();*/
    }

    void HealthFiller()
    {

        //healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxhealth), lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxhealth));
        //healthBar.color = healthColor;
    }


    IEnumerator SwitchColor()
    {
        yield return new WaitForSeconds(3f);
        //dmgRenderer.material.color = initialCol;
        isHitted = false;
    }

    public void Die()
    {
        GameManager.Instance.enemycount++;
        Destroy(this.gameObject);
    }

    public void Decrease(float dcPoint)
    {
        if (health - dcPoint > 0)
        {
            Debug.Log("ouch " + dcPoint);

            health -= dcPoint;
            dmgRenderer.material.color = Color.Lerp(dmgRenderer.material.color, Color.red, 3f * Time.deltaTime);

            StartCoroutine(SwitchColor());
        }
        else
        {
            Debug.Log("ZERO ");

            health = 0;
            Die();
            //you gotta play
        }
    }

    public void Increase(float inPoint)
    {
        if (health < maxhealth)
        {
            health += inPoint;
        }
    }
}
