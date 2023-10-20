using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.Net.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShipStation.Entities;
using ShipStation.Models;

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
                new JsonStringValue("SortBy", _fulfillmentsReq.SortBy.ToString()),
                new JsonStringValue("SortDir", _fulfillmentsReq.SortDir.ToString()),
                new JsonStringValue("Page", _fulfillmentsReq.Page.ToString()),
                new JsonStringValue("PageSize", _fulfillmentsReq.PageSize.ToString())
            };

            // accountReq.Add(items);
            // main.Add(jsonArrayCollection);

            string reqJson = reqMain.ToString();
            reqJson = reqJson.Replace("\n", "");
            reqJson = reqJson.Replace("\r", "");
            reqJson = reqJson.Replace("\t", "");
            /*getApi() 호출, getApi() return 후 해당 값으로 Res() 호출*/

            string reqResult = ShipStation.ApiResult(url, "GET", reqJson);

            /*// response
            JsonObjectCollection resMain = new JsonObjectCollection();
            JsonArrayCollection fulfillmentsArray = new JsonArrayCollection("fulfillments");
            JsonObjectCollection item = new JsonObjectCollection
            {
                new JsonStringValue("FulfillmentId", _fulfillmentsReq.FulfillmentId.ToString()),
                new JsonStringValue("OrderNumber", _fulfillmentsReq.OrderNumber.ToString()),
                new JsonStringValue("CreateDate", _fulfillmentsReq.CreateDateStart.ToString()),
            };

            fulfillmentsArray.Add(item);
            resMain.Add(fulfillmentsArray);

            string resJson = resMain.ToString();
            resJson = resJson.Replace("\n", "");
            resJson = resJson.Replace("\r", "");
            resJson = resJson.Replace("\t", "");

            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(resJson);
            JsonObjectCollection col = (JsonObjectCollection)obj;

            FulfillmentResponse fulfillmentsRes = new FulfillmentResponse(item);*/

            string resJson = "{\r\n  \"fulfillments\": [\r\n    {\r\n      \"fulfillmentId\": 33974374,\r\n      \"orderId\": 191759016,\r\n      \"orderNumber\": \"101\",\r\n      \"userId\": \"c9f06d74-95de-4263-9b04-e87095cababf\",\r\n      \"customerEmail\": \"apisupport@shipstation.com\",\r\n      \"trackingNumber\": \"783408231234\",\r\n      \"createDate\": \"2016-06-07T08:50:50.0670000\",\r\n      \"shipDate\": \"2016-06-07T00:00:00.0000000\",\r\n      \"voidDate\": null,\r\n      \"deliveryDate\": null,\r\n      \"carrierCode\": \"USPS\",\r\n      \"fulfillmentProviderCode\": null,\r\n      \"fulfillmentServiceCode\": null,\r\n      \"fulfillmentFee\": 0,\r\n      \"voidRequested\": false,\r\n      \"voided\": false,\r\n      \"marketplaceNotified\": true,\r\n      \"notifyErrorMessage\": null,\r\n      \"shipTo\": {\r\n        \"name\": \"Yoda\",\r\n        \"company\": null,\r\n        \"street1\": \"3800 N Lamar Blvd # 220\",\r\n        \"street2\": null,\r\n        \"street3\": null,\r\n        \"city\": \"AUSTIN\",\r\n        \"state\": \"TX\",\r\n        \"postalCode\": \"78756\",\r\n        \"country\": \"US\",\r\n        \"phone\": \"512-485-4282\",\r\n        \"residential\": null,\r\n        \"addressVerified\": null\r\n      }\r\n    },\r\n    {\r\n      \"fulfillmentId\": 246310,\r\n      \"orderId\": 193699927,\r\n      \"orderNumber\": \"101\",\r\n      \"userId\": \"c9f06d74-95de-4263-9b04-e87095cababf\",\r\n      \"customerEmail\": \"apisupport@shipstation.com\",\r\n      \"trackingNumber\": \"664756278745\",\r\n      \"createDate\": \"2016-06-08T12:54:53.3470000\",\r\n      \"shipDate\": \"2016-06-08T00:00:00.0000000\",\r\n      \"voidDate\": null,\r\n      \"deliveryDate\": null,\r\n      \"carrierCode\": \"FedEx\",\r\n      \"sellerFillProviderId\": 12345,\r\n      \"sellerFillProviderName\": \"Example Fulfillment Provider Name\",\r\n      \"fulfillmentProviderCode\": null,\r\n      \"fulfillmentServiceCode\": null,\r\n      \"fulfillmentFee\": 0,\r\n      \"voidRequested\": false,\r\n      \"voided\": false,\r\n      \"marketplaceNotified\": true,\r\n      \"notifyErrorMessage\": null,\r\n      \"shipTo\": {\r\n        \"name\": \"Yoda\",\r\n        \"company\": null,\r\n        \"street1\": \"3800 N Lamar Blvd # 220\",\r\n        \"street2\": null,\r\n        \"street3\": null,\r\n        \"city\": \"AUSTIN\",\r\n        \"state\": \"TX\",\r\n        \"postalCode\": \"78756\",\r\n        \"country\": \"US\",\r\n        \"phone\": \"512-485-4282\",\r\n        \"residential\": null,\r\n        \"addressVerified\": null\r\n      }\r\n    }\r\n  ],\r\n  \"total\": 2,\r\n  \"page\": 1,\r\n  \"pages\": 0\r\n}\r\n";

            JObject jobj = JObject.Parse(resJson);
            FulfillmentResponse fulfillmentsRes = new FulfillmentResponse(
                _fulfillmentId: (int)jobj["fulfillments"]["fulfillmentId"],
                _orderId: (int)jobj["fulfillments"]["orderId"],
                _orderNumber: (string)jobj["fulfillments"]["orderNumber"],
                _userId: (string)jobj["fulfillments"]["userId"],
                _customerEmail: (string)jobj["fulfillments"]["customerEmail"],
                _trackingNumber: (string)jobj["fulfillments"]["trackingNumber"],
                _createDate: (DateTime)jobj["fulfillments"]["createDate"],
                _shipDate: (DateTime)jobj["fulfillments"]["shipDate"],
                _voidDate: (DateTime)jobj["fulfillments"]["voidDate"],
                _deliveryDate: (DateTime)jobj["fulfillments"]["deliveryDate"],
                _carrierCode: (string)jobj["fulfillments"]["carrierCode"],
                _sellerFillProviderId: (string)jobj["fulfillments"]["sellerFillProviderId"],
                _sellerFillProviderName: (string)jobj["fulfillments"]["sellerFillProviderName"],
                _fulfillmentProviderCode: (string)jobj["fulfillments"]["fulfillmentProviderCode"],
                _fulfillmentServiceCode: (string)jobj["fulfillments"]["fulfillmentServiceCode"],
                _fulfillmentFee: (double)jobj["fulfillments"]["fulfillmentFee"],
                _isVoidRequested: (bool)jobj["fulfillments"]["voidRequested"],
                _isVoided: (bool)jobj["fulfillments"]["voided"],
                _isMarketpalceNotified: (bool)jobj["fulfillments"]["marketplaceNotified"],
                _notifyErrorMessage: (string)jobj["fulfillments"]["notifyErrorMessage"]);
            // _shipTo: (Address)jobj["fulfillments"]["shipTo"]); 

            Console.WriteLine(fulfillmentsRes.ToString());
            return fulfillmentsRes;
        }
    }
}
