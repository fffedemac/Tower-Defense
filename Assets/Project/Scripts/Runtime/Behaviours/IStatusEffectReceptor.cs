namespace StatusEffects
{
    public interface IStatusEffectReceptor : IDamageable
    {
        public void UpdateSpeed(float speed);
        public float GetMaxSpeed();
    }
}
