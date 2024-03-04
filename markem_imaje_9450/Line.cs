using System.Text;

namespace Markem_Imaje_9450;
public static class Line
{
    #region Variables

    /// <summary>
    /// Indication of a new line
    /// </summary>
    private static readonly byte StartLine = 0x0A;

    /// <summary>
    /// New block parameter
    /// </summary>
    private static readonly byte ParameterType = 0x10;

    /// <summary>
    /// Constant length value
    /// </summary>
    public static readonly byte[] Length = [0x00, 0x12];

    /// <summary>
    /// Selected algorithm in the machine ([0x00, 0x00] is the default)
    /// </summary>
    private static readonly byte[] AlgorithmNumber = [0x00, 0x00];

    /// <summary>
    /// Empty reserved place
    /// </summary>
    public static readonly byte Reserved = 0x00;

    private static readonly byte Expansion = 0x01;

    #endregion Variables

    /// <summary>
    /// Set a new line from a string
    /// </summary>
    /// <param name="lineLabel">Text of the line label</param>
    /// <param name="font">Font type</param>
    /// <param name="margin">Line margin</param>
    /// <returns>Formated line</returns>
    public static byte[] SetLine(this string lineLabel, Font font, byte height, int lineIndex)
    {
        byte[] textArray = Encoding.ASCII.GetBytes(lineLabel);
        byte[] yReference = [0x00, (byte)(lineIndex * (font.Height + height))];
        byte[] lineDefenition = [
            ParameterType,
            ..Length,
            .. font.Dimensions,
            .. AlgorithmNumber,
            .. yReference,
            Reserved,
            Expansion,
            Reserved,
            Reserved,
            Reserved,
            Reserved,
            ..Length,
            ParameterType];
        byte[] line = [StartLine, .. lineDefenition, .. textArray, .. lineDefenition];
        return line;
    }
}