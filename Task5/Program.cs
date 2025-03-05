interface ICharacterBuilder
{
    ICharacterBuilder SetHeight(int height);
    ICharacterBuilder SetBodyType(string bodyType);
    ICharacterBuilder SetHairColor(string hairColor);
    ICharacterBuilder SetEyeColor(string eyeColor);
    ICharacterBuilder SetClothing(string clothing);
    ICharacterBuilder AddToInventory(string item);
    ICharacterBuilder AddSkill(string skill);
    ICharacterBuilder AddGoodDeed(string deed); 
    ICharacterBuilder AddEvilDeed(string deed); 
    Character Build();
}


class Character
{
    public string Name { get; set; }
    public int Height { get; set; }
    public string BodyType { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public string Clothing { get; set; }
    public List<string> Inventory { get; set; } = new List<string>();
    public List<string> Skills { get; set; } = new List<string>();
    public List<string> Deeds { get; set; } = new List<string>();

    public void ShowInfo()
    {
        Console.WriteLine($"\n{Name} ({GetType().Name}):");
        Console.WriteLine($"- Height: {Height} cm");
        Console.WriteLine($"- Body Type: {BodyType}");
        Console.WriteLine($"- Hair Color: {HairColor}");
        Console.WriteLine($"- Eye Color: {EyeColor}");
        Console.WriteLine($"- Clothing: {Clothing}");
        Console.WriteLine($"- Inventory: {string.Join(", ", Inventory)}");
        Console.WriteLine($"- Skills: {string.Join(", ", Skills)}");
        Console.WriteLine($"- Deeds: {string.Join(", ", Deeds)}");
    }
}


class HeroBuilder : ICharacterBuilder
{
    private Character _character = new Character();

    public HeroBuilder(string name)
    {
        _character.Name = name;
    }

    public ICharacterBuilder SetHeight(int height)
    {
        _character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBodyType(string bodyType)
    {
        _character.BodyType = bodyType;
        return this;
    }

    public ICharacterBuilder SetHairColor(string hairColor)
    {
        _character.HairColor = hairColor;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string eyeColor)
    {
        _character.EyeColor = eyeColor;
        return this;
    }

    public ICharacterBuilder SetClothing(string clothing)
    {
        _character.Clothing = clothing;
        return this;
    }

    public ICharacterBuilder AddToInventory(string item)
    {
        _character.Inventory.Add(item);
        return this;
    }

    public ICharacterBuilder AddSkill(string skill)
    {
        _character.Skills.Add(skill);
        return this;
    }

    public ICharacterBuilder AddGoodDeed(string deed)
    {
        _character.Deeds.Add($"🟢 Good: {deed}");
        return this;
    }

    public ICharacterBuilder AddEvilDeed(string deed) 
    {
        return this;
    }

    public Character Build()
    {
        return _character;
    }
}


class EnemyBuilder : ICharacterBuilder
{
    private Character _character = new Character();

    public EnemyBuilder(string name)
    {
        _character.Name = name;
    }

    public ICharacterBuilder SetHeight(int height)
    {
        _character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBodyType(string bodyType)
    {
        _character.BodyType = bodyType;
        return this;
    }

    public ICharacterBuilder SetHairColor(string hairColor)
    {
        _character.HairColor = hairColor;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string eyeColor)
    {
        _character.EyeColor = eyeColor;
        return this;
    }

    public ICharacterBuilder SetClothing(string clothing)
    {
        _character.Clothing = clothing;
        return this;
    }

    public ICharacterBuilder AddToInventory(string item)
    {
        _character.Inventory.Add(item);
        return this;
    }

    public ICharacterBuilder AddSkill(string skill)
    {
        _character.Skills.Add(skill);
        return this;
    }

    public ICharacterBuilder AddGoodDeed(string deed) 
    {
        return this;
    }

    public ICharacterBuilder AddEvilDeed(string deed)
    {
        _character.Deeds.Add($"🔴 Evil: {deed}");
        return this;
    }

    public Character Build()
    {
        return _character;
    }
}


class CharacterDirector
{
    public Character CreateHero(ICharacterBuilder builder)
    {
        return builder
            .SetHeight(185)
            .SetBodyType("Athletic")
            .SetHairColor("Blonde")
            .SetEyeColor("Blue")
            .SetClothing("Shining Armor")
            .AddToInventory("Excalibur Sword")
            .AddSkill("Sword Wielding")
            .AddSkill("Magic Wielding")
            .AddGoodDeed("Saved the world")
            .Build();
    }

    public Character CreateEnemy(ICharacterBuilder builder)
    {
        return builder
            .SetHeight(200)
            .SetBodyType("Evil")
            .SetHairColor("Black")
            .SetEyeColor("Red")
            .SetClothing("Dark Robe")
            .AddToInventory("Cursed Staff")
            .AddSkill("Dark Magic")
            .AddSkill("Mind Control")
            .AddEvilDeed("Destroyed a kingdom")
            .Build();
    }
}


class Program
{
    static void Main()
    {
        CharacterDirector director = new CharacterDirector();

       
        Character hero = director.CreateHero(new HeroBuilder("Bob"));

     
        Character enemy = director.CreateEnemy(new EnemyBuilder("Kevin"));

       
        hero.ShowInfo();
        enemy.ShowInfo();
    }
}
