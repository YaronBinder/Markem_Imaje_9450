using System;
using System.Net.Sockets;

namespace Markem_Imaje_9450;

public static class Markem_Imaje_9450
{
    #region Private const variables

    /// <summary>
    /// Enquiry for the printer
    /// </summary>
    private const byte ENQ = 0x05;

    /// <summary>
    /// Acknowledge from the printer
    /// </summary>
    private const byte ACK = 0x06;

    /// <summary>
    /// negative acknowledgment
    /// </summary>
    private const byte NACK = 0x15;

    /// <summary>
    /// Job identifier
    /// </summary>
    private const byte identifier = 0xEF;

    /// <summary>
    /// Delimiter representing the end of the data transmission.
    /// </summary>
    private const byte END_OF_JOB = 0x0D;

    private const byte PARAMETER_TYPE = 0x09;

    private const byte NUMBER_OF_LINES = 0x03;

    private const byte TACHO_DIVISION = 0x05;

    private const byte DESCRIPTION_OF_GLOBAL_PARAMETERS = 0x10;

    private const byte NUMBER_OF_REPETITIONS = 0x00;

    private const byte DTOP = 0x02;

    private const byte FILLING_DATA = 0x00;

    private const byte TYPE_OF_ENTRY = 0x00;

    private const byte CRC = 0x00;

    #endregion

    #region Private static variables

    /// <summary>
    /// Keep a place for 2 byte size in the final print array
    /// </summary>
    private static readonly byte[] LengthPlaceHolder = new byte[2];

    private static readonly byte[] Margin = [0x00, 0x03, 0x00, 0x03];

    private static readonly byte[] PrintingDelay = [0x00, 0x03];

    private static readonly byte[] NumberOfParameter = [0x00, 0x02];

    private static readonly byte[] IntervalForRepeatingMode = [0x00, 0x02];

    private static readonly byte[] JobParameter = [0x01, 0x00];

    private static readonly byte[] ParameterLength = [0x00, 0x04];

    #endregion Private static variables

    /// <summary>
    /// Build and send the printing job to the printer
    /// </summary>
    /// <param name="address">Printer IP address</param>
    /// <param name="port">Printer port number</param>
    /// <param name="font">Font dimensions</param>
    /// <param name="margin">Line margin</param>
    /// <param name="lines">Line text</param>
    public static JobResult SendPrintingJob(string address, int port, Font font, byte margin, params string[] lines)
    {
        using TcpClient client = new(address, port);
        using NetworkStream stream = client.GetStream();

        try
        {
            stream.WriteByte(ENQ);
            if (stream.ReadByte() != ACK)
            {
                return JobResult.AckFail;
            }

            byte[] formatLines = [];
            int linesCount = lines.Length - 1;

            for (int i = 0; i < lines.Length; i++, linesCount--)
            {
                formatLines = [.. formatLines, .. lines[i].SetLine(font, margin, linesCount)];
            }

            byte[] printData = [
                identifier,
                .. LengthPlaceHolder,
                .. NumberOfParameter,
                .. JobParameter,
                ..Line.Length,
                DESCRIPTION_OF_GLOBAL_PARAMETERS,
                NUMBER_OF_REPETITIONS,
                DTOP,
                TACHO_DIVISION,
                .. Margin,
                .. IntervalForRepeatingMode,
                .. PrintingDelay,
                Line.Reserved,
                Line.Reserved,
                PARAMETER_TYPE,
                NUMBER_OF_LINES,
                .. ParameterLength,
                .. formatLines,
                END_OF_JOB,
                FILLING_DATA,
                TYPE_OF_ENTRY,
                CRC];

            printData[2] = Convert.ToByte(printData.Length - 4);
            printData[printData.Length - 1] = printData.CalcCrc();

            stream.Write(printData, 0, printData.Length);
            if (stream.ReadByte() == NACK)
            {
                Console.WriteLine(">> Data transmission failed");
                return JobResult.SendJobFail;
            }

            return JobResult.Success;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    /// <summary>
    /// Calculating the CRC value of the byte array
    /// </summary>
    /// <param name="array">The byte array to calculate</param>
    /// <returns>CRC value</returns>
    private static byte CalcCrc(this byte[] array)
    {
        byte crc = 0;
        foreach (byte b in array)
        {
            crc ^= b;
        }
        return crc;
    }
}
