
using System.Reflection.PortableExecutable;
using Microsoft.VisualBasic.FileIO;



public abstract class CharacterBase
{
    public string? Name { get; set; }

    public int Health { get; set; } = 100;

    public abstract void Attack(CharacterBase target);
    public abstract void Defend();

    public void TakeDamage(int amount)
    {
        Health -= amount;
    }

    public bool isDead => Health > 0;



}


public interface ISpecialAbility
{
    void UseSpecial(CharacterBase target);

}



public class Knight : CharacterBase
{
    public Knight() { Name = "Knight"; }

    public override void Attack(CharacterBase target)
    {
        Console.WriteLine($"{Name} swings a sword at {target.Name}!");
        target.TakeDamage(15);
    }
    public override void Defend()
    {
        Console.WriteLine($"{Name} raises a shield!");
    }

}

public class Wizard : CharacterBase, ISpecialAbility
{
    public Wizard() { Name = "Wizard"; }

    public override void Attack(CharacterBase target)
    {
        Console.WriteLine($"{Name} swings a sword at {target.Name}!");
        target.TakeDamage(15);
    }

    public override void Defend()
    {
        Console.WriteLine($"{Name} raises a shield!");
    }

    public void UseSpecial(CharacterBase target)
    {
        Console.WriteLine($"{Name} used they're special move! Striking {target.Name}");
        target.TakeDamage(48);
    }

}

public class Mage : CharacterBase, ISpecialAbility
{
    public Mage() { Name = "Mage"; }

    public override void Attack(CharacterBase target)
    {
        Console.WriteLine($"{Name} swings a sword at {target.Name}!");
        target.TakeDamage(15);
    }

    public override void Defend()
    {
        Console.WriteLine($"{Name} raises a shield!");
    }

    public void UseSpecial(CharacterBase target)
    {
        Console.WriteLine($"{Name} used they're special move! Striking {target.Name}");
        target.TakeDamage(48);
    }

}








public class Game
{
    public static void Main()
    {
        Random random = new Random();
        int number_of_turn = 100;
        Knight knight = new Knight();
        Mage mage = new Mage();
        Wizard wizard = new Wizard();

        List<CharacterBase> characters = new List<CharacterBase>();
        characters.Add(knight);
        characters.Add(mage);
        characters.Add(wizard);

        
        Console.WriteLine("\n\nFirst to Die!");
        Console.WriteLine("Battle Between Wizard, Knight, and the Mage!\n");


        for (int i = 0; i < number_of_turn; i++)
        {

            Console.WriteLine("\n");
            Console.WriteLine($"Turn: {i + 1} \n");
            int rand_player1 = random.Next(0, 3);
            int rand_player2 = random.Next(0, 3);
            int special_rand = random.Next(0, 2); //yes or no for the special power

            int player1_a_or_d = random.Next(0, 2);  // 0 = attack and 1 = Defence
            int player2_a_or_d = random.Next(0, 2);


            while (rand_player1 == rand_player2)
            {
                rand_player2 = random.Next(0, 3);
            }
            CharacterBase player1 = characters[rand_player1];
            CharacterBase player2 = characters[rand_player2];

            if (player1_a_or_d == 1 && player2_a_or_d == 1)
            {
                player1.Defend();
                player2.Defend();
                Console.WriteLine($"{player1.Name} Went to Block! However so Did {player2.Name}\n ThereFore Sheilds Collided, No Damage Dealt Either Way!\n");

                Console.WriteLine($"{player1.Name}'s Health is : {player1.Health} and {player2.Name}'s Health is : {player2.Health}");
                continue;
            }



            if (player1_a_or_d == 0) // attack
            {
                if (player1 is ISpecialAbility special && special_rand == 1)
                {
                    if (player2_a_or_d == 1) // but player 2 blocks
                    {
                        player2.Defend();
                        Console.WriteLine($"{player1.Name} Used They're Special Ability! However {player2.Name} Used their Defence! No Damage was Taken!\n");
                    }
                    else
                    {
                        special.UseSpecial(player2);
                    }

                }
                else if (player2_a_or_d == 1) // but player 2 blocks
                {
                    player2.Defend();
                    Console.WriteLine($"{player1.Name} Used They're Melee! However {player2.Name} Used their Defence! No Damage was Taken!\n");
                }
                else
                {
                    player1.Attack(player2);
                }


            }

            if (player2_a_or_d == 0) // attack
            {
                if (player2 is ISpecialAbility special && special_rand == 1)
                {
                    if (player1_a_or_d == 1) // but player 2 blocks
                    {
                        player1.Defend();
                        Console.WriteLine($"{player2.Name} Used They're Special Ability! However {player1.Name} Used their Defence! No Damage was Taken!\n");
                    }
                    else
                    {
                        special.UseSpecial(player1);
                    }

                }

                else if (player1_a_or_d == 1) // but player 2 blocks
                {
                    player1.Defend();
                    Console.WriteLine($"{player2.Name} Used They're Melee! However {player1.Name} Used their Defence! No Damage was Taken!\n");
                }
                else
                {
                    player2.Attack(player1);
                }

            }

            if (!player1.isDead)
            {
                Console.WriteLine($"{player1.Name} Has Fallen {player2.Name} Is Victorious!");
                break;
            }
            if (!player2.isDead)
            {
                Console.WriteLine($"{player2.Name} Has Fallen {player1.Name} Is Victorious!");
                break;
            }
        




            Console.WriteLine($"{player1.Name}'s Health is : {player1.Health} and {player2.Name}'s Health is : {player2.Health}");







        }








    }









}





