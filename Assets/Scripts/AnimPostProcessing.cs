using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class AnimPostProcessing : MonoBehaviour
{

    public PostProcessLayer v2_PostProcess;
    public PostProcessVolume postProcessVolume;

    private DepthOfField dph_1;

    // Start is called before the first frame update
    void Start()
    {
        List<PostProcessVolume> volList = new List<PostProcessVolume>();
        PostProcessManager.instance.GetActiveVolumes(v2_PostProcess, volList, true, true);
        //
        foreach (PostProcessVolume vol in volList)
        {
            PostProcessProfile ppp = vol.profile;
            if (ppp)
            {
                DepthOfField dph;
                if (ppp.TryGetSettings<DepthOfField>(out dph))
                {
                    //dph.focusDistance.value = 120;
                    dph_1 = dph;
                }
            }
        }

        //StartCoroutine(FadeIn(dph_1, 3));
    }

    public void FadeIn()
    {
        StartCoroutine(FadeIn(dph_1, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOut(dph_1, 1));
    }
    public IEnumerator FadeIn(DepthOfField depth, float FadeTime)
    {
        float startVolume = 3.99f;

        while (depth.focusDistance.value < 6)
        {
            depth.focusDistance.value += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        depth.focusDistance.value = 6;

    }

    public IEnumerator FadeOut(DepthOfField depth, float FadeTime)
    {
        float startVolume = depth.focusDistance.value;

        while (depth.focusDistance.value > 3.99 )
        {
            depth.focusDistance.value -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        //depth.focusDistance.value = startVolume;

    }
}
