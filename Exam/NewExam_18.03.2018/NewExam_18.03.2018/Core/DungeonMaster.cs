using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DungeonMaster
{
    private Dictionary<string, Character> party;
    private Stack<Item> pool;
    private int lastSurvivorRounds;

    private CharacterFactory characterFactory;
    private ItemFactory itemFactory;

    public DungeonMaster(CharacterFactory characterFactory, ItemFactory itemFactory)
    {
        this.party = new Dictionary<string, Character>();
        this.pool = new Stack<Item>();
        this.characterFactory = characterFactory;
        this.itemFactory = itemFactory;
    }

    public string JoinParty(string[] args)
    {
        var characterType = args[1];
        var name = args[2];
        this.party.Add(name, this.characterFactory.CreateCharacter(characterType, name, args[0]));

        return $"{name} joined the party!";
    }

    public string AddItemToPool(string[] args)
    {
        var itemName = args[0];
        this.pool.Push(this.itemFactory.CreateItem(itemName));

        return $"{itemName} added to pool.";
    }

    public string PickUpItem(string[] args)
    {
        var characterName = args[0];
        if (!this.party.ContainsKey(characterName))
        {
            throw new ArgumentException($"Character {characterName} not found!");
        }

        if (this.pool.Count == 0)
        {
            throw new InvalidOperationException("No items left in pool!");
        }

        var item = this.pool.Pop();
        var character = this.party[characterName];
        character.ReceiveItem(item);

        return $"{characterName} picked up {item.Name}!";
    }

    public string UseItem(string[] args)
    {
        var characterName = args[0];
        var itemName = args[1];
        if (!this.party.ContainsKey(characterName))
        {
            throw new ArgumentException($"Character {characterName} not found!");
        }

        this.party[characterName].UseItem(this.party[characterName].Bag.GetItem(itemName));

        return $"{characterName} used {itemName}.";
    }

    public string UseItemOn(string[] args)
    {
        var giverName = args[0];
        var receiverName = args[1];
        var itemName = args[2];
        if (!this.party.ContainsKey(giverName))
        {
            throw new ArgumentException($"Character {giverName} not found!");
        }

        if (!this.party.ContainsKey(receiverName))
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }

        var item = this.party[giverName].Bag.GetItem(itemName);
        this.party[giverName].UseItemOn(item, this.party[receiverName]);

        return $"{giverName} used {itemName} on {receiverName}.";
    }

    public string GiveCharacterItem(string[] args)
    {
        var giverName = args[0];
        var receiverName = args[1];
        var itemName = args[2];
        if (!this.party.ContainsKey(giverName))
        {
            throw new ArgumentException($"Character {giverName} not found!");
        }

        if (!this.party.ContainsKey(receiverName))
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }

        var item = this.party[giverName].Bag.GetItem(itemName);
        this.party[giverName].GiveCharacterItem(item, this.party[receiverName]);

        return $"{giverName} gave {receiverName} {itemName}.";
    }

    public string GetStats()
    {
        var result = new StringBuilder();
        foreach (var kvp in this.party.OrderByDescending(c => c.Value.IsAlive).ThenByDescending(c => c.Value.Health))
        {
            result.AppendLine(kvp.Value.ToString());
        }

        return result.ToString().Trim();
    }

    public string Attack(string[] args)
    {
        var attackerName = args[0];
        var receiverName = args[1];
        if (!this.party.ContainsKey(attackerName))
        {
            throw new ArgumentException($"Character {attackerName} not found!");
        }

        if (!this.party.ContainsKey(receiverName))
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }

        if (this.party[attackerName] is Cleric)
        {
            throw new ArgumentException($"{attackerName} cannot attack!");
        }

        var attacker = (Warrior)this.party[attackerName];
        var receiver = this.party[receiverName];
        attacker.Attack(receiver);

        var result = new StringBuilder();
        result.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! " +
                          $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
        if (!receiver.IsAlive)
        {
            result.AppendLine($"{receiver.Name} is dead!");
        }

        return result.ToString().Trim();
    }

    public string Heal(string[] args)
    {
        var healerName = args[0];
        var healingReceiverName = args[1];
        if (!this.party.ContainsKey(healerName))
        {
            throw new ArgumentException($"Character {healerName} not found!");
        }

        if (!this.party.ContainsKey(healingReceiverName))
        {
            throw new ArgumentException($"Character {healingReceiverName} not found!");
        }

        if (this.party[healerName] is Warrior)
        {
            throw new ArgumentException($"{healerName} cannot heal!");
        }

        var healer = (Cleric)this.party[healerName];
        var healingReceiver = this.party[healingReceiverName];
        healer.Heal(healingReceiver);

        return
            $"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! {healingReceiver.Name} has {healingReceiver.Health} health now!";
    }

    public string EndTurn(string[] args)
    {
        var result = new StringBuilder();
        foreach (var kvp in this.party.Where(c => c.Value.IsAlive))
        {
            var healthBeforeRest = kvp.Value.Health;
            kvp.Value.Rest();
            result.AppendLine($"{kvp.Value.Name} rests ({healthBeforeRest} => {kvp.Value.Health})");
        }

        if (this.party.Count(c => c.Value.IsAlive) <= 1)
        {
            this.lastSurvivorRounds++;
        }

        return result.ToString().Trim();
    }

    public bool IsGameOver()
    {
        return this.party.Count(c => c.Value.IsAlive) <= 1 && this.lastSurvivorRounds > 1;
    }
}