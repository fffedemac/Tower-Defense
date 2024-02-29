using UnityEngine;

[CreateAssetMenu(fileName = "New StatusEffectData", menuName = "Status Effect/New StatusEffectData")]
public sealed class StatusEffectData : ScriptableObject
{
    [SerializeField] private EffectMode _mode;
    [SerializeField] private EffectType _type;
    [SerializeField] private float _duration;
    [SerializeField] private float _tick;
    [SerializeField] private float _percentageValue;

    public EffectMode Mode { get => _mode; }
    public EffectType Type { get => _type; }
    public float Duration { get => _duration; }
    public float Tick { get => _tick; }
    public float PercentageValue { get => _percentageValue; }
}
