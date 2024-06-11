namespace Domain.Countries;



/// <summary>
/// La clase country del dominio, encargada de realizar la lógica de negocio relacionadas con el país.
/// </summary>
public sealed class Country
{
    //Necesario para Entity Core.
    private Country() { }



    public Country(string paramName, int paramPopulation)
    {
        (bool areArgumentsValid, string? invalidReason) = ValidateParameters(paramName, paramPopulation);
        if(areArgumentsValid == false) throw new ArgumentException(invalidReason);


        Name = paramName;
        Population = paramPopulation;
    }



    public string Name {  get; private set; }
    public int Population { get; private set; }


    public void SetPopulation(int paramPopulation)
    {
        (bool isValid, string? invalidReason) = ValidatePopulation(paramPopulation);
        if(isValid == false) throw new ArgumentException(invalidReason);


        Population = paramPopulation;
    }





    #region Validation
    private (bool IsValid, string? InvalidReason) ValidateName(string? paramName)
    {
        bool isValid = !string.IsNullOrWhiteSpace(paramName);
        string? invalidReason = null;

        if(isValid == false)
        {
            invalidReason = "El nombre del país se tiene que indicar.";
        }


        return (isValid, invalidReason);
    }



    private (bool IsValid, string? InvalidReason) ValidatePopulation(int? paramPopulation)
    {
        bool isValid = (paramPopulation >= 0 == true);
        string? invalidReason = null;

        if (isValid == false)
        {
            invalidReason = "El número de habitantes tiene que ser mayor o igual que cero.";
        }


        return (isValid, invalidReason);
    }



    private (bool IsValid, string? InvalidReason) ValidateParameters(string? paramName, int? paramPopulation)
    {
        (bool isValid, string? invalidReason) = ValidateName(paramName);
        if (isValid == false) return (isValid, invalidReason);


        (isValid, invalidReason) = ValidateName(paramName);
        if (isValid == false) return (isValid, invalidReason);


        return (true, null);
    }
    #endregion Validation
}
