using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve bouncyCurve;

    private static AnimationManager _instance;
    public static AnimationManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }


    public IEnumerator BounceGOUnscaled(GameObject objectToScale, float bounceTime = 0.275f)
    {
        AnimationCurve curve = bouncyCurve;
        if (curve == null)
            yield return null;

        float timer = 0;
        if (bounceTime < 0)
        {
            bounceTime = 0.275f;
        }

        while (timer <= bounceTime)
        {
            objectToScale.transform.localScale = new Vector3(curve.Evaluate(timer / bounceTime), curve.Evaluate(timer / bounceTime), 0);
            timer += Time.unscaledDeltaTime;
            yield return null;
        } 

        yield break;
    }
}
