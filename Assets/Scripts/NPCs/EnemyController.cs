using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // THESE ARE USED FOR DEBUGGING
    protected void Identify()
    {
        Debug.Log("I'm a child called " + gameObject);
    }

    protected void Flee()
    {
        transform.Translate(0f, 0.2f, 0);
    }
}
