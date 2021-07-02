using static MessageService.Common.ExtraModels.Country;

namespace MessageService.Resources.Api.OperationsWithCountry
{
    public static class DetectCountry
    {
        public static Countries DetectingByPhoneNumber(string phoneNumber)
        {
            foreach (var c in CountryMobileCodes)
            {
                if (phoneNumber.Contains(c.Value))
                {
                    return c.Key;
                }
            }
            return Countries.NotRegistered;
        }
    }
}
