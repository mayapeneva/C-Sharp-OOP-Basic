using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HackersManager
{
    private readonly Dictionary<string, Group> groups;

    public HackersManager()
    {
        this.groups = new Dictionary<string, Group>();
    }

    public void CreateGroup(string name, List<string> arguments)
    {
        var health = int.Parse(arguments[0]);
        var damage = int.Parse(arguments[1]);
        var warEffect = arguments[2];
        var attack = arguments[3];
        this.groups.Add(name, new Group(name, health, damage, warEffect, attack));
    }

    public void Attack(string attackerName, string targetName)
    {
        var attacker = this.groups[attackerName];
        var target = this.groups[targetName];
        try
        {
            if (!attacker.IsDead && !target.IsDead)
            {
                int attackerDamage = attacker.GetAttackerDamage();
                target.ReceivesAttack(attackerDamage);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public string Status()
    {
        var result = new StringBuilder();
        foreach (var group in this.groups.Values.OrderByDescending(g => g.Health).ThenByDescending(g => g.Damage))
        {
            result.AppendLine(group.ToString());
        }

        return result.ToString().Trim();
    }

    public void CheckForDailyLosses()
    {
        foreach (var group in this.groups.Where(g => g.Value.HaveMoreToLoose))
        {
            group.Value.GetToLoose();
        }
    }
}