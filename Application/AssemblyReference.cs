using System.Reflection;

namespace Application;



/// <summary>
/// Establece un referencia al ensamblado de aplicación, necesario para registrar algunas dependencias, por ejemplo las relacionadas
/// con MediatR.
/// </summary>
public class ApplicationAssemblyReference
{
    public static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
}
