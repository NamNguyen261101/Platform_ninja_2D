using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTech : MonoBehaviour
{
    [SerializeField] Text hpText;
    public void OnInit(float hp)
    {
        hpText.text = hp.ToString();
        Invoke(nameof(OnDespawn), 1);
    }

    public void OnDespawn()
    {
        Destroy(gameObject);
    }
}
