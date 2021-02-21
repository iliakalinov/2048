using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WInGame : MonoBehaviour
{
    public Effects effects;
    public Transform[] transforms;

    private int idEffect=0;
    private int lengthEffects = 0;
    GameObject EffectHit;

    private void Start()
    {
        Invoke(nameof(GenerateNext), 1f);
        lengthEffects = transforms.Length;
        EffectHit = effects.effectsHit;
    }

    private void GenerateNext()
    {
        Instantiate(EffectHit, transforms[idEffect].position, Quaternion.identity);
        idEffect++;

        if (idEffect == lengthEffects)
        {
            idEffect = 0;
        }
        Invoke(nameof(GenerateNext), 1f);

    }



}
