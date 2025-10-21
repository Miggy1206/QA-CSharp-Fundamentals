using Conditionals;

namespace Conditionals
{
    public enum  Pole
    {
        North,
        South
    }

    public enum CapitalCities
    {
        London,
        Paris,
        Rome,
        Madrid
    }
}



class Program
{
    static void Main(string[] args)
    {
        Conditionals.Pole pole = Pole.South;
        string animal;
        if (pole == Pole.North)
        {
            animal = "Polar Bear";
        }
        else
        {
            animal = "Penguin";
        }

        Console.WriteLine($"The animal that lives in the {pole} Pole is the {animal}.");
    
    
        Console.WriteLine("Please enter a capital city (London, Paris, Rome, Madrid):");
        var city = CapitalCities.Madrid;
        string countryMessage = "";
        switch(city)
        {
            case CapitalCities.London:
                countryMessage = "London is the capital of the United Kingdom.";
                break;
            case CapitalCities.Paris:
                countryMessage = "Paris is the capital of France.";
                break;
            case CapitalCities.Rome:
                countryMessage = "Rome is the capital of Italy.";
                break;
            case CapitalCities.Madrid:
                countryMessage = "Madrid is the capital of Spain.";
                break;
            default:
                countryMessage = "Unknown city.";
                break;
        }

        Console.WriteLine(countryMessage);







    }
}