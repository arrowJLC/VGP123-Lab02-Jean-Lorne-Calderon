using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum PickupType
    {
        Life,
        JumpBoost,
        Shrink,
        Score
    }

    public AudioClip pickupSound;

    public PickupType type;
    SpriteRenderer sr;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        audioSource.outputAudioMixerGroup = GameManager.Instance.SFXGroup;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NewBehaviourScript pc = collision.gameObject.GetComponent<NewBehaviourScript>();

            switch (type)
            {
                case PickupType.Life:
                    GameManager.Instance.lives++;
                    break;
                case PickupType.JumpBoost:
                    pc.JumpPowerUp();
                    break;
                //case PickupType.Shrink: break;
                case PickupType.Score:
                    //pc.score++;
                    break;
            }
            sr.enabled = false;
            audioSource.PlayOneShot(pickupSound);

            Destroy(gameObject, pickupSound.length);
        }
    }
}
