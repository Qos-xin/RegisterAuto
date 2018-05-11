using RegisterAuto.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterAuto.Orange
{
    public class Work
    {
        public async void StartAsync()
        {
            IPhoneManager phoneManager = new ApiPhoneManager();
            var phone = await phoneManager.GetPhoneAsync();
            var mobileInfo = new MobileInfo
            {
                Mobile = "18600586330"
            };
            if (await mobileInfo.LoadInfoAsync())
            {

                OrangeHandle orangeHandle = new OrangeHandle(mobileInfo);
                await orangeHandle._1StartAdAsync();
                await orangeHandle._2CreateRecordDataAsync();
                await orangeHandle._3GetUpdateVersionInfoAsync();
                await orangeHandle._4GetTwoOneActiveAsync();
                await orangeHandle._5GetCurrentTimeAsync();
                await orangeHandle._6SceneIndexAsync();
                await orangeHandle._7GetMIndexBannerByTypeAsync();
                await orangeHandle._8SendVerifySMSIsCheckAsync();
                var snsResult = await phoneManager.GetSMSAsync(phone.Data);
                await orangeHandle._9DoRegisterAsync(snsResult.Data);
                await orangeHandle._10PersonalCenterNewAsync();
            }

        }
    }
}
