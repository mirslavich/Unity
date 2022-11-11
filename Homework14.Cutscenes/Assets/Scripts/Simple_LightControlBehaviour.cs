using UnityEngine;
using UnityEngine.Playables;

public class Simple_LightControlBehaviour : PlayableBehaviour
{
    public float intensity;
    public Light light;
    private Color color;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (light!=null)
        {
            light.color = color;
            light.intensity = intensity;
        }
    }
}
