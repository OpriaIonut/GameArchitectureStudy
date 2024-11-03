using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100.0f;

        private float health;

        private void Start()
        {
            health = maxHealth;
        }

        public void Heal(float ammount)
        {
            health = Mathf.Clamp(health + ammount, 0.0f, maxHealth);
        }

        public void TakeDamage(float ammount)
        {
            health = Mathf.Clamp(health - ammount, 0.0f, maxHealth);
        }
    }
}