using System;


[Serializable]
public class BarcodeAPIResult
{
    // EAN-13 Number
    public string code;
    // Product of Barcode
    public Product product;
}

[Serializable]
public class Product
{
    // EN and DE product names
    public string product_name_en;
    public string product_name;

    // allergenes
    public string[] allergens_tags;

    // nutriscore grade
    public string nutriscore_grade;

    // ingredients and information about ingredients
    public Ingrediant[] ingredients;
    public string[] ingredients_analysis_tags;
}

[Serializable]
public class Ingrediant
{
    public string text;
    public string vegetarian;
    public string vegan;
    public float percent_estimate;
}
