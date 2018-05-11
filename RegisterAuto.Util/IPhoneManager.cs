using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegisterAuto.Util
{
    public interface IPhoneManager
    {
        Task<PhoneResult> GetPhoneAsync(string Phone = "");
        Task<PhoneResult> ReleasePhone(string Phone);
        Task<PhoneResult> GetSMSAsync(string Phone);
    }
    public class ApiPhoneManager : IPhoneManager
    {
        HttpClient hc = new HttpClient();
        Random rand = new Random((int)DateTime.Now.Ticks);
        public async Task<PhoneResult> GetPhoneAsync(string Phone = "")
        {
            var phoneResult = new PhoneResult();
            try
            {
                int cr = rand.Next(1, 4);
                var rt = $"http://cmyzm.5awo.com:8050/http.aspx?action=getMobilenum&pid=9116&uid=api_bashi&token=d2a9c4ac29bdae48&size=1&cr={cr}";
                if (string.IsNullOrWhiteSpace(Phone))
                    rt = $"{rt}&mobile={Phone}";
                var txt = await hc.GetStringAsync(rt);

                if (txt.Contains("|"))
                {
                    var phoneNumber = txt.Split('|')[0];
                    if (!phoneNumber.StartsWith("1"))
                    {
                        phoneResult.Success = false;
                        phoneResult.Msg = $"获取手机号格式不正确：{txt}";
                    }
                    else
                        phoneResult.Success = true;
                    phoneResult.Data = phoneNumber;
                }
                else
                {
                    phoneResult.Success = false;
                    phoneResult.Msg = $"获取手机号失败：{txt}";
                }
            }
            catch (Exception ex)
            {

                phoneResult.Success = false;
                phoneResult.Msg = ex.Message;
            }
            return phoneResult;
        }
        public async Task<PhoneResult> ReleasePhone(string Phone)
        {
            var phoneResult = new PhoneResult();
            try
            {
                var rt = $"http://cmyzm.5awo.com:8050/http.aspx?action=ReleaseMobile&uid=api_bashi&token=d2a9c4ac29bdae48&mobile={Phone}";
                var txt = await hc.GetStringAsync(rt);
                phoneResult.Success = true;
            }
            catch (Exception ex)
            {
                phoneResult.Success = false;
                phoneResult.Msg = ex.Message;
            }
            return phoneResult;
        }

        public async Task<PhoneResult> GetSMSAsync(string Phone)
        {
            var phoneResult = new PhoneResult();
            try
            {
                var rt = $"http://cmyzm.5awo.com:8050/http.aspx?action=getVcodeAndReleaseMobile&uid=api_bashi&token=d2a9c4ac29bdae48&pid=9116&mobile={Phone}";
                var txt = await hc.GetStringAsync(rt);
                if (txt.Contains("|"))
                {
                    Regex regex = new Regex(@"(?<!\d)\d{4,6}(?!\d)");

                    var matches = regex.Matches(rt);
                    if (!regex.IsMatch(txt))
                    {
                        phoneResult.Success = false;
                        phoneResult.Msg = "验证码解析失败";
                    }
                    else
                    {
                        phoneResult.Success = true;
                        phoneResult.Data = regex.Match(txt).Value;
                    }
                }
                else
                {
                    phoneResult.Success = false;
                    phoneResult.Msg = "返回内容中没有找到|";
                }

            }
            catch (Exception ex)
            {
                phoneResult.Success = false;
                phoneResult.Msg = ex.Message;
            }
            return phoneResult;
        }

    }
    public class PhoneResult
    {
        public bool Success { get; set; }
        public string Data { get; set; }
        public string Msg { get; set; }
    }
}
