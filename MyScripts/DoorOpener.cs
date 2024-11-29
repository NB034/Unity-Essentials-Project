using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    Animator doorAnimator;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (doorAnimator != null && other.CompareTag("Player"))
        {
            doorAnimator.SetTrigger("Door_Open");
            Destroy(this);
        }
    }
}
