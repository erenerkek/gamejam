using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            Debug.Log("Player entered door trigger");
            animator.SetBool("isIn", true);
            isOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            Debug.Log("Player exited door trigger");
            animator.SetBool("isIn", false);
            isOpen = false;
        }
    }
}