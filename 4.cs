using System;
using System.Collections.Generic;

// Step 1: Define the IMealPlan Interface
interface IMealPlan
{
    string MealType { get; }
    void DisplayMeal();
}

// Step 2: Implement Meal Plan Types
class VegetarianMeal : IMealPlan
{
    public string MealType => "Vegetarian Meal";

    public void DisplayMeal()
    {
        Console.WriteLine("Vegetarian Meal: Grilled Vegetables, Quinoa Salad, and Tofu.");
    }
}

class VeganMeal : IMealPlan
{
    public string MealType => "Vegan Meal";

    public void DisplayMeal()
    {
        Console.WriteLine("Vegan Meal: Lentil Soup, Avocado Toast, and Almond Milk Smoothie.");
    }
}

class KetoMeal : IMealPlan
{
    public string MealType => "Keto Meal";

    public void DisplayMeal()
    {
        Console.WriteLine("Keto Meal: Grilled Chicken, Avocado, and Cheese Omelette.");
    }
}

class HighProteinMeal : IMealPlan
{
    public string MealType => "High-Protein Meal";

    public void DisplayMeal()
    {
        Console.WriteLine("High-Protein Meal: Steak, Boiled Eggs, and Protein Shake.");
    }
}

// Step 3: Create a Generic Meal Class
class Meal<T> where T : IMealPlan
{
    public T MealPlan { get; set; }

    public Meal(T mealPlan)
    {
        MealPlan = mealPlan;
    }

    public void DisplayMealPlan()
    {
        Console.WriteLine($"\nMeal Plan: {MealPlan.MealType}");
        MealPlan.DisplayMeal();
    }
}

// Step 4: Implement a Generic Method to Validate and Generate Meal Plans
static class MealPlanGenerator
{
    public static void GenerateMealPlan<T>(T mealPlan) where T : IMealPlan
    {
        Console.WriteLine("\nValidating meal plan...");
        if (mealPlan is VegetarianMeal || mealPlan is VeganMeal || mealPlan is KetoMeal || mealPlan is HighProteinMeal)
        {
            Console.WriteLine("Meal Plan is Valid!");
            mealPlan.DisplayMeal();
        }
        else
        {
            Console.WriteLine("Invalid Meal Plan!");
        }
    }
}

// Step 5: Test the Implementation
class Program
{
    static void Main()
    {
        // Creating meal plans
        VegetarianMeal vegMeal = new VegetarianMeal();
        VeganMeal veganMeal = new VeganMeal();
        KetoMeal ketoMeal = new KetoMeal();
        HighProteinMeal proteinMeal = new HighProteinMeal();

        // Using generic Meal class
        Meal<VegetarianMeal> vegetarianMealPlan = new Meal<VegetarianMeal>(vegMeal);
        Meal<VeganMeal> veganMealPlan = new Meal<VeganMeal>(veganMeal);

        // Display meal plans
        vegetarianMealPlan.DisplayMealPlan();
        veganMealPlan.DisplayMealPlan();

        // Generate meal plans dynamically
        MealPlanGenerator.GenerateMealPlan(ketoMeal);
        MealPlanGenerator.GenerateMealPlan(proteinMeal);
    }
}
