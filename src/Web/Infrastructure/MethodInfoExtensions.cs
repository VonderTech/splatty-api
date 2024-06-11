using System.Reflection;

namespace Web.Infrastructure;

/// <summary>
///     Provides extension methods for the MethodInfo class.
/// </summary>
public static class MethodInfoExtensions
{
    /// <summary>
    ///     Determines whether the specified method is an anonymous method.
    /// </summary>
    /// <param name="method">The method to check.</param>
    /// <returns>true if the method is an anonymous method; otherwise, false.</returns>
    public static bool IsAnonymous(this MethodInfo method)
    {
        var invalidChars = new[] { '<', '>' };
        return method.Name.Any(invalidChars.Contains);
    }

    /// <summary>
    ///     Throws an ArgumentException if the specified delegate is an anonymous method.
    /// </summary>
    /// <param name="guardClause">The IGuardClause instance on which the extension method is invoked.</param>
    /// <param name="input">The delegate to check.</param>
    public static void AnonymousMethod(this IGuardClause guardClause, Delegate input)
    {
        if (input.Method.IsAnonymous())
            throw new ArgumentException(
                "The endpoint name must be specified when using anonymous handlers."
            );
    }
}
