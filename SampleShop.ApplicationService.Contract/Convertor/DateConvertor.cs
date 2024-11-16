using System.Globalization;

namespace SampleShop.ApplicationService.Contract.Convertor
{
    public struct DateConvertor
    {
        public string CreatePerisanDate(DateTime persianDate,out string result)
        {
            var persian = new PersianCalendar();
            persianDate = new DateTime(persian.GetYear(persianDate),
            persian.GetMonth(persianDate),
            persian.GetDayOfMonth(persianDate), persian.GetHour(persianDate), persian.
                GetMinute(persianDate), persian.
                GetSecond(persianDate));
             result = persianDate.ToString();
            return result;
        }
    }
}
