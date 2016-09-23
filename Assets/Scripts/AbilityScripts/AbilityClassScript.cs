using UnityEngine;
using System.Collections;

public abstract class AbilityClassScript : MonoBehaviour {

    public enum AbilityFase { Ready, Acting, Cooldown };
    public AbilityFase abilityState = AbilityFase.Ready;
    public float actingTimer, cooldownTimer;
    public float currentTimer;

    public bool ActivateAbility = false;

    public void TryActivate()
    {
        if (currentTimer <= 0 & abilityState == AbilityFase.Ready)
            ActivateAbility = true;
    }

    public abstract void Ready();
    public abstract void Acting();
    public abstract void Cooldown();

}
