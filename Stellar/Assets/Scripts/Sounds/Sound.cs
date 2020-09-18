using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public static AudioClip dropCardSound, drawCardSound, holdingCardSound, losingHealth, cardAttacking;
    static AudioSource audioSource;

    void Start(){
        dropCardSound = Resources.Load<AudioClip>("greeting_1");
        drawCardSound = Resources.Load<AudioClip>("draw_card");
        holdingCardSound = Resources.Load<AudioClip>("card_hover0");
        losingHealth = Resources.Load<AudioClip>("lose_health");
        cardAttacking = Resources.Load<AudioClip>("shouting6");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip){
        switch(clip){
            case "greeting_1":
                audioSource.PlayOneShot(dropCardSound);
                break;
            case "draw_card":
                audioSource.PlayOneShot(drawCardSound);
                break;
            case "card_hover0":
                audioSource.PlayOneShot(holdingCardSound);
                break;
            case "lose_health":
                audioSource.PlayOneShot(losingHealth);
                break;
            case "shouting6":
                audioSource.PlayOneShot(cardAttacking);
                break;
        }
    }
}
