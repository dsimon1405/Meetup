using System.Globalization;

namespace MeetupAPI.View
{
    public static class Parser
    {
        public static bool TryParseStringToDateTime(string source, out DateTime destination, out string mistake)
        {
            destination = new ();
            mistake = string.Empty;

            try
            {
                destination = DateTime.Parse(source, CultureInfo.GetCultureInfo("de-DE"));
            }
            catch (Exception exception)
            {
                mistake = exception.Message;
                return false;
            }

            return true;
        }
    }
}
