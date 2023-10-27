using ShipStation.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Json;
using System.Text;

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

            // string reqResult = ShipStation.ApiResult(url, "POST", _jsonData);

            //response
            /* method : AcReq(), AcRes() 합치기 */
            /*            AccountResponse accountsRes = new AccountResponse(
                            _message: "ShipStation account Created.",
                            _sellerId: 123456,
                            _success: true,
                            _apiKey: "abcdt9845hjmgfklj3498gkljdkuyekl",
                            _apiSecret: "1234iou983lkj8mnxgfwu509hkhdy7u3");*/

            /* AccountResponse acc = new AccountResponse
            { Message = "ShipStation account created.",
            SellerId = 123456,
            Success = true,
            ApiKey = "abcdt9845hjmgfklj3498gkljdkuyekl",
            ApiSecret = "1234iou983lkj8mnxgfwu509hkhdy7u3" }; */

            // string resJsonData = JsonConvert.SerializeObject(accountsRes);

            string resJsonData = "{\r\n  \"message\": \"ShipStation account created.\",\r\n  \"sellerId\": 123456,\r\n  \"success\": true,\r\n  \"apiKey\": \"abcdt9845hjmgfklj3498gkljdkuyekl\",\r\n  \"apiSecret\": \"1234iou983lkj8mnxgfwu509hkhdy7u3\"\r\n}\r\n";

            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(resJsonData);
            JsonObjectCollection col = (JsonObjectCollection)obj;

            //삼항 연산자 
            // -> (if 조건) ? (참일 때 사용 값) ? (거짓일 때 사용 값)
            AccountResponse accountsRes = new AccountResponse(
                _message: (string)(col["message"] != null ? col["message"].GetValue() : string.Empty),
                _sellerId: int.Parse(col["sellerId"] != null ? col["sellerId"].GetValue().ToString() : string.Empty),
                _success: bool.Parse(col["success"] != null ? col["success"].GetValue().ToString() : string.Empty),
                _apiKey: (string)(col["apiKey"] != null ? col["apiKey"].GetValue() : string.Empty),
                _apiSecret: (string)(col["apiSecret"] != null ? col["apiSecret"].GetValue() : string.Empty));

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

            // response
            string jsonText = "{\r\n  \"fulfillments\": [\r\n    {\r\n      \"fulfillmentId\": 33974374,\r\n      \"orderId\": 191759016,\r\n      \"orderNumber\": \"101\",\r\n      \"userId\": \"c9f06d74-95de-4263-9b04-e87095cababf\",\r\n      \"customerEmail\": \"apisupport@shipstation.com\",\r\n      \"trackingNumber\": \"783408231234\",\r\n      \"createDate\": \"2016-06-07T08:50:50.0670000\",\r\n      \"shipDate\": \"2016-06-07T00:00:00.0000000\",\r\n      \"voidDate\": null,\r\n      \"deliveryDate\": null,\r\n      \"carrierCode\": \"USPS\",\r\n      \"fulfillmentProviderCode\": null,\r\n      \"fulfillmentServiceCode\": null,\r\n      \"fulfillmentFee\": 0,\r\n      \"voidRequested\": false,\r\n      \"voided\": false,\r\n      \"marketplaceNotified\": true,\r\n      \"notifyErrorMessage\": null,\r\n      \"shipTo\": {\r\n        \"name\": \"Yoda\",\r\n        \"company\": null,\r\n        \"street1\": \"3800 N Lamar Blvd # 220\",\r\n        \"street2\": null,\r\n        \"street3\": null,\r\n        \"city\": \"AUSTIN\",\r\n        \"state\": \"TX\",\r\n        \"postalCode\": \"78756\",\r\n        \"country\": \"US\",\r\n        \"phone\": \"512-485-4282\",\r\n        \"residential\": null,\r\n        \"addressVerified\": null\r\n      }\r\n    },\r\n    {\r\n      \"fulfillmentId\": 246310,\r\n      \"orderId\": 193699927,\r\n      \"orderNumber\": \"101\",\r\n      \"userId\": \"c9f06d74-95de-4263-9b04-e87095cababf\",\r\n      \"customerEmail\": \"apisupport@shipstation.com\",\r\n      \"trackingNumber\": \"664756278745\",\r\n      \"createDate\": \"2016-06-08T12:54:53.3470000\",\r\n      \"shipDate\": \"2016-06-08T00:00:00.0000000\",\r\n      \"voidDate\": null,\r\n      \"deliveryDate\": null,\r\n      \"carrierCode\": \"FedEx\",\r\n      \"sellerFillProviderId\": 12345,\r\n      \"sellerFillProviderName\": \"Example Fulfillment Provider Name\",\r\n      \"fulfillmentProviderCode\": null,\r\n      \"fulfillmentServiceCode\": null,\r\n      \"fulfillmentFee\": 0,\r\n      \"voidRequested\": false,\r\n      \"voided\": false,\r\n      \"marketplaceNotified\": true,\r\n      \"notifyErrorMessage\": null,\r\n      \"shipTo\": {\r\n        \"name\": \"Yoda\",\r\n        \"company\": null,\r\n        \"street1\": \"3800 N Lamar Blvd # 220\",\r\n        \"street2\": null,\r\n        \"street3\": null,\r\n        \"city\": \"AUSTIN\",\r\n        \"state\": \"TX\",\r\n        \"postalCode\": \"78756\",\r\n        \"country\": \"US\",\r\n        \"phone\": \"512-485-4282\",\r\n        \"residential\": null,\r\n        \"addressVerified\": null\r\n      }\r\n    }\r\n  ],\r\n  \"total\": 2,\r\n  \"page\": 1,\r\n  \"pages\": 0\r\n}\r\n";
            /*string jsonText = @"
            {jsonarray 형식으로 for문 
                ""fulfillments"": [
                {   
                    ""fulfillmentId"": 33974374,
                    ""orderId"": 191759016,
                    ""orderNumber"": ""101"",
                    ""userId"": ""c9f06d74-95de-4263-9b04-e87095cababf"",
                    ""customerEmail"": ""apisupport@shipstation.com"",
                    ""trackingNumber"": ""783408231234"",
                    ""createDate"": ""2016-06-07T08:50:50.0670000"",
                    ""shipDate"": ""2016-06-07T00:00:00.0000000"",
                    ""voidDate"": null,
                    ""deliveryDate"": null,
                    ""carrierCode"": ""USPS"",
                    ""fulfillmentProviderCode"": null,
                    ""fulfillmentServiceCode"": null,
                    ""fulfillmentFee"": 0,
                    ""voidRequested"": false,
                    ""voided"": false,
                    ""marketplaceNotified"": true,
                    ""notifyErrorMessage"": null,
                    ""shipTo"": {
                        ""name"": ""Yoda"",
                        ""company"": null,
                        ""street1"": ""3800 N Lamar Blvd # 220"",
                        ""street2"": null,
                        ""street3"": null,
                        ""city"": ""AUSTIN"",
                        ""state"": ""TX"",
                        ""postalCode"": ""78756"",
                        ""country"": ""US"",
                        ""phone"": ""512-485-4282"",
                        ""residential"": null,
                        ""addressVerified"": null
                    }
                },
                {
                    ""fulfillmentId"": 246310,
                    ""orderId"": 193699927,
                    ""orderNumber"": ""101"",
                    ""userId"": ""c9f06d74-95de-4263-9b04-e87095cababf"",
                    ""customerEmail"": ""apisupport@shipstation.com"",
                    ""trackingNumber"": ""664756278745"",
                    ""createDate"": ""2016-06-08T12:54:53.3470000"",
                    ""shipDate"": ""2016-06-08T00:00:00.0000000"",
                    ""voidDate"": null,
                    ""deliveryDate"": null,
                    ""carrierCode"": ""FedEx"",
                    ""sellerFillProviderId"": 12345,
                    ""sellerFillProviderName"": ""Example Fulfillment Provider Name"",
                    ""fulfillmentProviderCode"": null,
                    ""fulfillmentServiceCode"": null,
                    ""fulfillmentFee"": 0,
                    ""voidRequested"": false,
                    ""voided"": false,
                    ""marketplaceNotified"": true,
                    ""notifyErrorMessage"": null,
                    ""shipTo"": {
                        ""name"": ""Yoda"",
                        ""company"": null,
                        ""street1"": ""3800 N Lamar Blvd # 220"",
                        ""street2"": null,
                        ""street3"": null,
                        ""city"": ""AUSTIN"",
                        ""state"": ""TX"",
                        ""postalCode"": ""78756"",
                        ""country"": ""US"",
                        ""phone"": ""512-485-4282"",
                        ""residential"": null,
                        ""addressVerified"": null
                    }
                }
            ],
            ""total"": 2,
            ""page"": 1,
            ""pages"": 0
            }";*/

            string resJsonData = jsonText.ToString();
            resJsonData = resJsonData.Replace("\n", "");
            resJsonData = resJsonData.Replace("\r", "");
            resJsonData = resJsonData.Replace("\t", "");

            // 여기까지 get 응답이 직렬화되어 서버에서 넘어온 상황.
                        
            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(resJsonData);
            JsonObjectCollection col = (JsonObjectCollection)obj;

            JsonArrayCollection fulfillmentsArray = (JsonArrayCollection)col["fulfillments"];

            FulfillmentResponse fulfillmentRes = new FulfillmentResponse();

            for (int i = 0; i < fulfillmentsArray.Count; i++)
            {
                JsonObjectCollection element = (JsonObjectCollection)fulfillmentsArray[i];
                fulfillmentRes.FulfillmentId = int.Parse(element["fulfillmentId"].GetValue().ToString());

            }
            return fulfillmentRes;
        }
    }
}
