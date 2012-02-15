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

		    string postString = @"SearchMode=&cmdMove=Search+Now&ClassType=CONED&CourseNumber=&CourseTitle=&CourseCode=&StartDate_Low=&StartDate_High=&ClassCountyCode=&RegionCouncilNum=&ClassNumber=&IncludeDisapprovedClasses=0&OutputFormat=FileDelimited";
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

		    string postString = @"SearchMode=&cmdMove=Search+Now&ClassType=CONED&CourseNumber=&CourseTitle=&CourseCode=&StartDate_Low=&StartDate_High=&ClassCountyCode=&RegionCouncilNum=&ClassNumber=&IncludeDisapprovedClasses=0&OutputFormat=Screen";
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
      out HttpWebResponse response
      )
    {
	    response = null;

	    try
	    {
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ems.health.state.pa.us/ConEd/Export/ClassSearch_345.txt");
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
      internal string course_number = k.EMPTY;
      internal string course_title = k.EMPTY;
      internal string class_number = k.EMPTY;
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
      internal string sponsor_name = k.EMPTY;
      internal string sponsor_number = k.EMPTY;
      internal string instructor_name = k.EMPTY;
      internal string contact_name = k.EMPTY;
      internal string contact_name_1 = k.EMPTY;
      internal string location = k.EMPTY;
      internal string class_location = k.EMPTY;
      internal string class_city_state = k.EMPTY;
      internal string class_county_code = k.EMPTY;
      internal string class_region_code = k.EMPTY;
      }
    internal ArrayList AvailableConedClassesList()
      {
      var class_search_unlimited = new ArrayList();
      //
      var cookie_container = new CookieContainer();
      var stream_string = k.EMPTY;
      var html_document = new HtmlDocument();
      HttpWebResponse response;
      //
      if (!Request_ems_health_state_pa_us_Emsportal(cookie_container,out response))
        {
        throw new Exception("Request_ems_health_state_pa_us_Emsportal() returned FALSE.");
        }
      else
        {
        html_document = HtmlDocumentOf(ConsumedStreamOf(response));
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
        else
          {
          stream_string = ConsumedStreamOf(response);
          if (!Request_ems_health_state_pa_us_EmsportalApplicationlist(cookie_container,out response))
            {
            throw new Exception("Request_ems_health_state_pa_us_EmsportalApplicationlist() returned FALSE.");
            }
          else
            {
            stream_string = ConsumedStreamOf(response);
            if (!Request_ems_health_state_pa_us_EmsportalApplicationtransfersTransfertoemsreg(cookie_container,out response))
              {
              throw new Exception("Request_ems_health_state_pa_us_EmsportalApplicationtransfersTransfertoemsreg() returned FALSE.");
              }
            else
              {
              stream_string = ConsumedStreamOf(response);
              if (!Request_ems_health_state_pa_us_EmsregDefault(cookie_container,out response))
                {
                throw new Exception("Request_ems_health_state_pa_us_EmsregDefault() returned FALSE.");
                }
              else
                {
                stream_string = ConsumedStreamOf(response);
                if (!Request_ems_health_state_pa_us_EmsregPractitionerHome(cookie_container,out response))
                  {
                  throw new Exception("Request_ems_health_state_pa_us_EmsregPractitionerHome() returned FALSE.");
                  }
                else
                  {
                  stream_string = ConsumedStreamOf(response);
                  if (!Request_ems_health_state_pa_us_EmsregReportsReportlist(cookie_container,out response))
                    {
                    throw new Exception("Request_ems_health_state_pa_us_EmsregReportsReportlist() returned FALSE.");
                    }
                  else
                    {
                    stream_string = ConsumedStreamOf(response);
                    if (!Request_ems_health_state_pa_us_EmsregReportsAvailablececlasseslistsearch(cookie_container,out response))
                      {
                      throw new Exception("Request_ems_health_state_pa_us_EmsregReportsAvailablececlasseslistsearch() returned FALSE.");
                      }
                    else
                      {
                      html_document = HtmlDocumentOf(ConsumedStreamOf(response));
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
                      else
                        {
                        stream_string = ConsumedStreamOf(response).Replace("&nbsp;",k.EMPTY);
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
                        var hnc_als_ce_total = hn_target_table.SelectNodes("tr/td[15]");
                        var hnc_als_ce_other = hn_target_table.SelectNodes("tr/td[16]");
                        var hnc_als_ce_trauma = hn_target_table.SelectNodes("tr/td[17]");
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
                          coned_offering.als_ce_total = k.Safe(hnc_als_ce_total[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
                          coned_offering.als_ce_trauma = k.Safe(hnc_als_ce_trauma[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
                          coned_offering.als_ce_other = k.Safe(hnc_als_ce_other[i.val].InnerText.Trim(),k.safe_hint_type.REAL_NUM);
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
                          class_search_unlimited.Add(coned_offering);
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      return class_search_unlimited;
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
