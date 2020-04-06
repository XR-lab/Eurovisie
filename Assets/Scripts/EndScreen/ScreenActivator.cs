using UnityEngine;

public class ScreenActivator : MonoBehaviour
{
    public void screenActivation(GameObject target)
    {
        target.SetActive(true);
    }

    public void screenInactive(GameObject target)
    {
        target.SetActive(false);
    }
}
