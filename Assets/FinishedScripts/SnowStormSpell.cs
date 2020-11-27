using UnityEngine;

public class SnowStormSpell : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TookDamage(0, Time.deltaTime * 2);
            other.GetComponent<Enemy>().snowStormSpeedReduced = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Enemy>().snowStormSpeedReduced = false;
    }
}
