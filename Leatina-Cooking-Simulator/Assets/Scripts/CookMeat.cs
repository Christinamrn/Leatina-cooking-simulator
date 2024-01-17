using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMeat : MonoBehaviour
{
    public AudioClip cookSound;

    private SteakBehaviour steakScript;

    private void Start()
    {
        steakScript = GetComponent<SteakBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meat") && GlobalVariables.hotPan)
        {
            if (steakScript != null && !steakScript.EstCuit())
            {
                //StartCoroutine(CookAndDarkenMeat(other.gameObject));
                steakScript.CuireSteak();
            }

        }
    }

    public IEnumerator CookAndDarkenMeat(GameObject meatObject)
    {
        GameObject audioSourceObject = new GameObject("CookSound");
        AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
        audioSource.clip = cookSound;
        audioSource.Play();

        yield return new WaitForSeconds(5f);

        audioSource.Stop();
        Destroy(audioSourceObject);

        Renderer rend = meatObject.GetComponent<Renderer>();

        if (rend != null)
        {
            Color currentColor = rend.material.color;

            float darkenFactor = 1.2f;
            Color darkenedColor = new Color(currentColor.r * darkenFactor, currentColor.g * darkenFactor, currentColor.b * darkenFactor, currentColor.a);

            rend.material.color = darkenedColor;

            /*Debug.Log("la viande a chang� de couleur");

            if (steakScript != null)
            {
                steakScript.CuireSteak();
            }*/
        }
    }
}