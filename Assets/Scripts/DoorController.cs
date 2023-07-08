using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;
    public float doorCloseDelay = 5f;

    private bool isDoorOpen = false;
    private float doorOpenTime;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player is entering the trigger area
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (!isDoorOpen)
        {
            doorAnimator.SetTrigger("Open");
            isDoorOpen = true;
            doorOpenTime = Time.time;
        }
    }

    private void Update()
    {
        // Close the door if it's open and the delay time has passed
        if (isDoorOpen && Time.time >= doorOpenTime + doorCloseDelay)
        {
            CloseDoor();
        }
    }

    private void CloseDoor()
    {
        if (isDoorOpen)
        {
            doorAnimator.SetTrigger("Close");
            isDoorOpen = false;
        }
    }
}
