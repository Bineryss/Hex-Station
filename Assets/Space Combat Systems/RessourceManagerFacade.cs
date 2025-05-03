using UnityEngine;

public class RessourceManagerFacade : MonoBehaviour
{
    public void IncreaseHex(int ammount = 0)
    {
        RessourcesManager.Instance.IncreaseHex(ammount);
    }
}
