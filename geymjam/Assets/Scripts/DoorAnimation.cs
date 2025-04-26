using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public Animator doorAnimator;

    void Start()
    {
        // Kapı başlangıçta kapalı olsun
        if (doorAnimator != null)
        {
            doorAnimator.SetBool("isOpen", false);
            Debug.Log("Kapı başlangıçta kapalı.");
        }
        else
        {
            Debug.LogError("DoorAnimator atanmamış! Lütfen Animator'ü kontrol et.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger'a giren: " + other.gameObject.name);
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Oyuncu tespit edildi! (Layer: Player)");
            doorAnimator.SetBool("isOpen", true);
            Debug.Log("Animator isOpen durumu: " + doorAnimator.GetBool("isOpen"));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Oyuncu çıktı! (Layer: Player)");
            doorAnimator.SetBool("isOpen", false);
            Debug.Log("Animator isOpen durumu: " + doorAnimator.GetBool("isOpen"));
        }
    }
}