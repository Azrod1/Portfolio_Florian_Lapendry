using UnityEngine;

public class ActiveCondition : MonoBehaviour
{
    public GameObject objectAsActivate;

    private void OnTriggerEnter(Collider collision)
    {
        /*if (collision.CompareTag("Player"))
        {
            objectAsActivate.GetComponent<ConditionToInteract>().ActivateObject();
        }*/
    }
}
