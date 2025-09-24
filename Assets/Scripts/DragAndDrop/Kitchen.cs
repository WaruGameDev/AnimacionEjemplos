using UnityEngine;


public class Kitchen : MonoBehaviour
{
    public GameObject chef;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rabbit"))
        {
            other.gameObject.SetActive(false);
            chef.SetActive(true);
            MoneyManager.instance.moneyDPS++;

        }

    }
}
