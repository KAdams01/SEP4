using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultToSniper : MonoBehaviour
{
    private GunModelManager gmm;
    // Start is called before the first frame update
    void Start()
    {
        gmm = GunModelManager.Instance;
        if (GunModelManager.currentWeapon != GunModelManager.currentlySelected.Sniper)
        {
            gmm.ShowSniperRifle();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
