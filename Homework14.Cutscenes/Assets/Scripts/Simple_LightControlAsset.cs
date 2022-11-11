using UnityEngine;
using UnityEngine.Playables;

public class Simple_LightControlAsset : PlayableAsset
{
    public ExposedReference<Light> light;
    public Color color=Color.white;
    public float intensity = 1f;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<Simple_LightControlBehaviour>.Create(graph);
        var behaviour = playable.GetBehaviour();
        behaviour.light = light.Resolve(graph.GetResolver());
        behaviour.intensity = intensity;
        return playable;
    }
}
