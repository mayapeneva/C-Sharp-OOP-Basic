using System;

public class Group
{
    private readonly string name;
    private int health;
    private int damage;

    private readonly string warEffect;
    private readonly string attack;

    private bool IsWarEffectTriggered;
    private bool isDead;
    private bool haveMoreToLoose;

    private readonly int initialHealth;
    private int initialDamageBeforeWarTrigger;

    public Group(string name, int health, int damage, string warEffect, string attack)
    {
        this.name = name;
        this.health = health;
        this.damage = damage;
        this.warEffect = warEffect;
        this.attack = attack;
        this.initialHealth = health;
    }

    public int Health
    {
        get { return this.health; }
        private set { this.health = value; }
    }

    public int Damage
    {
        get { return this.damage; }
    }

    public bool IsDead
    {
        get { return this.isDead; }
    }

    public bool HaveMoreToLoose
    {
        get { return this.haveMoreToLoose; }
    }

    public int GetAttackerDamage()
    {
        if (this.attack.Equals("Paris"))
        {
            return this.Damage;
        }
        else
        {
            this.Health = (int)Math.Ceiling(this.Health / 2.0);
            if (this.Health < 1)
            {
                this.Health = 1;
            }

            return 2 * this.Damage;
        }
    }

    public void ReceivesAttack(int damage)
    {
        this.health -= damage;
        if (this.IsWarEffectTriggered)
        {
            throw new Exception("An effect can only be triggered once.");
        }

        if (this.health <= this.initialHealth / 2 && !this.IsWarEffectTriggered)
        {
            this.IsWarEffectTriggered = true;
            if (this.attack.Equals("Jihad"))
            {
                this.initialDamageBeforeWarTrigger = this.damage;
                this.damage *= 2;
                this.haveMoreToLoose = true;
            }
        }

        if (this.health <= 0)
        {
            this.isDead = true;
        }
    }

    public void GetToLoose()
    {
        if (this.warEffect.Equals("Jihad"))
        {
            if (this.damage >= this.initialDamageBeforeWarTrigger)
            {
                this.damage -= 5;
            }
        }
        else
        {
            if (this.health > 0)
            {
                this.health -= 10;
            }
        }

        if (this.health <= 0)
        {
            this.isDead = true;
        }
    }

    public override string ToString()
    {
        if (isDead)
        {
            return $"Group {this.name} AMEN";
        }

        return $"Group {this.name}: {this.Health} HP, {this.Damage} Damage";
    }
}