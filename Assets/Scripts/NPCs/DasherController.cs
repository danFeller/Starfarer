using UnityEngine;

public class DasherController : EnemyController
{
    static int dasherCount;
    bool deathPlaneTriggerIsRunning = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathPlane" && deathPlaneTriggerIsRunning)
        {
            deathPlaneTriggerIsRunning = false;
            decrementCounter();
            Destroy(gameObject);
        }
    }

    public int getCount()
    {
        return dasherCount;
    }
    public void incrementCounter()
    {
        dasherCount++;
    }
    public void decrementCounter()
    {
        dasherCount--;
    }
    public void resetCount()
    {
        dasherCount = 0;
    }


    void DebugDrawNewBox(float x, float y)
    {
        Debug.DrawLine(new Vector3(-x, y, 0), new Vector3(x, y, 0));
        Debug.DrawLine(new Vector3(x, y, 0), new Vector3(x, -y, 0));
        Debug.DrawLine(new Vector3(x, -y, 0), new Vector3(-x, -y, 0));
        Debug.DrawLine(new Vector3(-x, -y, 0), new Vector3(-x, y, 0));
    }
}
