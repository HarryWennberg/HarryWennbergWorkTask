using UnityEngine;

namespace Unity.FPS.Game
{
    public class Damageable : MonoBehaviour
    {
        [Tooltip("Multiplier to apply to the received damage")]
        public float DamageMultiplier = 1f;

        [Range(0, 1)] [Tooltip("Multiplier to apply to self damage")]
        public float SensibilityToSelfdamage = 0.5f;

        public Health Health { get; private set; }

        DamageText damageText;

        void Awake()
        {
            // find the health component either at the same level, or higher in the hierarchy
            Health = GetComponent<Health>();
            if (!Health)
            {
                Health = GetComponentInParent<Health>();
            }
        }

        public void InflictDamage(float damage, bool isExplosionDamage, GameObject damageSource)
        {
            if (Health)
            {
                var totalDamage = damage;

                // skip the crit multiplier if it's from an explosion
                if (!isExplosionDamage)
                {
                    totalDamage *= DamageMultiplier;
                }

                // potentially reduce damages if inflicted by self
                if (Health.gameObject == damageSource)
                {
                    totalDamage *= SensibilityToSelfdamage;

                }

                if (damageSource.CompareTag("Player") && Health.gameObject.CompareTag("Player"))
                {

                    totalDamage /= 2;

                }

                // apply the damages
                Health.TakeDamage(totalDamage, damageSource);

                //if (Health.gameObject.tag == "enemy")
                //{
                //    //skicak Health.Gameobject ttransform
                //    //damageText.DamageTextCreation(Health.gameObject, totalDamage);
                    
                //    //damageText.DamageTextCreation(Health.gameObject,0);
                    
                //}
            }
        }
    }
}