using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.Net.Json;
using Newtonsoft.Json;
using ShipStation.Entities;

namespace ShipStation.Api
{
    public class ShipStation
    {
        public static string ApiResult(string _url, string _method, string _postData)
        {

            string responseText = string.Empty;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_url);
            webRequest.Method = _method;
            webRequest.Timeout = 30 * 1000; // 30초
                                            // ContentType은 지정된 것이 있으면 그것을 사용해준다.
            webRequest.ContentType = "application/json; charset=utf-8";

            /* _postData 변수에 api request body 초기화*//*
            byte[] byteArray = Encoding.UTF8.GetBytes(_postData);
            // 요청 Data를 쓰는 데 사용할 Stream 개체를 가져온다.
            Stream dataStream = webRequest.GetRequestStream();
            // Data를 전송한다.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // dataStream 개체 닫기
            dataStream.Close();*/
            
            return _postData;

            try
            {
                // 응답 받기
                using (HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse())
                {
                    HttpStatusCode status = resp.StatusCode;
                    Console.WriteLine(status);      // status 가 정상일경우 OK가 입력된다.

                    // 응답과 관련된 stream을 가져온다.
                    Stream respStream = resp.GetResponseStream();
                    using (StreamReader streamReader = new StreamReader(respStream))
                    {
                        responseText = streamReader.ReadToEnd();
                    }
                }

                Console.WriteLine(responseText);
            }
            catch (WebException ex1)
            {
                string error_str = ex1.Message;

                if (ex1.Status == WebExceptionStatus.ProtocolError)
                {

                    using (Stream data = ex1.Response.GetResponseStream())
                    //using (GZipStream gzip = new GZipStream(data, CompressionMode.Compress))
                    using (var reader = new StreamReader(data, Encoding.UTF8))
                    {
                        string text = reader.ReadToEnd();
                        error_str = text;
                    }
                }
                //return "";
            }
            catch (Exception ex2)
            {
                string error_str = ex2.Message;
                //return "";
            }
        }
    }

    public class RegisterAccount
    {
        public static AccountResponse AcReq(AccountRequest _accountsReq)
        {
            string url = "https://ssapi.shipstation.com/accounts/registeraccount";

            JsonObjectCollection main = new JsonObjectCollection
            /* JsonArrayCollection accountReq = new JsonArrayCollection("AccountRequest");
            JsonObjectCollection items = new JsonObjectCollection */
            {
                new JsonStringValue("FirstName", _accountsReq.FirstName),
                new JsonStringValue("LastName", _accountsReq.LastName),
                new JsonStringValue("Email", _accountsReq.Email),
                new JsonStringValue("Password", _accountsReq.Password),
                new JsonStringValue("ShippingOriginCountryCode", _accountsReq.ShippingOriginCountryCode),
                new JsonStringValue("CompanyName", _accountsReq.CompanyName),
                new JsonStringValue("Addr1", _accountsReq.Addr1),
                new JsonStringValue("Addr2", _accountsReq.Addr2),
                new JsonStringValue("City", _accountsReq.City),
                new JsonStringValue("State", _accountsReq.State),
                new JsonStringValue("Zip", _accountsReq.Zip),
                new JsonStringValue("CountryCode", _accountsReq.CountryCode),
                new JsonStringValue("Phone", _accountsReq.Phone)
            };

            // accountReq.Add(items);
            // main.Add(jsonArrayCollection);

            string _jsonData = main.ToString();
            _jsonData = _jsonData.Replace("\n", "");
            _jsonData = _jsonData.Replace("\r", "");
            _jsonData = _jsonData.Replace("\t", "");

            /*getApi() 호출, getApi() return 후 해당 값으로 Res() 호출*/

            string reqResult = ShipStation.ApiResult(url, "POST", _jsonData);

            /* method : AcReq(), AcRes() 합치기 */
            // 모델 형식으로 값 입력
            AccountResponse accountsRes = new AccountResponse(
                _message: "ShipStation account Created.",
                _sellerId: 123456,
                _success: true,
                _apiKey: "abcdt9845hjmgfklj3498gkljdkuyekl",
                _apiSecret: "1234iou983lkj8mnxgfwu509hkhdy7u3");

            /* { Message = "ShipStation account created.",
            SellerId = 123456,
            Success = true,
            ApiKey = "abcdt9845hjmgfklj3498gkljdkuyekl",
            ApiSecret = "1234iou983lkj8mnxgfwu509hkhdy7u3" } */

            string resJsonData = JsonConvert.SerializeObject(accountsRes);

            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(resJsonData);
            JsonObjectCollection col = (JsonObjectCollection)obj;

            try
            {
                /* 차이점 뭐지? 
                 차이점..? : JsonObjectCollection parse 사용 vs model 형식 사용 ?*/

                Console.WriteLine(col["Message"].GetValue());
                Console.WriteLine(col["SellerId"].GetValue());
                Console.WriteLine(col["Success"].GetValue());
                Console.WriteLine(col["ApiKey"].GetValue());
                Console.WriteLine(col["ApiSecret"].GetValue());

                /* Console.WriteLine(accountRes.Message);
                Console.WriteLine(accountRes.SellerId);
                Console.WriteLine(accountRes.Success);
                Console.WriteLine(accountRes.ApiKey);
                Console.WriteLine(accountRes.ApiSecret); */
            }
            catch (NullReferenceException ex1) { Console.WriteLine(ex1.Message); }

            return accountsRes;
        }
    }

    public class ListFulfillments
    {
        public static FulfillmentResponse LfReq(FulfillmentRequest _fulfillmentsReq)
        {
            string url = "https://ssapi.shipstation.com/fulfillments";

            JsonObjectCollection reqMain = new JsonObjectCollection
            /* JsonArrayCollection accountReq = new JsonArrayCollection("AccountRequest");
            JsonObjectCollection items = new JsonObjectCollection */
            {
                new JsonStringValue("FulfillmentId", _fulfillmentsReq.FulfillmentId.ToString()),
                new JsonStringValue("OrderId", _fulfillmentsReq.OrderId.ToString()),
                new JsonStringValue("OrderNumber", _fulfillmentsReq.OrderNumber),
                new JsonStringValue("TrackingNumber", _fulfillmentsReq.TrackingNumber),
                new JsonStringValue("RecipientName", _fulfillmentsReq.RecipientName),
                new JsonStringValue("CreateDateStart", _fulfillmentsReq.CreateDateStart.ToString()),
                new JsonStringValue("CreateDateEnd", _fulfillmentsReq.CreateDateEnd.ToString()),
                new JsonStringValue("ShipDateStart", _fulfillmentsReq.ShipDateStart.ToString()),
                new JsonStringValue("ShipDateEnd", _fulfillmentsReq.ShipDateEnd.ToString()),
                new JsonStringValue("SortBy", _fulfillmentsReq.SortBy),
                new JsonStringValue("SortDir", _fulfillmentsReq.SortDir),
                new JsonStringValue("Page", _fulfillmentsReq.Page.ToString()),
                new JsonStringValue("PageSize", _fulfillmentsReq.PageSize.ToString())
            };

            // accountReq.Add(items);
            // main.Add(jsonArrayCollection);

            string _jsonData = reqMain.ToString();
            _jsonData = _jsonData.Replace("\n", "");
            _jsonData = _jsonData.Replace("\r", "");
            _jsonData = _jsonData.Replace("\t", "");

            /*getApi() 호출, getApi() return 후 해당 값으로 Res() 호출*/

            string reqResult = ShipStation.ApiResult(url, "GET", _jsonData);

            // response
            JsonObjectCollection resMain = new JsonObjectCollection();
            JsonArrayCollection fulfillmentsArray = new JsonArrayCollection("fulfillments");
            JsonObjectCollection item = new JsonObjectCollection
            {
                new JsonStringValue("FulfillmentId", _fulfillmentsReq.FulfillmentId.ToString()),
                new JsonStringValue("OrderNumber", _fulfillmentsReq.OrderNumber.ToString()),
                new JsonStringValue("CreateDate", _fulfillmentsReq.CreateDateStart.ToString()),
                // new JsonStringValue("FulfillmentFee", _fulfillmentsReq.fulfillmentFee.ToString())
            };

            fulfillmentsArray.Add(item);
            resMain.Add(fulfillmentsArray);

            /* _jsonData = resMain.ToString();
            _jsonData = _jsonData.Replace("\n", "");
            _jsonData = _jsonData.Replace("\r", "");
            _jsonData = _jsonData.Replace("\t", "");

            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(_jsonData);
            JsonObjectCollection col = (JsonObjectCollection)obj;

            Console.WriteLine(col["FulfillmentId"].GetValue()); */

            FulfillmentResponse fulfillmentsRes = new FulfillmentResponse(item);

            return fulfillmentsRes;
        }
    }
}
