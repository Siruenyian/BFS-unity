using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Sanity_Script : MonoBehaviour
{
    public Image sanityBar;
    public TextMeshProUGUI sanityText;
    public float maxSanity = 100f;
    public float sanity;
    float lerpSpeed;
    public static Action onSanityChanged;
    [SerializeField] private GameObject WorkOV;
    [SerializeField] private Button[] toDisable; 
    private bool isactive;
    // Start is called before the first frame update
    void Start()
    {
        //sanity = maxSanity;
    }

    // Update is called once per frame
    void Update()
    {
        sanityText.text = "Sanity: " + sanity + "%";
        if (sanity > maxSanity)
        {
            sanity = maxSanity;
        }

       /* if (sanity<0&&toDisable.Length>0)
        {

            for (int i = 0; i <toDisable.Length; i++)
            {
                

                toDisable[i].interactable = false;
            }
        }
        if (sanity < 0 && toDisable.Length > 0)
        {

        }*/

        lerpSpeed = 3f * Time.deltaTime;
        SanityFiller();
        ColorChanger();
    }

    void SanityFiller()
    {

        sanityBar.fillAmount = Mathf.Lerp(sanityBar.fillAmount, (sanity/maxSanity), lerpSpeed);
    }

    void ColorChanger()
    {
        Color staminaColor = Color.Lerp(Color.red, Color.green, (sanity/maxSanity));
        sanityBar.color = staminaColor;
    }

    public void Decrease(float dcPoint)
    {

        if (sanity-dcPoint > 0)
        {
            sanity -= dcPoint;
        }
        else
        {
            sanity = 0;
            for (int i = 0; i < toDisable.Length; i++)
            {
                WorkOV.SetActive(false);

                toDisable[i].interactable = false;
            }
            //you gotta play
        }
    }

    public void Increase(float inPoint)
    {
        if (sanity < maxSanity)
        {
            sanity += inPoint;
        }
    }

}
