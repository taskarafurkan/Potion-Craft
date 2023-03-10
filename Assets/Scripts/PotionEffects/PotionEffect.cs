namespace PotionCraft.PotionScripts
{
    public abstract class PotionEffect
    {
        #region Fields
        private float _effectTime;
        #endregion

        #region Properties
        /// <summary>
        /// Potion exposure time
        /// </summary>
        public float EffectTime { get => _effectTime; set => _effectTime = value; }
        #endregion

        #region Methods
        public abstract void ApplyEffect();
        #endregion
    }
}