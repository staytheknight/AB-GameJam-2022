using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool hasEtherealPower = false;
    public bool hasInvertKillPower = false;
    public bool hasWraparoundPower = false;
    public bool hasGravityPower = false;

    [SerializeField] GameObject wrapAroundIconOn;
    [SerializeField] GameObject wrapAroundIconOff;


    private void Update()
    {
        if (hasWraparoundPower)
        {
            if(Input.GetButton("Wraparound"))
            {
                wrapAroundIconOn.SetActive(true);
                wrapAroundIconOff.SetActive(false);

            } else if (!Input.GetButton("Wraparound")) {

                wrapAroundIconOn.SetActive(false);
                wrapAroundIconOff.SetActive(true);

            } else {

                wrapAroundIconOn.SetActive(false);
                wrapAroundIconOff.SetActive(false);
            }
        }

    }

}
