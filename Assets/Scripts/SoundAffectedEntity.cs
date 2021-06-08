using UnityEngine;

public class SoundAffectedEntity : MonoBehaviour
{
    public virtual void Pull()
    {
        Debug.Log(gameObject.name + "Pulled");
    }

    public virtual void Push()
    {
        Debug.Log(gameObject.name + "Pushed");
    }
}