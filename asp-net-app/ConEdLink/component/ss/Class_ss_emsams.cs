using Class_ss;
using HtmlAgilityPack;
using kix;
using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Web;

namespace ConEdLink.component.ss
  {
  public static class Class_ss_emsams_Static
    {
    }

  internal class Class_ss_emsams : TClass_ss
    {

    private bool Request_ems_health_state_pa_us_Emsportal
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/emsportal/");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "http://www.emsi.org/";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"loginid=Rekaufman; __utma=106443904.163291999.1326547990.1326547990.1326547990.1; __utmz=106443904.1326547990.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_Emsportal_Login
      (
      CookieContainer cookie_container,
      string view_state,
      string event_validation,
      string username,
      string password,
      out HttpWebResponse response
      )
      {
	    response = null;
	    try
	      {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/emsportal/");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
        //
		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/emsportal/";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.ContentType = "application/x-www-form-urlencoded";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=dh4f2wnm3ei4m1xogh0yp3lb");
        //
		    request.Method = "POST";
        //
		    string postString = @"__LASTFOCUS=&__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=" + HttpUtility.UrlEncode(view_state) + "&__EVENTVALIDATION=" + HttpUtility.UrlEncode(event_validation) + "&ctl00%24ctl00%24SessionLinkBar%24Content%24txtUserName=" + HttpUtility.UrlEncode(username) + "&ctl00%24ctl00%24SessionLinkBar%24Content%24txtPassword=" + HttpUtility.UrlEncode(password) + "&ctl00%24ctl00%24SessionLinkBar%24Content%24cmdLoginUser=Login";
		    byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(postString);
		    request.ContentLength = postBytes.Length;
		    Stream stream = request.GetRequestStream();
		    stream.Write(postBytes, 0, postBytes.Length);
		    stream.Close();
        //
		    response = (HttpWebResponse)request.GetResponse();
	      }
	    catch (WebException e)
	      {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	      }
	    catch (Exception)
	      {
		    if(response != null) response.Close();
		    return false;
	      }
	    return true;
      }

    private bool Request_ems_health_state_pa_us_EmsportalApplicationlist
    (
    CookieContainer cookie_container,
    out HttpWebResponse response
    )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/emsportal/ApplicationList.aspx");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/emsportal/";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"loginid=Rekaufman; ASP.NET_SessionId=yals2q1pqdsx0xgye24t2d2u; __utma=106443904.163291999.1326547990.1326547990.1326547990.1; __utmz=106443904.1326547990.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	      return true;
      }

    private static bool Request_ems_health_state_pa_us_EmsportalApplicationtransfersTransfertoconed
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
      {
	    response = null;

	    try
	      {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/EMSPortal/ApplicationTransfers/TransferToConEd.aspx");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/EMSPortal/ApplicationList.aspx";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=hymy3yujgf1gaopjfodpcqfn");

		    response = (HttpWebResponse)request.GetResponse();
	      }
	    catch (WebException e)
	      {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
  	    }
	    catch (Exception)
	      {
		    if(response != null) response.Close();
		    return false;
	      }

	    return true;
      }

    private static bool Request_ems_health_state_pa_us_EmsportalApplicationtransfersTransfertoemsreg
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
      {
	    response = null;

	    try
	      {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/EMSPortal/ApplicationTransfers/TransferToEMSREG.aspx");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/EMSPortal/ApplicationList.aspx";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=hymy3yujgf1gaopjfodpcqfn");

		    response = (HttpWebResponse)request.GetResponse();
	      }
	    catch (WebException e)
	      {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
  	    }
	    catch (Exception)
	      {
		    if(response != null) response.Close();
		    return false;
	      }

	    return true;
      }

    private bool Request_ems_health_state_pa_us_EmsregDefault
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
      {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/emsreg/default.aspx?Version=2.2.25");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/EMSPortal/ApplicationList.aspx";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"__utma=106443904.163291999.1326547990.1326547990.1326547990.1; __utmz=106443904.1326547990.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); ASP.NET_SessionId=gra35ekc4fbgr4yn5umh2oii; loginid=Rekaufman");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
      }

    private bool Request_ems_health_state_pa_us_EmsregPractitionerHome
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/emsreg/practitioner/home.aspx");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/EMSPortal/ApplicationList.aspx";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"__utma=106443904.163291999.1326547990.1326547990.1326547990.1; __utmz=106443904.1326547990.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); ASP.NET_SessionId=gra35ekc4fbgr4yn5umh2oii; loginid=Rekaufman; EMSREG=A91AB0CB7AB6A388CBC1664AEFB890AA8816CBEF1748B3D6D49C1D92F6988868DA7ACAE842B48004CF52E8A9A91CD3A0582CBFDF8C87D1BAEE31B4894F684484455FE1FBA0CFDAA855AA3117CF2CBA903CAABFCE2759417082B51258F468F133082D8EE27AA3F45534ABAE3E553C522DF79BF19ED36EEC805F45A016EBB9B72FF0144E83DF6B6A8AF60F63FD9B0012744A1E62C36164DA09E965405523E79B0A0ABEDEAAA2267E88F86F7D8BCE167CC2381F138948BC25B53589445951D7CB344A95F6DE4A9B9793EC89779E5C70E076F5957E0DF3EFAF9BB0E34828207FCA9E449E0FFED42543F03E198D16131C9B67");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private bool Request_ems_health_state_pa_us_EmsregReportsReportlist
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/emsreg/Reports/ReportList.aspx");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/emsreg/practitioner/home.aspx";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"__utma=106443904.163291999.1326547990.1326547990.1326547990.1; __utmz=106443904.1326547990.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); ASP.NET_SessionId=gra35ekc4fbgr4yn5umh2oii; loginid=Rekaufman; EMSREG=A91AB0CB7AB6A388CBC1664AEFB890AA8816CBEF1748B3D6D49C1D92F6988868DA7ACAE842B48004CF52E8A9A91CD3A0582CBFDF8C87D1BAEE31B4894F684484455FE1FBA0CFDAA855AA3117CF2CBA903CAABFCE2759417082B51258F468F133082D8EE27AA3F45534ABAE3E553C522DF79BF19ED36EEC805F45A016EBB9B72FF0144E83DF6B6A8AF60F63FD9B0012744A1E62C36164DA09E965405523E79B0A0ABEDEAAA2267E88F86F7D8BCE167CC2381F138948BC25B53589445951D7CB344A95F6DE4A9B9793EC89779E5C70E076F5957E0DF3EFAF9BB0E34828207FCA9E449E0FFED42543F03E198D16131C9B67");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private bool Request_ems_health_state_pa_us_EmsregReportsAvailablececlasseslistsearch
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/emsreg/Reports/AvailableCEClassesListSearch.aspx");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/emsreg/Reports/ReportList.aspx";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"__utma=106443904.163291999.1326547990.1326547990.1326547990.1; __utmz=106443904.1326547990.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); ASP.NET_SessionId=gra35ekc4fbgr4yn5umh2oii; loginid=Rekaufman; EMSREG=A91AB0CB7AB6A388CBC1664AEFB890AA8816CBEF1748B3D6D49C1D92F6988868DA7ACAE842B48004CF52E8A9A91CD3A0582CBFDF8C87D1BAEE31B4894F684484455FE1FBA0CFDAA855AA3117CF2CBA903CAABFCE2759417082B51258F468F133082D8EE27AA3F45534ABAE3E553C522DF79BF19ED36EEC805F45A016EBB9B72FF0144E83DF6B6A8AF60F63FD9B0012744A1E62C36164DA09E965405523E79B0A0ABEDEAAA2267E88F86F7D8BCE167CC2381F138948BC25B53589445951D7CB344A95F6DE4A9B9793EC89779E5C70E076F5957E0DF3EFAF9BB0E34828207FCA9E449E0FFED42543F03E198D16131C9B67");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private bool Request_ems_health_state_pa_us_EmsregReportsAvailablececlasseslistsearch_From
      (
      CookieContainer cookie_container,
      string view_state,
      string event_validation,
      string date_from,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/emsreg/Reports/AvailableCEClassesListSearch.aspx");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/emsreg/Reports/AvailableCEClassesListSearch.aspx";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.ContentType = "application/x-www-form-urlencoded";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"__utma=106443904.163291999.1326547990.1326547990.1326547990.1; __utmz=106443904.1326547990.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); ASP.NET_SessionId=gra35ekc4fbgr4yn5umh2oii; loginid=Rekaufman; EMSREG=4704B228D3FD0BE7891F4D9E004D4B0C01479A4F7ECABE552DBFA33BD000CD98A02F9006BC7346ED4C01BBB33971EBF624EAC2F2EEF7B7B51C8A1A8277F571873D68F7C8737E88744502676CCE7B48054AEF794125C22CF09C09A0DBF5748571226E3257FAB6C806DE42238B4CF164E92164B32555DC4FE2EF3F0046F2F58B1651FF0FB897AAFB97D1677A543A87C9A0ED61D4A8F443CE1AA6F2D6DCFDC51CE8F53E939F3C967938B134B3F1D9936A3425E46EFAC1CBDDC6AD66F6625CB91B4152CE7213B980F91BEC0F1AFC2406DFB96D5602571BA911A5E48F479B1F201D62BDE149B176BA064DA34FCB58F05E47B2");

		    request.Method = "POST";

		    string postString = @"__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=" + HttpUtility.UrlEncode(view_state) + "&__EVENTVALIDATION=" + HttpUtility.UrlEncode(event_validation) + "&_ctl0%3A_ctl0%3ASessionLinkBar%3AContent%3ADateRangeControl1%3AtbxDateFrom=" + HttpUtility.UrlEncode(date_from) + "&_ctl0%3A_ctl0%3ASessionLinkBar%3AContent%3ADateRangeControl1%3AtbxDateTo=12%2F31%2F9999&_ctl0%3A_ctl0%3ASessionLinkBar%3AContent%3AReportFormat%3ArdlFormat=2&_ctl0%3A_ctl0%3ASessionLinkBar%3AContent%3AbtnGenerateReport=Generate+Report";
		    byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(postString);
		    request.ContentLength = postBytes.Length;
		    Stream stream = request.GetRequestStream();
		    stream.Write(postBytes, 0, postBytes.Length);
		    stream.Close();

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_ConedClasssearch
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/ClassSearch.asp");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/MainMenu.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=hymy3yujgf1gaopjfodpcqfn; ConEd_EMSOUserID=345; ASPSESSIONIDSCCDSBCQ=JDKNGNNCEFNLKBKABEAGCCPJ; ASPSESSIONIDQCBBRDCQ=MFMNIHOCGKDFKAECCINFODBN; EMS_EMSOUserID=KALipscomb; EMS_EMSOType=QRS; ASPSESSIONIDSCDBSADR=BAMDPJOCCGMIMJLGHPPCFEIG; ASPSESSIONIDQCDARDDQ=OABNCNOCAOGCDDDIGLEBHGFH; ASPSESSIONIDSABBRDDR=AKIJMAPCAGNFPBAIGBJEHGJN");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_ConedClasssearch_Coned_Filedelimited_Searchnow
      (
      CookieContainer cookie_container,
      string date_from,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/ClassSearch.asp");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/ClassSearch.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.ContentType = "application/x-www-form-urlencoded";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=drkxrxkrje0i1irpscgw35g3; ConEd_EMSOUserID=345; ASPSESSIONIDSCDATADQ=NLGPKEICGOFDPEKCGMIBHCHH");

		    request.Method = "POST";

		    string postString = @"SearchMode=&cmdMove=Search+Now&ClassType=CONED&CourseNumber=&CourseTitle=&CourseCode=&StartDate_Low=" + HttpUtility.UrlEncode(date_from) + "&StartDate_High=&ClassCountyCode=&RegionCouncilNum=&ClassNumber=&IncludeDisapprovedClasses=0&OutputFormat=FileDelimited";
		    byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(postString);
		    request.ContentLength = postBytes.Length;
		    Stream stream = request.GetRequestStream();
		    stream.Write(postBytes, 0, postBytes.Length);
		    stream.Close();

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_ConedClasssearch_Coned_Searchnow
      (
      CookieContainer cookie_container,
      string date_from,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/ClassSearch.asp");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/ClassSearch.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.ContentType = "application/x-www-form-urlencoded";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=drkxrxkrje0i1irpscgw35g3; ConEd_EMSOUserID=345; ASPSESSIONIDSCDATADQ=NLGPKEICGOFDPEKCGMIBHCHH");

		    request.Method = "POST";

		    string postString = @"SearchMode=&cmdMove=Search+Now&ClassType=CONED&CourseNumber=&CourseTitle=&CourseCode=&StartDate_Low=" + HttpUtility.UrlEncode(date_from) + "&StartDate_High=&ClassCountyCode=&RegionCouncilNum=&ClassNumber=&IncludeDisapprovedClasses=0&OutputFormat=Screen";
		    byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(postString);
		    request.ContentLength = postBytes.Length;
		    Stream stream = request.GetRequestStream();
		    stream.Write(postBytes, 0, postBytes.Length);
		    stream.Close();

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_ConedExportClasssearchtxt
      (
      CookieContainer cookie_container,
      string user_id,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/Export/ClassSearch_" + user_id + ".txt");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "text/html, application/xhtml+xml, */*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/ClassSearch.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=eftwud551xujf0rdibjcz4re");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_ConedExportSponsorsearchtxt
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/Export/SponsorSearch_345.txt");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/SponsorSearch.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=jcydtlzcjxtbyawd4zjsbg3w; ConEd_EMSOUserID=345; ASPSESSIONIDQCBBQCCR=HCGDCOMCLNEJMAGGPPNHCAFM");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_ConedListclassnumbers
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/ListClassNumbers.asp");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "*/*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/ClassSearch.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=hymy3yujgf1gaopjfodpcqfn; ConEd_EMSOUserID=345; ASPSESSIONIDSCCDSBCQ=JDKNGNNCEFNLKBKABEAGCCPJ; ASPSESSIONIDQCBBRDCQ=MFMNIHOCGKDFKAECCINFODBN; EMS_EMSOUserID=KALipscomb; EMS_EMSOType=QRS; ASPSESSIONIDSCDBSADR=BAMDPJOCCGMIMJLGHPPCFEIG; ASPSESSIONIDQCDARDDQ=OABNCNOCAOGCDDDIGLEBHGFH; ASPSESSIONIDSABBRDDR=AKIJMAPCAGNFPBAIGBJEHGJN");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_ConedListClassNumbers_Coned_2011_999999_ShowNumbers
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/ListClassNumbers.asp");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/ListClassNumbers.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.ContentType = "application/x-www-form-urlencoded";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
		    request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=hymy3yujgf1gaopjfodpcqfn; ConEd_EMSOUserID=345; ASPSESSIONIDSCCDSBCQ=JDKNGNNCEFNLKBKABEAGCCPJ; ASPSESSIONIDQCBBRDCQ=MFMNIHOCGKDFKAECCINFODBN; EMS_EMSOUserID=KALipscomb; EMS_EMSOType=QRS; ASPSESSIONIDSCDBSADR=BAMDPJOCCGMIMJLGHPPCFEIG; ASPSESSIONIDQCDARDDQ=OABNCNOCAOGCDDDIGLEBHGFH; ASPSESSIONIDSABBRDDR=AKIJMAPCAGNFPBAIGBJEHGJN");

		    request.Method = "POST";

		    string postString = @"ClassType=CONED&ClassYear=2011&HowMany=999999&cmdMove=Show+Numbers";
		    byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(postString);
		    request.ContentLength = postBytes.Length;
		    Stream stream = request.GetRequestStream();
		    stream.Write(postBytes, 0, postBytes.Length);
		    stream.Close();

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_Coned_Mainmenu_Logout
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/MainMenu.asp?cmdMove=logout");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/MainMenu.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=5rk44se5bzjgtspmizipbpwp; ConEd_EMSOUserID=345; ASPSESSIONIDQCCATACQ=IPDLADIDOFONKEFNONAJIAEK");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_ConedSponsorsearch
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/SponsorSearch.asp");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/MainMenu.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=jcydtlzcjxtbyawd4zjsbg3w; ConEd_EMSOUserID=345; ASPSESSIONIDQCBBQCCR=HCGDCOMCLNEJMAGGPPNHCAFM");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }    

    private static bool Request_ems_health_state_pa_us_ConedSponsorsearch_Filedelimited_Searchnow
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/SponsorSearch.asp");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/SponsorSearch.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.ContentType = "application/x-www-form-urlencoded";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=jcydtlzcjxtbyawd4zjsbg3w; ConEd_EMSOUserID=345; ASPSESSIONIDQCBBQCCR=HCGDCOMCLNEJMAGGPPNHCAFM");

		    request.Method = "POST";

		    string postString = @"cmdMove=Search+Now&name=&number=&Region=&CountyCode=&ExpirationDate_Low=&ExpirationDate_High=&Status=&ApplicationDate_Low=&ApplicationDate_High=&ProcessDate_Low=&ProcessDate_High=&OutputFormat=FileDelimited";
		    byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(postString);
		    request.ContentLength = postBytes.Length;
		    Stream stream = request.GetRequestStream();
		    stream.Write(postBytes, 0, postBytes.Length);
		    stream.Close();

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_ConedSponsorsearch_StatusSearchnow
      (
      CookieContainer cookie_container,
      string status,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/SponsorSearch.asp");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/SponsorSearch.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.ContentType = "application/x-www-form-urlencoded";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"__utma=106443904.163291999.1326547990.1326547990.1326547990.1; __utmz=106443904.1326547990.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); ASPSESSIONIDACBATCSR=GAFPJGNBECCHBGLEJILLKFCL");

		    request.Method = "POST";

		    string postString = @"cmdMove=Search+Now&name=&number=&Region=&CountyCode=&ExpirationDate_Low=&ExpirationDate_High=&Status=" + status + "&ApplicationDate_Low=&ApplicationDate_High=&ProcessDate_Low=&ProcessDate_High=";
		    byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(postString);
		    request.ContentLength = postBytes.Length;
		    Stream stream = request.GetRequestStream();
		    stream.Write(postBytes, 0, postBytes.Length);
		    stream.Close();

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_ConedUsersearch
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/UserSearch.asp");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/MainMenu.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=5gecqtoycvwyikzjp3kz0mtz; ConEd_EMSOUserID=345; ASPSESSIONIDQCACSBCQ=NJAJLPMAEMPCLKMBIIEGHPLA");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_ConedUsersearch_RegionalCouncilId_SearchNow
      (
      CookieContainer cookie_container,
      string regional_council_id,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/UserSearch.asp");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/ConEd/UserSearch.asp";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.ContentType = "application/x-www-form-urlencoded";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=5gecqtoycvwyikzjp3kz0mtz; ConEd_EMSOUserID=345; ASPSESSIONIDQCACSBCQ=NJAJLPMAEMPCLKMBIIEGHPLA");

		    request.Method = "POST";

		    string postString = @"SponsorName=&SponsorID=&cmdMove=Search+Now&FirstName=&LastName=&CertNumber=&RegionalCouncilID=" + regional_council_id + "&CountyCode=";
		    byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(postString);
		    request.ContentLength = postBytes.Length;
		    Stream stream = request.GetRequestStream();
		    stream.Write(postBytes, 0, postBytes.Length);
		    stream.Close();

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_EmsregActivepractitioners
      (
      CookieContainer cookie_container,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/emsreg/ActivePractitioners.aspx");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"__utma=106443904.163291999.1326547990.1326547990.1326547990.1; __utmz=106443904.1326547990.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)");

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    private static bool Request_ems_health_state_pa_us_EmsregActivepractitioners_3000
      (
      CookieContainer cookie_container,
      string view_state,
      string event_validation,
      string next_page_ctl_num,
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/emsreg/ActivePractitioners.aspx");
        request.CookieContainer = cookie_container;
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

		    request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, */*";
		    request.Referer = "https://ems.health.state.pa.us/emsreg/ActivePractitioners.aspx";
		    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
		    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
		    request.ContentType = "application/x-www-form-urlencoded";
		    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
		    request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
		    //request.Headers.Set(HttpRequestHeader.Cookie, @"ASP.NET_SessionId=2l0x3eidkit2jetl4uovsqsv");

		    request.Method = "POST";

        string postString = @"__EVENTTARGET=" + (next_page_ctl_num.Length == 0 ? k.EMPTY : "_ctl0%24_ctl0%24SessionLinkBar%24Content%24dgActivePractitioners%24_ctl3004%24_ctl" + next_page_ctl_num)
        + "&__EVENTARGUMENT=&__VIEWSTATE=" + (view_state.Length > 0 ? HttpUtility.UrlEncode(view_state) : "%2FwEPDwULLTExNzg2MTQwMjgPZBYCZg9kFgJmD2QWAgIDD2QWAgIDD2QWAgIBD2QWBAI3DxBkDxYcZgIBAgICAwIEAgUCBgIHAggCCQIKAgsCDAINAg4CDwIQAhECEgITAhQCFQIWAhcCGAIZAhoCGxYcEAUCMjAFAjIwZxAFAjUwBQI1MGcQBQMxMDAFAzEwMGcQBQMxNTAFAzE1MGcQBQMyMDAFAzIwMGcQBQMyNTAFAzI1MGcQBQMzMDAFAzMwMGcQBQMzNTAFAzM1MGcQBQM0MDAFAzQwMGcQBQM0NTAFAzQ1MGcQBQM1MDAFAzUwMGcQBQQxMDAwBQQxMDAwZxAFBDIwMDAFBDIwMDBnEAUEMzAwMAUEMzAwMGcQBQIyMAUCMjBnEAUCNTAFAjUwZxAFAzEwMAUDMTAwZxAFAzE1MAUDMTUwZxAFAzIwMAUDMjAwZxAFAzI1MAUDMjUwZxAFAzMwMAUDMzAwZxAFAzM1MAUDMzUwZxAFAzQwMAUDNDAwZxAFAzQ1MAUDNDUwZxAFAzUwMAUDNTAwZxAFBDEwMDAFBDEwMDBnEAUEMjAwMAUEMjAwMGcQBQQzMDAwBQQzMDAwZxYBZmQCOw88KwALAGRkaaMuzfh9ltl6IOR911kmcVkKMgITOI%2BDw%2BK%2FXyHUuj0%3D")
        + "&__EVENTVALIDATION=" + (event_validation.Length > 0 ? HttpUtility.UrlEncode(event_validation) : "%2FwEWOQL30Y%2BjBwKk3e29BwKsi5ORBwKsi4%2BRBwKsi4uRBwKsi4eRBwKsi4ORBwKsi%2F%2BQBwKsi%2FuQBwKsi%2FeQBwKsi%2FOQBwKsi%2B%2BQBwKsi%2BuQBwKsi%2BeQBwKsi%2BOQBwKsi9%2BQBwKsi9uQBwKsi9eQBwKsi9OQBwKsi8%2BQBwKsi8uQBwKsi8eQBwKsi8OQBwKsi7%2BQBwKsi7uQBwKsi7eQBwKsi7OQBwKsi6%2BQBwK%2Fo8WnCwK6o8WnCwKY4qLwDAKY4tbzDAKZ4qLwDAKZ4tbzDAKW4qLwDAKW4tbzDAKX4qLwDAKX4tbzDAKU4qLwDAKY4uLNBwKZ4uLNBwKW4uLNBwK%2Fo8WnCwK6o8WnCwKY4qLwDAKY4tbzDAKZ4qLwDAKZ4tbzDAKW4qLwDAKW4tbzDAKX4qLwDAKX4tbzDAKU4qLwDAKY4uLNBwKZ4uLNBwKW4uLNBwL3s5yCAjrn621pzzM%2FnReSpQ%2B3sr4F3e12hGqbdpT1XiF0WhEX")
        + "&_ctl0%3A_ctl0%3ASessionLinkBar%3AContent%3AddPageSize=3000"
        + (next_page_ctl_num.Length == 0 ? "&_ctl0%3A_ctl0%3ASessionLinkBar%3AContent%3AbtnRefresh=Refresh" : k.EMPTY);
		    byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(postString);
		    request.ContentLength = postBytes.Length;
		    Stream stream = request.GetRequestStream();
		    stream.Write(postBytes, 0, postBytes.Length);
		    stream.Close();

		    response = (HttpWebResponse)request.GetResponse();
	    }
	    catch (WebException e)
	    {
		    if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
		    else return false;
	    }
	    catch (Exception)
	    {
		    if(response != null) response.Close();
		    return false;
	    }

	    return true;
    }

    internal void Login(CookieContainer cookie_container)
      {
      HttpWebResponse response;
      if (!Request_ems_health_state_pa_us_Emsportal(cookie_container,out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_Emsportal() returned FALSE.");
        }
      var html_document = HtmlDocumentOf(ConsumedStreamOf(response));
      if(!Request_ems_health_state_pa_us_Emsportal_Login
          (
          cookie_container,
          ViewstateOf(html_document),
          EventValidationOf(html_document),
          ConfigurationManager.AppSettings["emsportal_login_username"],
          ConfigurationManager.AppSettings["emsportal_login_password"],
          out response
          )
        )
        {
        throw new Exception("Request_ems_health_state_pa_us_Emsportal_Login() returned FALSE.");
        }
      if (!Request_ems_health_state_pa_us_EmsportalApplicationlist(cookie_container,out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_EmsportalApplicationlist() returned FALSE.");
        }
      if (TitleOf(HtmlDocumentOf(ConsumedStreamOf(response))) != "EMS Login | Application List")
        {
        throw new Exception("Unexpected response from Request_ems_health_state_pa_us_EmsportalApplicationlist().");
        }
      }

    private static void ScrapeConedSponsors
      (
      string status,
      ArrayList teaching_entity_array_list,
      HttpWebResponse response
      )
      {
      var hn_target_table = HtmlDocumentOf(ConsumedStreamOf(response)).DocumentNode.SelectSingleNode("html/body/font/center[2]/center/table");
      //
      var hnc_name = hn_target_table.SelectNodes("tr/td[1]/a");
      var hnc_location_column = hn_target_table.SelectNodes("tr/td[2]");
      var hnc_county_name = hn_target_table.SelectNodes("tr/td[2]/table/tr[2]/td[2]");
      var hnc_teaching_entity_kind = hn_target_table.SelectNodes("tr/td[2]/table/tr[4]/td[1]");
      var hnc_sponsor_number = hn_target_table.SelectNodes("tr/td[2]/table/tr[4]/td[2]");
      var hnc_public_contact_name = hn_target_table.SelectNodes("tr/td[3]/table/tr[1]/td[2]");
      var hnc_public_contact_phone = hn_target_table.SelectNodes("tr/td[3]/table/tr[2]/td[2]");
      var hnc_public_contact_email = hn_target_table.SelectNodes("tr/td[3]/table/tr[3]/td[2]");
      var hnc_public_contact_website_cell = hn_target_table.SelectNodes("tr/td[3]/table/tr[4]/td[2]");
      var hnc_public_contact_notes = hn_target_table.SelectNodes("tr/td[3]/table/tr[5]/td[2]");
      //
      for (var i = new k.subtype<int>(0, hnc_name.Count); i.val < i.LAST; i.val++)
        {
        var county_name = k.Safe(hnc_county_name[i.val].InnerText.Trim(), k.safe_hint_type.ALPHA);
        var teaching_entity_kind = k.Safe(hnc_teaching_entity_kind[i.val].InnerText,k.safe_hint_type.ALPHA);
        if ((county_name != "OutofState") && (teaching_entity_kind == "Sponsor"))
          {
          var teaching_entity = new TeachingEntity();
          var hn_name = hnc_name[i.val];
          var name_href = hn_name.Attributes["href"].Value;
          var name_href_index_of_ampersand = name_href.IndexOf("&");
          teaching_entity.id = k.Safe(name_href.Substring(0, name_href_index_of_ampersand), k.safe_hint_type.NUM);
          teaching_entity.region = k.Safe(name_href.Substring(name_href_index_of_ampersand), k.safe_hint_type.NUM);
          teaching_entity.name = k.Safe(hn_name.InnerText.Trim(), k.safe_hint_type.ORG_NAME);
          var hnc_location_column_children = hnc_location_column[i.val].ChildNodes;
          var hnc_location_column_children_count = hnc_location_column_children.Count;
          teaching_entity.address_1 = (hnc_location_column_children_count == 7 ? k.Safe(hnc_location_column_children[0].InnerText.Trim(), k.safe_hint_type.POSTAL_STREET_ADDRESS) : k.EMPTY);
          teaching_entity.address_2 = (hnc_location_column_children_count == 9 ? k.Safe(hnc_location_column_children[2].InnerText.Trim(), k.safe_hint_type.POSTAL_STREET_ADDRESS) : k.EMPTY);
          var city_state_zip = hnc_location_column_children[hnc_location_column_children_count - 5].InnerText.Replace("&nbsp;",k.SPACE).Trim();
          if (city_state_zip.Length > 0)
            {
            var city_state_zip_index_of_comma = city_state_zip.IndexOf(k.COMMA);
            teaching_entity.city = k.Safe(city_state_zip.Substring(0, city_state_zip_index_of_comma), k.safe_hint_type.POSTAL_CITY);
            teaching_entity.state = k.Safe(city_state_zip.Substring(city_state_zip_index_of_comma), k.safe_hint_type.ALPHA);
            teaching_entity.zip = k.Safe(city_state_zip.Substring(city_state_zip_index_of_comma), k.safe_hint_type.HYPHENATED_NUM);
            }
          teaching_entity.county_name = county_name;
          teaching_entity.sponsor_number = k.Safe(hnc_sponsor_number[i.val].InnerText.Trim(), k.safe_hint_type.HYPHENATED_NUM);
          teaching_entity.public_contact_name = k.Safe(hnc_public_contact_name[i.val].InnerText.Trim(), k.safe_hint_type.HUMAN_NAME);
          teaching_entity.public_contact_phone = k.Safe(hnc_public_contact_phone[i.val].InnerText.Trim(), k.safe_hint_type.PHONE_NUM);
          var hn_public_contact_email = hnc_public_contact_email[i.val].SelectSingleNode("a");
          if (hn_public_contact_email != null)
            {
            teaching_entity.public_contact_email = k.Safe(hn_public_contact_email.InnerText.Trim(), k.safe_hint_type.EMAIL_ADDRESS);
            }
          var hn_public_contact_website = hnc_public_contact_website_cell[i.val].SelectSingleNode("a");
          if (hn_public_contact_website != null)
            {
            teaching_entity.public_contact_website = k.Safe(hn_public_contact_website.InnerText.Trim(), k.safe_hint_type.HTTP_TARGET);
            }
          teaching_entity.public_contact_notes = k.Safe(hnc_public_contact_notes[i.val].InnerText.Trim(), k.safe_hint_type.PUNCTUATED);
          teaching_entity.sponsor_status_description = status;
          teaching_entity_array_list.Add(teaching_entity);
          }
        }
      }

    internal class ConedOffering
      {
      internal string class_id_1 = k.EMPTY;
      internal string class_type = k.EMPTY;
      internal string course_id = k.EMPTY;
      internal string class_number = k.EMPTY;
      internal string course_code = k.EMPTY;
      internal string created_by = k.EMPTY;
      internal string date_created = k.EMPTY;
      internal string last_edited_by = k.EMPTY;
      internal string date_last_edited = k.EMPTY;
      internal string sponsor_id = k.EMPTY;
      internal string sponsor_number = k.EMPTY;
      internal string training_ins_accred_num = k.EMPTY;
      internal string document_status = k.EMPTY;
      internal string class_final_status = k.EMPTY;
      internal string course_number = k.EMPTY;
      internal string location = k.EMPTY;
      internal string student_cost = k.EMPTY;
      internal string tuition_includes = k.EMPTY;
      internal string closed = k.EMPTY;
      internal string estimated_students = k.EMPTY;
      internal string start_date_time = k.EMPTY;
      internal string end_date_time = k.EMPTY;
      internal string start_time = k.EMPTY;
      internal string end_time = k.EMPTY;
      internal string other_dates_and_times = k.EMPTY;
      internal string instructors = k.EMPTY;
      internal string instructor_qualifications = k.EMPTY;
      internal string verification_name = k.EMPTY;
      internal string contact_name = k.EMPTY;
      internal string contact_address_1 = k.EMPTY;
      internal string contact_address_2 = k.EMPTY;
      internal string contact_city = k.EMPTY;
      internal string contact_state = k.EMPTY;
      internal string contact_zip = k.EMPTY;
      internal string contact_daytime_phone = k.EMPTY;
      internal string contact_evening_phone = k.EMPTY;
      internal string contact_email = k.EMPTY;
      internal string public_contact_name = k.EMPTY;
      internal string public_contact_phone = k.EMPTY;
      internal string public_contact_email = k.EMPTY;
      internal string public_contact_website = k.EMPTY;
      internal string public_contact_notes = k.EMPTY;
      internal string date_submitted_to_region = k.EMPTY;
      internal string date_received_by_region = k.EMPTY;
      internal string date_sponsor_notified = k.EMPTY;
      internal string date_registration_sent_to_state = k.EMPTY;
      internal string date_cards_sent_to_sponsor = k.EMPTY;
      internal string date_materials_to_be_returned = k.EMPTY;
      internal string approved = k.EMPTY;
      internal string region_comments = k.EMPTY;
      internal string region_council_num = k.EMPTY;
      internal string class_county_code = k.EMPTY;
      internal string total_class_hours = k.EMPTY;
      internal string location_address_1 = k.EMPTY;
      internal string location_address_2 = k.EMPTY;
      internal string location_city = k.EMPTY;
      internal string location_state = k.EMPTY;
      internal string location_zip = k.EMPTY;
      internal string location_zip_plus_4 = k.EMPTY;
      internal string location_phone = k.EMPTY;
      internal string location_email = k.EMPTY;
      internal string location_of_registration = k.EMPTY;
      internal string primary_text = k.EMPTY;
      internal string additional_texts = k.EMPTY;
      internal string final_registration_date = k.EMPTY;
      internal string offered_as_college_credit = k.EMPTY;
      internal string practical_exam_date = k.EMPTY;
      internal string written_exam_date = k.EMPTY;
      internal string disapproval_reason_id = k.EMPTY;
      internal string date_final_paperwork_received = k.EMPTY;
      internal string signed_hard_copy = k.EMPTY;
      internal string created_by_first_name = k.EMPTY;
      internal string created_by_last_name = k.EMPTY;
      internal string class_disapproval_reason_description = k.EMPTY;
      internal string class_final_status_description = k.EMPTY;
      internal string sponsor_name = k.EMPTY;
      internal string courses_course_number = k.EMPTY;
      internal string course_title = k.EMPTY;
      internal string cert_course_code = k.EMPTY;
      internal string cert_course_description = k.EMPTY;
      internal string class_id_2 = k.EMPTY;
      //
      internal string fr_med_trauma_hours = k.EMPTY;
      internal string fr_other_hours = k.EMPTY;
      internal string emt_med_trauma_hours = k.EMPTY;
      internal string emt_other_hours = k.EMPTY;
      internal string emtp_med_trauma_hours = k.EMPTY;
      internal string emtp_other_hours = k.EMPTY;
      internal string phrn_med_trauma_hours = k.EMPTY;
      internal string phrn_other_hours = k.EMPTY;
      internal string length = k.EMPTY;
      internal string region_council_name = k.EMPTY;
      internal string class_county_name = k.EMPTY;
      //
      internal string class_start_date = k.EMPTY;
      internal string class_start_time = k.EMPTY;
      internal string class_end_date = k.EMPTY;
      internal string class_end_time = k.EMPTY;
      internal string total_ceus = k.EMPTY;
      internal string fr_ce_trauma = k.EMPTY;
      internal string fr_ce_other = k.EMPTY;
      internal string fr_ce_total = k.EMPTY;
      internal string emt_ce_trauma = k.EMPTY;
      internal string emt_ce_other = k.EMPTY;
      internal string emt_ce_total = k.EMPTY;
      internal string als_ce_total = k.EMPTY;
      internal string als_ce_trauma = k.EMPTY;
      internal string als_ce_other = k.EMPTY;
      internal string tuition = k.EMPTY;
      internal string instructor_name = k.EMPTY;
      internal string contact_name_1 = k.EMPTY;
      internal string class_location = k.EMPTY;
      internal string class_city_state = k.EMPTY;
      internal string class_region_code = k.EMPTY;
      }
    internal ArrayList AvailableConedClassesList()
      {
      var available_coned_classes_list = new ArrayList();
      var cookie_container = new CookieContainer();
      //
      Login(cookie_container);
      //
      HttpWebResponse response;
      if (!Request_ems_health_state_pa_us_EmsportalApplicationtransfersTransfertoemsreg(cookie_container,out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_EmsportalApplicationtransfersTransfertoemsreg() returned FALSE.");
        }
      if (!Request_ems_health_state_pa_us_EmsregDefault(cookie_container,out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_EmsregDefault() returned FALSE.");
        }
      if (!Request_ems_health_state_pa_us_EmsregPractitionerHome(cookie_container,out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_EmsregPractitionerHome() returned FALSE.");
        }
      if (!Request_ems_health_state_pa_us_EmsregReportsReportlist(cookie_container,out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_EmsregReportsReportlist() returned FALSE.");
        }
      if (!Request_ems_health_state_pa_us_EmsregReportsAvailablececlasseslistsearch(cookie_container,out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_EmsregReportsAvailablececlasseslistsearch() returned FALSE.");
        }
      var html_document = HtmlDocumentOf(ConsumedStreamOf(response));
      if(!Request_ems_health_state_pa_us_EmsregReportsAvailablececlasseslistsearch_From
          (
          cookie_container,
          ViewstateOf(html_document),
          EventValidationOf(html_document),
          DateTime.Today.AddMonths(-2).ToString(),
          out response
          )
        )
        {
        throw new Exception("Request_ems_health_state_pa_us_EmsregReportsAvailablececlasseslistsearch_FromToFormatGenerateReport() returned FALSE.");
        }
      var stream_string = ConsumedStreamOf(response).Replace("&nbsp;",k.EMPTY);
      var hn_target_table = HtmlDocumentOf(stream_string).DocumentNode.SelectSingleNode("table");
      //
      var hnc_course_number = hn_target_table.SelectNodes("tr/td[1]");
      var hnc_course_title = hn_target_table.SelectNodes("tr/td[2]");
      var hnc_class_number = hn_target_table.SelectNodes("tr/td[3]");
      var hnc_class_start_date = hn_target_table.SelectNodes("tr/td[4]");
      var hnc_class_start_time = hn_target_table.SelectNodes("tr/td[5]");
      var hnc_class_end_date = hn_target_table.SelectNodes("tr/td[6]");
      var hnc_class_end_time = hn_target_table.SelectNodes("tr/td[7]");
      var hnc_total_ceus = hn_target_table.SelectNodes("tr/td[8]");
      var hnc_fr_ce_trauma = hn_target_table.SelectNodes("tr/td[9]");
      var hnc_fr_ce_other = hn_target_table.SelectNodes("tr/td[10]");
      var hnc_fr_ce_total = hn_target_table.SelectNodes("tr/td[11]");
      var hnc_emt_ce_trauma = hn_target_table.SelectNodes("tr/td[12]");
      var hnc_emt_ce_other = hn_target_table.SelectNodes("tr/td[13]");
      var hnc_emt_ce_total = hn_target_table.SelectNodes("tr/td[14]");
      //
      // Values that EMSRS reports in the following columns are unreliable.  They appear to be double the appropriate values.
      //
      //var hnc_als_ce_total = hn_target_table.SelectNodes("tr/td[15]");
      //var hnc_als_ce_other = hn_target_table.SelectNodes("tr/td[16]");
      //var hnc_als_ce_trauma = hn_target_table.SelectNodes("tr/td[17]");
      //
      var hnc_tuition = hn_target_table.SelectNodes("tr/td[18]");
      var hnc_sponsor_name = hn_target_table.SelectNodes("tr/td[19]");
      var hnc_sponsor_number = hn_target_table.SelectNodes("tr/td[20]");
      var hnc_instructor_name = hn_target_table.SelectNodes("tr/td[21]");
      var hnc_contact_name = hn_target_table.SelectNodes("tr/td[22]");
      var hnc_contact_name_1 = hn_target_table.SelectNodes("tr/td[23]");
      var hnc_location = hn_target_table.SelectNodes("tr/td[24]");
      var hnc_class_location = hn_target_table.SelectNodes("tr/td[25]");
      var hnc_class_city_state = hn_target_table.SelectNodes("tr/td[26]");
      var hnc_class_county_code = hn_target_table.SelectNodes("tr/td[27]");
      var hnc_class_region_code = hn_target_table.SelectNodes("tr/td[28]");
      //
      for (var i = new k.subtype<int>(1,hnc_course_number.Count); i.val < i.LAST; i.val++)
        {
        var coned_offering = new ConedOffering();
        coned_offering.course_number = k.Safe(hnc_course_number[i.val].InnerText.Trim(),k.safe_hint_type.NUM);
        coned_offering.course_title = k.Safe(hnc_course_title[i.val].InnerText.Trim(),k.safe_hint_type.PUNCTUATED);
        coned_offering.class_number = k.Safe(hnc_class_number[i.val].InnerText.Trim(),k.safe_hint_type.NUM);
        coned_offering.class_start_date = k.Safe(hnc_class_start_date[i.val].InnerText.Trim(),k.safe_hint_type.DATE_TIME);
        coned_offering.class_start_time = k.Safe(hnc_class_start_time[i.val].InnerText.Trim(),k.safe_hint_type.PUNCTUATED);
        coned_offering.class_end_date = k.Safe(hnc_class_end_date[i.val].InnerText.Trim(),k.safe_hint_type.DATE_TIME);
        coned_offering.class_end_time = k.Safe(hnc_class_end_time[i.val].InnerText.Trim(),k.safe_hint_type.PUNCTUATED);
        coned_offering.total_ceus = k.Safe(hnc_total_ceus[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
        coned_offering.fr_ce_trauma = k.Safe(hnc_fr_ce_trauma[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
        coned_offering.fr_ce_other = k.Safe(hnc_fr_ce_other[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
        coned_offering.fr_ce_total = k.Safe(hnc_fr_ce_total[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
        coned_offering.emt_ce_trauma = k.Safe(hnc_emt_ce_trauma[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
        coned_offering.emt_ce_other = k.Safe(hnc_emt_ce_other[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
        coned_offering.emt_ce_total = k.Safe(hnc_emt_ce_total[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
        //coned_offering.als_ce_total = k.Safe(hnc_als_ce_total[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
        //coned_offering.als_ce_trauma = k.Safe(hnc_als_ce_trauma[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
        //coned_offering.als_ce_other = k.Safe(hnc_als_ce_other[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
        coned_offering.tuition = k.Safe(hnc_tuition[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
        coned_offering.sponsor_name = k.Safe(hnc_sponsor_name[i.val].InnerText.Trim(),k.safe_hint_type.ORG_NAME);
        coned_offering.sponsor_number = k.Safe(hnc_sponsor_number[i.val].InnerText.Trim(),k.safe_hint_type.NUM);
        coned_offering.instructor_name = k.Safe(hnc_instructor_name[i.val].InnerText.Trim(),k.safe_hint_type.HUMAN_NAME_CSV);
        coned_offering.contact_name = k.Safe(hnc_contact_name[i.val].InnerText.Trim(),k.safe_hint_type.HUMAN_NAME);
        coned_offering.contact_name_1 = k.Safe(hnc_contact_name_1[i.val].InnerText.Trim(),k.safe_hint_type.HUMAN_NAME);
        coned_offering.location = k.Safe(hnc_location[i.val].InnerText.Trim(),k.safe_hint_type.ORG_NAME);
        coned_offering.class_location = k.Safe(hnc_class_location[i.val].InnerText.Trim(),k.safe_hint_type.POSTAL_STREET_ADDRESS);
        coned_offering.class_city_state = k.Safe(hnc_class_city_state[i.val].InnerText.Trim(),k.safe_hint_type.POSTAL_STREET_ADDRESS);
        coned_offering.class_county_code = k.Safe(hnc_class_county_code[i.val].InnerText.Trim(),k.safe_hint_type.NUM);
        coned_offering.class_region_code = k.Safe(hnc_class_region_code[i.val].InnerText.Trim(),k.safe_hint_type.NUM);
        //
        available_coned_classes_list.Add(coned_offering);
        }
      return available_coned_classes_list;
      }

    internal ArrayList ClassSearchScreen()
      {
      var class_search_screen = new ArrayList();
      var cookie_container = new CookieContainer();
      //
      Login(cookie_container);
      //
      HttpWebResponse response;
      if (!Request_ems_health_state_pa_us_EmsportalApplicationtransfersTransfertoconed(cookie_container,out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_EmsportalApplicationtransfersTransfertoconed() returned FALSE.");
        }
      if (!Request_ems_health_state_pa_us_ConedClasssearch(cookie_container,out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_ConedClasssearch() returned FALSE.");
        }
      if (!Request_ems_health_state_pa_us_ConedClasssearch_Coned_Searchnow(cookie_container,DateTime.Today.AddMonths(-2).ToString(),out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_ConedClasssearch_Coned_Searchnow() returned FALSE.");
        }
      //
      var hn_target_table = HtmlDocumentOf(ConsumedStreamOf(response)).DocumentNode.SelectSingleNode("html/body/font/center/table");
      //
      var hnc_start_date = hn_target_table.SelectNodes("tr/td[1]"); // This will also catch the horizontal line separator cells that occur every other row, so there'll be twice as many of these as of the rest.
      var hnc_course_title = hn_target_table.SelectNodes("tr/td[2]/table/tr[1]/td[2]/a");
      var hnc_course_number = hn_target_table.SelectNodes("tr/td[2]/table/tr[2]/td[2]");
      var hnc_fr_med_trauma_hours = hn_target_table.SelectNodes("tr/td[2]/table/tr[5]/td/table/tr[2]/td[4]");
      var hnc_fr_other_hours = hn_target_table.SelectNodes("tr/td[2]/table/tr[5]/td/table/tr[2]/td[5]");
      var hnc_emt_med_trauma_hours = hn_target_table.SelectNodes("tr/td[2]/table/tr[5]/td/table/tr[3]/td[4]");
      var hnc_emt_other_hours = hn_target_table.SelectNodes("tr/td[2]/table/tr[5]/td/table/tr[3]/td[5]");
      var hnc_emtp_med_trauma_hours = hn_target_table.SelectNodes("tr/td[2]/table/tr[5]/td/table/tr[4]/td[4]");
      var hnc_emtp_other_hours = hn_target_table.SelectNodes("tr/td[2]/table/tr[5]/td/table/tr[4]/td[5]");
      var hnc_phrn_med_trauma_hours = hn_target_table.SelectNodes("tr/td[2]/table/tr[5]/td/table/tr[5]/td[4]");
      var hnc_phrn_other_hours = hn_target_table.SelectNodes("tr/td[2]/table/tr[5]/td/table/tr[5]/td[5]");
      var hnc_length = hn_target_table.SelectNodes("tr/td[2]/table/tr[7]/td[2]");
      var hnc_closed = hn_target_table.SelectNodes("tr/td[2]/table/tr[8]/td[2]");
      var hnc_student_cost = hn_target_table.SelectNodes("tr/td[2]/table/tr[9]/td[2]");
      var hnc_class_number = hn_target_table.SelectNodes("tr/td[3]/table/tr[2]/td[2]/a");
      var hnc_sponsor_name = hn_target_table.SelectNodes("tr/td[3]/table/tr[4]/td[2]");
      var hnc_sponsor_id = hn_target_table.SelectNodes("tr/td[3]/table/tr[4]/td[2]/input");
      var hnc_region_council_name = hn_target_table.SelectNodes("tr/td[3]/table/tr[5]/td[2]");
      var hnc_region_council_num = hn_target_table.SelectNodes("tr/td[3]/table/tr[5]/td[2]/input");
      var hnc_class_county_name = hn_target_table.SelectNodes("tr/td[3]/table/tr[6]/td[2]");
      var hnc_location = hn_target_table.SelectNodes("tr/td[3]/table/tr[7]/td[2]");
      var hnc_public_contact_name = hn_target_table.SelectNodes("tr/td[3]/table/tr[9]/td[2]");
      var hnc_public_contact_phone = hn_target_table.SelectNodes("tr/td[3]/table/tr[10]/td[2]");
      //var hnc_public_contact_email = hn_target_table.SelectNodes("tr/td[3]/table/tr[11]/td[2]/a");
      var hnc_public_contact_website = hn_target_table.SelectNodes("tr/td[3]/table/tr[12]/td[2]");
      var hnc_public_contact_notes = hn_target_table.SelectNodes("tr/td[3]/table/tr[13]/td[2]");
      //
      for (var i = new k.subtype<int>(0,hnc_course_title.Count); i.val < i.LAST; i.val++)
        {
        var class_county_name = k.Safe(hnc_class_county_name[i.val].InnerText.Trim(),k.safe_hint_type.ALPHA);
        if (class_county_name != "OutofState")
          {
          var coned_offering = new ConedOffering();
          coned_offering.approved = "1";
          coned_offering.start_date_time = k.Safe(hnc_start_date[i.val*2].FirstChild.InnerText.Trim(),k.safe_hint_type.DATE_TIME);
          coned_offering.course_id = k.Safe(hnc_course_title[i.val].Attributes["href"].Value,k.safe_hint_type.NUM);
          coned_offering.course_title = k.Safe(hnc_course_title[i.val].InnerText.Trim(),k.safe_hint_type.PUNCTUATED);
          coned_offering.course_number = k.Safe(hnc_course_number[i.val].InnerText.Trim(),k.safe_hint_type.NUM);
          coned_offering.fr_med_trauma_hours = k.Safe(hnc_fr_med_trauma_hours[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
          coned_offering.fr_other_hours = k.Safe(hnc_fr_other_hours[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
          coned_offering.emt_med_trauma_hours = k.Safe(hnc_emt_med_trauma_hours[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
          coned_offering.emt_other_hours = k.Safe(hnc_emt_other_hours[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
          coned_offering.emtp_med_trauma_hours = k.Safe(hnc_emtp_med_trauma_hours[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
          coned_offering.emtp_other_hours = k.Safe(hnc_emtp_other_hours[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
          coned_offering.phrn_med_trauma_hours = k.Safe(hnc_phrn_med_trauma_hours[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
          coned_offering.phrn_other_hours = k.Safe(hnc_phrn_other_hours[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
          coned_offering.length = k.Safe(hnc_length[i.val].InnerText.Trim().Replace("&nbsp;hrs.",k.EMPTY),k.safe_hint_type.REAL_NUM);
          coned_offering.closed = k.Safe(hnc_closed[i.val].InnerText.Trim(),k.safe_hint_type.ALPHA);
          coned_offering.student_cost = k.Safe(hnc_student_cost[i.val].InnerText.Trim(),k.safe_hint_type.ALPHA);
          coned_offering.class_id_1 = k.Safe(hnc_class_number[i.val].Attributes["href"].Value,k.safe_hint_type.NUM);
          coned_offering.class_number = k.Safe(hnc_class_number[i.val].InnerText.Trim(),k.safe_hint_type.NUM);
          coned_offering.sponsor_name = k.Safe(hnc_sponsor_name[i.val].InnerText.Trim(),k.safe_hint_type.ORG_NAME);
          coned_offering.sponsor_id = k.Safe(hnc_sponsor_id[i.val].Attributes["value"].Value,k.safe_hint_type.NUM);
          coned_offering.region_council_name = k.Safe(hnc_region_council_name[i.val].InnerText.Trim(),k.safe_hint_type.ORG_NAME);
          coned_offering.region_council_num = k.Safe(hnc_region_council_num[i.val].Attributes["value"].Value,k.safe_hint_type.NUM);
          coned_offering.class_county_name = class_county_name.Replace("Northhampton","Northampton");
          coned_offering.location = k.Safe(hnc_location[i.val].FirstChild.InnerText.Trim(),k.safe_hint_type.POSTAL_STREET_ADDRESS);
          coned_offering.public_contact_name = k.Safe(hnc_public_contact_name[i.val].InnerText.Trim(),k.safe_hint_type.HUMAN_NAME);
          coned_offering.public_contact_phone = k.Safe(hnc_public_contact_phone[i.val].InnerText.Trim(),k.safe_hint_type.PHONE_NUM);
          //coned_offering.public_contact_email = k.Safe(hnc_public_contact_email[i.val].InnerText.Trim(),k.safe_hint_type.EMAIL_ADDRESS);
          coned_offering.public_contact_website = k.Safe(hnc_public_contact_website[i.val].InnerText.Trim(),k.safe_hint_type.HTTP_TARGET);
          coned_offering.public_contact_notes = k.Safe(hnc_public_contact_notes[i.val].InnerText.Trim(),k.safe_hint_type.PUNCTUATED);
          class_search_screen.Add(coned_offering);
          }
        }
      return class_search_screen;
      }

    internal ArrayList ClassSearchTabDelimited()
      {
      var class_search_tab_delimited = new ArrayList();
      var cookie_container = new CookieContainer();
      //
      Login(cookie_container);
      //
      HttpWebResponse response;
      if (!Request_ems_health_state_pa_us_EmsportalApplicationtransfersTransfertoconed(cookie_container,out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_EmsportalApplicationtransfersTransfertoconed() returned FALSE.");
        }
      if (!Request_ems_health_state_pa_us_ConedClasssearch(cookie_container,out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_ConedClasssearch() returned FALSE.");
        }
      if (!Request_ems_health_state_pa_us_ConedClasssearch_Coned_Filedelimited_Searchnow(cookie_container,DateTime.Today.AddMonths(-2).ToString(),out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_ConedClasssearch_Coned_Filedelimited_Searchnow() returned FALSE.");
        }
      var dn = HtmlDocumentOf(ConsumedStreamOf(response)).DocumentNode;
      if(!Request_ems_health_state_pa_us_ConedExportClasssearchtxt
          (
          cookie_container,
          k.Safe
            (
            dn.SelectSingleNode("/html/body/font[2]/a[1]").Attributes["href"].Value.Replace("Export/ClassSearch_",k.EMPTY).Replace(".txt",k.EMPTY),
            k.safe_hint_type.NUM
            ),
          out response
          )
        )
        {
        throw new Exception("Request_ems_health_state_pa_us_ConedExportClasssearchtxt() returned FALSE.");
        }
      var stream_reader = new StreamReader(response.GetResponseStream());
      stream_reader.ReadLine();  //Discard the first line.  It only contains column headings.
      while (!stream_reader.EndOfStream)
        {
        var field_array = stream_reader.ReadLine().Split(new string[] {k.TAB},StringSplitOptions.None);
        var course_title = k.Safe(field_array[77],k.safe_hint_type.PUNCTUATED);
        if (course_title.Trim().Length > 0)
          {
          var coned_offering = new ConedOffering();
          coned_offering.class_id_1 = k.Safe(field_array[0],k.safe_hint_type.NUM);
          coned_offering.class_type = k.Safe(field_array[1],k.safe_hint_type.ALPHA);
          coned_offering.course_id = k.Safe(field_array[2],k.safe_hint_type.NUM);
          coned_offering.class_number = k.Safe(field_array[3],k.safe_hint_type.NUM);
          coned_offering.course_code = k.Safe(field_array[4],k.safe_hint_type.NUM);
          coned_offering.created_by = k.Safe(field_array[5],k.safe_hint_type.NUM);
          coned_offering.date_created = k.Safe(field_array[6],k.safe_hint_type.DATE_TIME);
          coned_offering.last_edited_by = k.Safe(field_array[7],k.safe_hint_type.NUM);
          coned_offering.date_last_edited = k.Safe(field_array[8],k.safe_hint_type.DATE_TIME);
          coned_offering.sponsor_id = k.Safe(field_array[9],k.safe_hint_type.NUM);
          coned_offering.sponsor_number = k.Safe(field_array[10],k.safe_hint_type.HYPHENATED_NUM);
          coned_offering.training_ins_accred_num = k.Safe(field_array[11],k.safe_hint_type.NUM);
          coned_offering.document_status = k.Safe(field_array[12],k.safe_hint_type.ALPHA);
          coned_offering.class_final_status = k.Safe(field_array[13],k.safe_hint_type.ALPHA);
          coned_offering.course_number = k.Safe(field_array[14],k.safe_hint_type.NUM);
          coned_offering.location = k.Safe(field_array[15],k.safe_hint_type.POSTAL_STREET_ADDRESS);
          coned_offering.student_cost = k.Safe(field_array[16],k.safe_hint_type.CURRENCY_USA);
          coned_offering.tuition_includes = k.Safe(field_array[17],k.safe_hint_type.PUNCTUATED);
          coned_offering.closed = k.Safe(field_array[18],k.safe_hint_type.ALPHA);
          coned_offering.estimated_students = k.Safe(field_array[19],k.safe_hint_type.NUM);
          coned_offering.start_date_time = k.Safe(field_array[20],k.safe_hint_type.DATE_TIME);
          coned_offering.end_date_time = k.Safe(field_array[21],k.safe_hint_type.DATE_TIME);
          coned_offering.start_time = k.Safe(field_array[22],k.safe_hint_type.PUNCTUATED);
          coned_offering.end_time = k.Safe(field_array[23],k.safe_hint_type.PUNCTUATED);
          coned_offering.other_dates_and_times = k.Safe(field_array[24],k.safe_hint_type.PUNCTUATED);
          coned_offering.instructors = k.Safe(field_array[25],k.safe_hint_type.PUNCTUATED);
          coned_offering.instructor_qualifications = k.Safe(field_array[26],k.safe_hint_type.PUNCTUATED);
          coned_offering.verification_name = k.Safe(field_array[27],k.safe_hint_type.HUMAN_NAME);
          coned_offering.contact_name = k.Safe(field_array[28],k.safe_hint_type.HUMAN_NAME);
          coned_offering.contact_address_1 = k.Safe(field_array[29],k.safe_hint_type.POSTAL_STREET_ADDRESS);
          coned_offering.contact_address_2 = k.Safe(field_array[30],k.safe_hint_type.POSTAL_STREET_ADDRESS);
          coned_offering.contact_city = k.Safe(field_array[31],k.safe_hint_type.POSTAL_CITY);
          coned_offering.contact_state = k.Safe(field_array[32],k.safe_hint_type.ALPHA);
          coned_offering.contact_zip = k.Safe(field_array[33],k.safe_hint_type.NUM);
          coned_offering.contact_daytime_phone = k.Safe(field_array[34],k.safe_hint_type.PHONE_NUM);
          coned_offering.contact_evening_phone = k.Safe(field_array[35],k.safe_hint_type.PHONE_NUM);
          coned_offering.contact_email = k.Safe(field_array[36],k.safe_hint_type.EMAIL_ADDRESS);
          coned_offering.public_contact_name = k.Safe(field_array[37],k.safe_hint_type.HUMAN_NAME);
          coned_offering.public_contact_phone = k.Safe(field_array[38],k.safe_hint_type.PHONE_NUM);
          coned_offering.public_contact_email = k.Safe(field_array[39],k.safe_hint_type.EMAIL_ADDRESS);
          coned_offering.public_contact_website = k.Safe(field_array[40],k.safe_hint_type.HTTP_TARGET);
          coned_offering.public_contact_notes = k.Safe(field_array[41],k.safe_hint_type.PUNCTUATED);
          coned_offering.date_submitted_to_region = k.Safe(field_array[42],k.safe_hint_type.DATE_TIME);
          coned_offering.date_received_by_region = k.Safe(field_array[43],k.safe_hint_type.DATE_TIME);
          coned_offering.date_sponsor_notified = k.Safe(field_array[44],k.safe_hint_type.DATE_TIME);
          coned_offering.date_registration_sent_to_state = k.Safe(field_array[45],k.safe_hint_type.DATE_TIME);
          coned_offering.date_cards_sent_to_sponsor = k.Safe(field_array[46],k.safe_hint_type.DATE_TIME);
          coned_offering.date_materials_to_be_returned = k.Safe(field_array[47],k.safe_hint_type.DATE_TIME);
          coned_offering.approved = k.Safe(field_array[48],k.safe_hint_type.NUM);
          coned_offering.region_comments = k.Safe(field_array[49],k.safe_hint_type.PUNCTUATED);
          coned_offering.region_council_num = k.Safe(field_array[50],k.safe_hint_type.NUM);
          coned_offering.class_county_code = k.Safe(field_array[51],k.safe_hint_type.NUM);
          coned_offering.total_class_hours = k.Safe(field_array[52],k.safe_hint_type.REAL_NUM);
          coned_offering.location_address_1 = k.Safe(field_array[53],k.safe_hint_type.POSTAL_STREET_ADDRESS);
          coned_offering.location_address_2 = k.Safe(field_array[54],k.safe_hint_type.POSTAL_STREET_ADDRESS);
          coned_offering.location_city = k.Safe(field_array[55],k.safe_hint_type.POSTAL_CITY);
          coned_offering.location_state = k.Safe(field_array[56],k.safe_hint_type.ALPHA);
          coned_offering.location_zip = k.Safe(field_array[57],k.safe_hint_type.NUM);
          coned_offering.location_zip_plus_4 = k.Safe(field_array[58],k.safe_hint_type.NUM);
          coned_offering.location_phone = k.Safe(field_array[59],k.safe_hint_type.PHONE_NUM);
          coned_offering.location_email = k.Safe(field_array[60],k.safe_hint_type.EMAIL_ADDRESS);
          coned_offering.location_of_registration = k.Safe(field_array[61],k.safe_hint_type.PUNCTUATED);
          coned_offering.primary_text = k.Safe(field_array[62],k.safe_hint_type.PUNCTUATED);
          coned_offering.additional_texts = k.Safe(field_array[63],k.safe_hint_type.NUM);
          coned_offering.final_registration_date = k.Safe(field_array[64],k.safe_hint_type.DATE_TIME);
          coned_offering.offered_as_college_credit = k.Safe(field_array[65],k.safe_hint_type.ALPHA);
          coned_offering.practical_exam_date = k.Safe(field_array[66],k.safe_hint_type.DATE_TIME);
          coned_offering.written_exam_date = k.Safe(field_array[67],k.safe_hint_type.DATE_TIME);
          coned_offering.disapproval_reason_id = k.Safe(field_array[68],k.safe_hint_type.NUM);
          coned_offering.date_final_paperwork_received = k.Safe(field_array[69],k.safe_hint_type.DATE_TIME);
          coned_offering.signed_hard_copy = k.Safe(field_array[70],k.safe_hint_type.ALPHA);
          coned_offering.created_by_first_name = k.Safe(field_array[71],k.safe_hint_type.HUMAN_NAME);
          coned_offering.created_by_last_name = k.Safe(field_array[72],k.safe_hint_type.HUMAN_NAME);
          coned_offering.class_disapproval_reason_description = k.Safe(field_array[73],k.safe_hint_type.PUNCTUATED);
          coned_offering.class_final_status_description = k.Safe(field_array[74],k.safe_hint_type.ALPHA_WORDS);
          coned_offering.sponsor_name = k.Safe(field_array[75],k.safe_hint_type.ORG_NAME);
          coned_offering.courses_course_number = k.Safe(field_array[76],k.safe_hint_type.NUM);
          coned_offering.course_title = course_title;
          coned_offering.cert_course_code = k.Safe(field_array[78],k.safe_hint_type.NUM);
          coned_offering.cert_course_description = k.Safe(field_array[79],k.safe_hint_type.NUM);
          coned_offering.class_id_2 = k.Safe(field_array[80],k.safe_hint_type.NUM);
          class_search_tab_delimited.Add(coned_offering);
          }
        }
      stream_reader.Close();
      return class_search_tab_delimited;
      }

    internal class TeachingEntity
      {
      internal string id = k.EMPTY;
      internal string date_created = k.EMPTY;
      internal string date_last_edited = k.EMPTY;
      internal string sponsor_number = k.EMPTY;
      internal string training_ins_accred_num = k.EMPTY;
      internal string name = k.EMPTY;
      internal string short_name = k.EMPTY;
      internal string address_1 = k.EMPTY;
      internal string address_2 = k.EMPTY;
      internal string city = k.EMPTY;
      internal string state = k.EMPTY;
      internal string zip = k.EMPTY;
      internal string county_code = k.EMPTY;
      internal string region = k.EMPTY;
      internal string email = k.EMPTY;
      internal string website = k.EMPTY;
      internal string daytime_phone = k.EMPTY;
      internal string evening_phone = k.EMPTY;
      internal string fax = k.EMPTY;
      internal string business_type_id = k.EMPTY;
      internal string con_ed_level = k.EMPTY;
      internal string certification_level = k.EMPTY;
      internal string contact_prefix = k.EMPTY;
      internal string contact_first_name = k.EMPTY;
      internal string contact_last_name = k.EMPTY;
      internal string contact_suffix = k.EMPTY;
      internal string contact_title = k.EMPTY;
      internal string contact_address_1 = k.EMPTY;
      internal string contact_address_2 = k.EMPTY;
      internal string contact_city = k.EMPTY;
      internal string contact_state = k.EMPTY;
      internal string contact_zip = k.EMPTY;
      internal string contact_daytime_phone = k.EMPTY;
      internal string contact_evening_phone = k.EMPTY;
      internal string contact_fax = k.EMPTY;
      internal string contact_email = k.EMPTY;
      internal string public_contact_name = k.EMPTY;
      internal string public_contact_phone = k.EMPTY;
      internal string public_contact_email = k.EMPTY;
      internal string public_contact_website = k.EMPTY;
      internal string public_contact_notes = k.EMPTY;
      internal string application_date = k.EMPTY;
      internal string application_received = k.EMPTY;
      internal string sponsor_status = k.EMPTY;
      internal string sponsor_status_description = k.EMPTY;
      internal string training_inst_status = k.EMPTY;
      internal string training_inst_status_description = k.EMPTY;
      internal string issue_date = k.EMPTY;
      internal string prev_expiration_date = k.EMPTY;
      internal string expiration_date_sponsor = k.EMPTY;
      internal string expiration_date_training_inst = k.EMPTY;
      internal string process_date = k.EMPTY;
      internal string corrective_action = k.EMPTY;
      internal string compliance_by_date = k.EMPTY;
      internal string initial_accred_date = k.EMPTY;
      internal string accepted_provisional_date = k.EMPTY;
      internal string completed_provisional_date = k.EMPTY;
      internal string withdrawal_challenge_due_date = k.EMPTY;
      internal string letter_for_expiration = k.EMPTY;
      internal string letter_f_for_ppwk_non_compliance = k.EMPTY;
      internal string other_letter = k.EMPTY;
      internal string history = k.EMPTY;
      internal string business_type_description = k.EMPTY;
      internal string county_name = k.EMPTY;
      }
    internal ArrayList TeachingEntitySearch()
      {
      var teaching_entity_search = new ArrayList();
      //
      HttpWebResponse response;
      var cookie_container = new CookieContainer();
      if (Request_ems_health_state_pa_us_ConedSponsorsearch_StatusSearchnow(cookie_container,"S1",out response))
        {
        ScrapeConedSponsors("Approved",teaching_entity_search,response);
        }
      if (Request_ems_health_state_pa_us_ConedSponsorsearch_StatusSearchnow(cookie_container,"S3",out response))
        {
        ScrapeConedSponsors("Provisional",teaching_entity_search,response);
        }
      return teaching_entity_search;
      }

    internal class Practitioner
      {
      internal string last_name = k.EMPTY;
      internal string first_name = k.EMPTY;
      internal string middle_initial = k.EMPTY;
      internal string certification_number = k.EMPTY;
      internal string level = k.EMPTY;
      internal string regional_council = k.EMPTY;
      }
    internal class ActivePractitionersContext
      {
      internal CookieContainer cookie_container = null;
      internal string view_state = k.EMPTY;
      internal string event_validation = k.EMPTY;
      internal string next_page_ctl_num = k.EMPTY;
      internal k.int_sign_range disposition = null;
      //
      public ActivePractitionersContext()
        {
        HttpWebResponse response;
        cookie_container = new CookieContainer();
        disposition = new k.int_sign_range();
        Request_ems_health_state_pa_us_EmsregActivepractitioners(cookie_container,out response);
        var html_document = HtmlDocumentOf(ConsumedStreamOf(response));
        view_state = ViewstateOf(html_document);
        event_validation = EventValidationOf(html_document);
        }
      }
    internal ArrayList ActivePractitioners
      (
      ActivePractitionersContext context
      )
      {
      var active_practitioners = new ArrayList();
      //
      HttpWebResponse response;
      if (Request_ems_health_state_pa_us_EmsregActivepractitioners_3000(context.cookie_container,context.view_state,context.event_validation,context.next_page_ctl_num,out response))
        {
        var html_document = HtmlDocumentOf(ConsumedStreamOf(response));
        //
        // The initial XPaths are determined by visiting the page in IE9, selecting "F12 developer tools", setting Document Mode to IE9 Standards, navigating to the node of interest, and disregarding any form or tbody tags.
        //
        var hn_target_table = html_document.GetElementbyId("_ctl0__ctl0_SessionLinkBar_Content_dgActivePractitioners"); 
        //
        var hnc_last_name = hn_target_table.SelectNodes("tr/td[1]/span");
        var hnc_first_name = hn_target_table.SelectNodes("tr/td[2]/span");
        var hnc_middle_initial = hn_target_table.SelectNodes("tr/td[3]/span");
        var hnc_certification_number = hn_target_table.SelectNodes("tr/td[4]/span");
        var hnc_level = hn_target_table.SelectNodes("tr/td[5]/span");
        var hnc_regional_council = hn_target_table.SelectNodes("tr/td[6]/span");
        //
        for (var i = new k.subtype<int>(1,hnc_last_name.Count - 1); i.val < i.LAST; i.val++)  //limits take into account non-data header & page index rows
          {
          var practitioner = new Practitioner();
          practitioner.last_name = k.Safe(hnc_last_name[i.val].InnerText.Trim(),k.safe_hint_type.HUMAN_NAME);
          practitioner.first_name = k.Safe(hnc_first_name[i.val].InnerText.Trim(),k.safe_hint_type.HUMAN_NAME);
          practitioner.middle_initial = k.Safe(hnc_middle_initial[i.val].InnerText.Trim(),k.safe_hint_type.HUMAN_NAME);
          practitioner.certification_number = k.Safe(hnc_certification_number[i.val].InnerText.Trim(),k.safe_hint_type.NUM);
          practitioner.level = k.Safe(hnc_level[i.val].InnerText.Trim(),k.safe_hint_type.HUMAN_NAME);
          practitioner.regional_council = k.Safe(hnc_regional_council[i.val].InnerText.Trim(),k.safe_hint_type.ORG_NAME);
          active_practitioners.Add(practitioner);
          }
        //
        context.view_state = html_document.GetElementbyId("__VIEWSTATE").Attributes["value"].Value;
        context.event_validation = html_document.GetElementbyId("__EVENTVALIDATION").Attributes["value"].Value;
        //
        var hn_current_page_num_node_next_sibling = hnc_last_name[hnc_last_name.Count - 1].NextSibling;
        if (hn_current_page_num_node_next_sibling == null)
          {
          context.disposition.val = 1;
          }
        else
          {
          context.next_page_ctl_num = hn_current_page_num_node_next_sibling.NextSibling.Attributes["href"].Value
            .Replace("javascript:__doPostBack(&#39;_ctl0$_ctl0$SessionLinkBar$Content$dgActivePractitioners$_ctl3004$_ctl",k.EMPTY)
            .Replace("&#39;,&#39;&#39;)",k.EMPTY);
          context.disposition.val = 0;
          }
        }
      return active_practitioners;
      }

    }
  }
