namespace Domain.Utility;

public static class Ensure
{
    /// <summary>
    /// Ensures that the specified <see cref="int" value is greater than zero/>
    /// </summary>
    /// <param name="value">the value to check</param>
    /// <param name="message">The message to show if the check fails.</param>
    /// <param name="argumentName">The name of the argument being checked.</param>
    /// <exception cref="ArgumentException"></exception>
    public static void GreaterThanZero(int value, string message, string argumentName)
    {
        if (value <= 0)
            throw new ArgumentException(message, argumentName);
    }

    /// <summary>
    /// Ensure that the specified <see cref="int"/> value is greater than or equal to zero
    /// </summary>
    /// <param name="value">The value to check</param>
    /// <param name="message">The message to show if the check fails.</param>
    /// <param name="argumentName">The name of the argument being checked.</param>
    /// <exception cref="ArgumentException">if the specified value is less than zero.</exception>
    public static void GreaterThanOrEqualToZero(int value, string message, string argumentName)
    {
        if (value < 0)
            throw new ArgumentException(message, argumentName);
    }

    /// <summary>
    /// Ensure that the specified <see cref="decimal"/> value is greater than or equal to zero
    /// </summary>
    /// <param name="value">The value to check</param>
    /// <param name="message">The message to show if the check fails.</param>
    /// <param name="argumentName">The name of the argument being checked.</param>
    /// <exception cref="ArgumentException">if the specified value is less than zero.</exception>
    public static void GreaterThanOrEqualToZero(decimal value, string message, string argumentName)
    {
        if (value < 0)
            throw new ArgumentException(message, argumentName);
    }

    /// <summary>
    /// Ensures that the specified <see cref="string"/> value is not empty
    /// </summary>
    /// <param name="value">The value to check</param>
    /// <param name="message"> The message to show if the check fails</param>
    /// <param name="argumentName">The name of the argement being checked.</param>
    /// <exception cref="ArgumentException">If the specified value is empty.</exception>
    public static void NotEmpty(string value,string message, string argumentName)
    {
        if (string.IsNullOrEmpty(value)) 
            throw new ArgumentException(message,argumentName);
    }

    /// <summary>
    /// Ensures that the specified <see cref="DateTime"/> value is not empty
    /// </summary>
    /// <param name="value">The value to check</param>
    /// <param name="message"> The message to show if the check fails</param>
    /// <param name="argumentName">The name of the argement being checked.</param>
    /// <exception cref="ArgumentException">If the specified value is empty.</exception>
    public static void NotEmpty(DateTime value,string message, string argumentName)
    {
        if (value==default)
            throw new ArgumentException(message, argumentName);
    }

    /// <summary>
    /// Ensures that the specified <see cref="object"/> value is not empty
    /// </summary>
    /// <param name="value">The value to check</param>
    /// <param name="message"> The message to show if the check fails</param>
    /// <param name="argumentName">The name of the argement being checked.</param>
    /// <exception cref="ArgumentException">If the specified value is empty.</exception>
    public static void NotNull(object value,string message, string argumentName)
    {
        if (value is null)
            throw new ArgumentException(message, argumentName);
    }


}
