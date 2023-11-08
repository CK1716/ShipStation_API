using Newtonsoft.Json;
using ShipStation.Entities;
using ShipStation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Json;
using System.Runtime.InteropServices;
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

            JsonObjectCollection reqMain = new JsonObjectCollection
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

            string reqJson = reqMain.ToString();
            reqJson = reqJson.Replace("\n", "");
            reqJson = reqJson.Replace("\r", "");
            reqJson = reqJson.Replace("\t", "");

            /*getApi() 호출, getApi() return 후 해당 값으로 Res() 호출*/

            // string reqResult = ShipStation.ApiResult(url, "POST", reqJson);

            //response
            /* 
            AccountResponse accountsRes = new AccountResponse(
                _message: "ShipStation account Created.",
                _sellerId: 123456,
                _success: true,
                _apiKey: "abcdt9845hjmgfklj3498gkljdkuyekl",
                _apiSecret: "1234iou983lkj8mnxgfwu509hkhdy7u3");*/

            /* 
            AccountResponse acc = new AccountResponse
            {
                Message = "ShipStation account created.",
                SellerId = 123456,
                Success = true,
                ApiKey = "abcdt9845hjmgfklj3498gkljdkuyekl",
                ApiSecret = "1234iou983lkj8mnxgfwu509hkhdy7u3"
            };*/

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

            // string reqResult = ShipStation.ApiResult(url, "GET", reqJson);

            // response
            string jsonText = "{\r\n  \"fulfillments\": [\r\n    {\r\n      \"fulfillmentId\": 33974374,\r\n      \"orderId\": 191759016,\r\n      \"orderNumber\": \"101\",\r\n      \"userId\": \"c9f06d74-95de-4263-9b04-e87095cababf\",\r\n      \"customerEmail\": \"apisupport@shipstation.com\",\r\n      \"trackingNumber\": \"783408231234\",\r\n      \"createDate\": \"2016-06-07T08:50:50.0670000\",\r\n      \"shipDate\": \"2016-06-07T00:00:00.0000000\",\r\n      \"voidDate\": null,\r\n      \"deliveryDate\": null,\r\n      \"carrierCode\": \"USPS\",\r\n      \"fulfillmentProviderCode\": null,\r\n      \"fulfillmentServiceCode\": null,\r\n      \"fulfillmentFee\": 0,\r\n      \"voidRequested\": false,\r\n      \"voided\": false,\r\n      \"marketplaceNotified\": true,\r\n      \"notifyErrorMessage\": null,\r\n      \"shipTo\": {\r\n        \"name\": \"Yoda\",\r\n        \"company\": null,\r\n        \"street1\": \"3800 N Lamar Blvd # 220\",\r\n        \"street2\": null,\r\n        \"street3\": null,\r\n        \"city\": \"AUSTIN\",\r\n        \"state\": \"TX\",\r\n        \"postalCode\": \"78756\",\r\n        \"country\": \"US\",\r\n        \"phone\": \"512-485-4282\",\r\n        \"residential\": null,\r\n        \"addressVerified\": null \r\n      }\r\n    },\r\n    {\r\n      \"fulfillmentId\": 246310,\r\n      \"orderId\": 193699927,\r\n      \"orderNumber\": \"101\",\r\n      \"userId\": \"c9f06d74-95de-4263-9b04-e87095cababf\",\r\n      \"customerEmail\": \"apisupport@shipstation.com\",\r\n      \"trackingNumber\": \"664756278745\",\r\n      \"createDate\": \"2016-06-08T12:54:53.3470000\",\r\n      \"shipDate\": \"2016-06-08T00:00:00.0000000\",\r\n      \"voidDate\": null,\r\n      \"deliveryDate\": null,\r\n      \"carrierCode\": \"FedEx\",\r\n      \"sellerFillProviderId\": 12345,\r\n      \"sellerFillProviderName\": \"Example Fulfillment Provider Name\",\r\n      \"fulfillmentProviderCode\": null,\r\n      \"fulfillmentServiceCode\": null,\r\n      \"fulfillmentFee\": 0,\r\n      \"voidRequested\": false,\r\n      \"voided\": false,\r\n      \"marketplaceNotified\": true,\r\n      \"notifyErrorMessage\": null,\r\n      \"shipTo\": {\r\n        \"name\": \"Yoda\",\r\n        \"company\": null,\r\n        \"street1\": \"3800 N Lamar Blvd # 220\",\r\n        \"street2\": null,\r\n        \"street3\": null,\r\n        \"city\": \"AUSTIN\",\r\n        \"state\": \"TX\",\r\n        \"postalCode\": \"78756\",\r\n        \"country\": \"US\",\r\n        \"phone\": \"512-485-4282\",\r\n        \"residential\": null,\r\n        \"addressVerified\": null\r\n      }\r\n    }\r\n  ],\r\n  \"total\": 2,\r\n  \"page\": 1,\r\n  \"pages\": 0\r\n}\r\n";
            /*string jsonText = @"
            {   jsonarray 형식으로 for문 
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
            JsonNumericValue setTotal = (JsonNumericValue)col["total"];
            JsonNumericValue setPage = (JsonNumericValue)col["page"];
            JsonNumericValue setPageSize = (JsonNumericValue)col["pages"];

            List<Fulfillments> listFulFill = new List<Fulfillments>();
            ElementPage elementPage = new ElementPage();

            for (int i = 0; i < fulfillmentsArray.Count; i++)
            {
                /* fulfillmentRes의 각 파라미터에 해당하는 값을 저장해야함 <- 구현 중 */

                JsonObjectCollection element = (JsonObjectCollection)fulfillmentsArray[i];
                JsonObjectCollection elementShipTo = (JsonObjectCollection)element["shipTo"];

                // 1. 원래 방식으로 변경하기 v
                // 2. AddressVerified 값 어떻게 넘겨 받아올지 생각해보기
                // 3. total, page, pages 값 받기 v 
                // 4. 전체적인 값 한 번에 넘긴 후, request에서 제대로 값 들어왔는지 확인하기 v
                /*                addrShipTo.Name = Convert.ToString(elementShipTo["name"] != null ? elementShipTo["name"].GetValue() : string.Empty);
                                addrShipTo.Company = Convert.ToString(elementShipTo["company"] != null ? elementShipTo["company"].GetValue() : string.Empty);
                                addrShipTo.Street1 = Convert.ToString(elementShipTo["street1"] != null ? elementShipTo["street1"].GetValue() : string.Empty);
                                addrShipTo.Street2 = Convert.ToString(elementShipTo["street2"] != null ? elementShipTo["street2"].GetValue() : string.Empty);
                                addrShipTo.Street3 = Convert.ToString(elementShipTo["street3"] != null ? elementShipTo["street3"].GetValue() : string.Empty);
                                addrShipTo.City = Convert.ToString(elementShipTo["city"] != null ? elementShipTo["city"].GetValue() : string.Empty);
                                addrShipTo.State = Convert.ToString(elementShipTo["state"] != null ? elementShipTo["state"].GetValue() : string.Empty);
                                addrShipTo.PostalCode = Convert.ToString(elementShipTo["postalCode"] != null ? elementShipTo["postalCode"].GetValue() : string.Empty);
                                addrShipTo.Country = Convert.ToString(elementShipTo["country"] != null ? elementShipTo["country"].GetValue() : string.Empty);
                                addrShipTo.Phone = Convert.ToString(elementShipTo["phone"] != null ? elementShipTo["phone"].GetValue() : string.Empty);
                                addrShipTo.IsResidential = Convert.ToBoolean(elementShipTo["residential"] != null ? elementShipTo["residential"].GetValue() : null);
                                addrShipTo.AddressVerified = Convert.ToString(elementShipTo["addressVerified"] != null ? elementShipTo["addressVerified"].GetValue() :null);*/

                /*Address addrShipTo = new Address(
                    _name: Convert.ToString(elementShipTo["name"] != null ? elementShipTo["name"].GetValue() : string.Empty),
                    _company: Convert.ToString(elementShipTo["company"] != null ? elementShipTo["company"].GetValue() : string.Empty),
                    _street1: Convert.ToString(elementShipTo["street1"] != null ? elementShipTo["street1"].GetValue() : string.Empty),
                    _street2: Convert.ToString(elementShipTo["street2"] != null ? elementShipTo["street2"].GetValue() : string.Empty),
                    _street3: Convert.ToString(elementShipTo["street3"] != null ? elementShipTo["street3"].GetValue() : string.Empty),
                    _city: Convert.ToString(elementShipTo["city"] != null ? elementShipTo["city"].GetValue() : string.Empty),
                    _state: Convert.ToString(elementShipTo["state"] != null ? elementShipTo["state"].GetValue() : string.Empty),
                    _postalCode: Convert.ToString(elementShipTo["postalCode"] != null ? elementShipTo["postalCode"].GetValue() : string.Empty),
                    _country: Convert.ToString(elementShipTo["country"] != null ? elementShipTo["country"].GetValue() : string.Empty),
                    _phone: Convert.ToString(elementShipTo["phone"] != null ? elementShipTo["phone"].GetValue() : string.Empty),
                    _isResidential: Convert.ToBoolean(elementShipTo["residential"] != null ? elementShipTo["residential"].GetValue() : null),
                    _addressVerified: Convert.ToString(elementShipTo["addressVerified"] != null ? elementShipTo["addressVerified"].GetValue() : string.Empty));*/

                // AddressVerified 값이 enumValue인데 string으로 써도 상관 없나..? -> 형 변환을 어떤 식으로 해서 값을 집어넣어야 할지를 잘 모르겠음. 검색해보기
                // -> 모델에서 건드리는게 가장 깔끔할 것 같음

                listFulFill.Add(new Fulfillments()
                {
                    FulfillmentId = Convert.ToInt32(element["fulfillmentId"] != null ? element["fulfillmentId"].GetValue() : null),
                    OrderId = Convert.ToInt32(element["orderId"] != null ? element["orderId"].GetValue() : null),
                    OrderNumber = Convert.ToString(element["orderNumber"] != null ? element["orderId"].GetValue() : string.Empty),
                    UserId = Convert.ToString(element["userId"] != null ? element["userId"].GetValue() : string.Empty),
                    CustomerEmail = Convert.ToString(element["customerEmail"] != null ? element["customerEmail"].GetValue() : string.Empty),
                    TrackingNumber = Convert.ToString(element["trackingNumber"] != null ? element["trackingNumber"].GetValue() : string.Empty),
                    CreatedDate = Convert.ToDateTime(element["createDate"] != null ? element["createDate"].GetValue() : string.Empty),
                    ShipDate = Convert.ToDateTime(element["shipDate"] != null ? element["shipDate"].GetValue() : string.Empty),
                    VoidDate = Convert.ToDateTime(element["vaoidDate"] != null ? element["voidDate"].GetValue() : null),
                    DeliveryDate = Convert.ToDateTime(element["deliveryDate"] != null ? element["deliveryDate"].GetValue() : string.Empty),
                    CarrierCode = Convert.ToString(element["carrierCode"] != null ? element["carrierCode"].GetValue() : string.Empty),
                    SellerFillProviderId = Convert.ToInt32(element["sellerFillProviderId"] != null ? element["sellerFillProviderId"].GetValue() : null),
                    SellerFillProviderName = Convert.ToString(element["sellerFillProviderName"] != null ? element["sellerFillProviderName"].GetValue() : string.Empty),
                    FulfillmentServiceCode = Convert.ToString(element["fulfillmentProviderCode"] != null ? element["fulfillmentProviderCode"].GetValue() : string.Empty),
                    FulfillmentProviderCode = Convert.ToString(element["fulfillmentServiceCode"] != null ? element["fulfillmentServiceCode"].GetValue() : string.Empty),
                    FulfillmentFee = Convert.ToDouble(element["fulfillmentFee"] != null ? element["fulfillmentFee"].GetValue() : null),
                    IsVoidRequested = Convert.ToBoolean(element["voidRequested"] != null ? element["voidRequested"].GetValue() : null),
                    IsVoided = Convert.ToBoolean(element["voided"] != null ? element["voided"].GetValue() : null),
                    IsMarketplaceNotified = Convert.ToBoolean(element["marketplaceNotified"] != null ? element["marketplaceNotified"].GetValue() : null),
                    NotifyErrorMessage = Convert.ToString(element["notifyErrorMessage"] != null ? element["notifyErrorMessage"].GetValue() : null),
                    ShipTo = new Address()
                    {
                        Name = Convert.ToString(elementShipTo["name"] != null ? elementShipTo["name"].GetValue() : string.Empty),
                        Company = Convert.ToString(elementShipTo["company"] != null ? elementShipTo["company"].GetValue() : string.Empty),
                        Street1 = Convert.ToString(elementShipTo["street1"] != null ? elementShipTo["street1"].GetValue() : string.Empty),
                        Street2 = Convert.ToString(elementShipTo["street2"] != null ? elementShipTo["street2"].GetValue() : string.Empty),
                        Street3 = Convert.ToString(elementShipTo["street3"] != null ? elementShipTo["street3"].GetValue() : string.Empty),
                        City = Convert.ToString(elementShipTo["city"] != null ? elementShipTo["city"].GetValue() : string.Empty),
                        State = Convert.ToString(elementShipTo["state"] != null ? elementShipTo["state"].GetValue() : string.Empty),
                        PostalCode = Convert.ToString(elementShipTo["postalCode"] != null ? elementShipTo["postalCode"].GetValue() : string.Empty),
                        Country = Convert.ToString(elementShipTo["country"] != null ? elementShipTo["country"].GetValue() : string.Empty),
                        Phone = Convert.ToString(elementShipTo["phone"] != null ? elementShipTo["phone"].GetValue() : string.Empty),
                        IsResidential = Convert.ToBoolean(elementShipTo["residential"] != null ? elementShipTo["residential"].GetValue() : null),
                        AddressVerified = Convert.ToString(elementShipTo["addressVerified"] != null ? elementShipTo["addressVerified"].GetValue() : null)
                    }
                        
                });

                // 상태도 같이 리턴??
                string _statusToStr = listFulFill[i].ShipTo.AddressVerified;
                switch (_statusToStr)
                {
                    
                    case "Address not yet validated":
                        // "Address not yet validated";
                        AddressVerified status =  AddressVerified.NotVerified; // 상태를 마지막에 함께 넘겨줘야 하나? 
                        listFulFill[i].ShipTo.AddressVerified = "Address not yet validated";
                        break;

                    case "Address validation warning":
                        // "Address validation warning";
                        status = AddressVerified.Warning;
                        listFulFill[i].ShipTo.AddressVerified = "Address validation warning";
                        break;

                    case "Address validation failed":
                        // "Address validation failed";
                        status = AddressVerified.Failed;
                        listFulFill[i].ShipTo.AddressVerified = "Address validation failed";
                        break;

                    case "Address validated successfully":
                        // "Address validated successfully";
                        status = AddressVerified.Successful;
                        listFulFill[i].ShipTo.AddressVerified = "Address validated successfully";
                        break;
                        
                    case null:
                        // null
                        break;
                } 
                
                /*listFulFill.Add(new FulfillmentResponse(
                    _fulfillmentId: Convert.ToInt32(element["fulfillmentId"] != null ? element["fulfillmentId"].GetValue() : null),
                    _orderId: Convert.ToInt32(element["orderId"] != null ? element["orderId"].GetValue() : null),
                    _orderNumber: Convert.ToString(element["orderNumber"] != null ? element["orderId"].GetValue() : string.Empty),
                    _userId: Convert.ToString(element["userId"] != null ? element["userId"].GetValue() : string.Empty),
                    _customerEmail: Convert.ToString(element["customerEmail"] != null ? element["customerEmail"].GetValue() : string.Empty),
                    _trackingNumber: Convert.ToString(element["trackingNumber"] != null ? element["trackingNumber"].GetValue() : string.Empty),
                    _createDate: Convert.ToDateTime(element["createDate"] != null ? element["createDate"].GetValue() : string.Empty),
                    _shipDate: Convert.ToDateTime(element["shipDate"] != null ? element["shipDate"].GetValue() : string.Empty),
                    _voidDate: Convert.ToDateTime(element["vaoidDate"] != null ? element["voidDate"].GetValue() : null),
                    _deliveryDate: Convert.ToDateTime(element["deliveryDate"] != null ? element["deliveryDate"].GetValue() : string.Empty),
                    _carrierCode: Convert.ToString(element["carrierCode"] != null ? element["carrierCode"].GetValue() : string.Empty),
                    _sellerFillProviderId: Convert.ToInt32(element["sellerFillProviderId"] != null ? element["sellerFillProviderId"].GetValue() : null),
                    _sellerFillProviderName: Convert.ToString(element["sellerFillProviderName"] != null ? element["sellerFillProviderName"].GetValue() : string.Empty),
                    _fulfillmentProviderCode: Convert.ToString(element["fulfillmentProviderCode"] != null ? element["fulfillmentProviderCode"].GetValue() : string.Empty),
                    _fulfillmentServiceCode: Convert.ToString(element["fulfillmentServiceCode"] != null ? element["fulfillmentServiceCode"].GetValue() : string.Empty),
                    _fulfillmentFee: Convert.ToDouble(element["fulfillmentFee"] != null ? element["fulfillmentFee"].GetValue() : null),
                    _isVoidRequested: Convert.ToBoolean(element["voidRequested"] != null ? element["voidRequested"].GetValue() : null),
                    _isVoided: Convert.ToBoolean(element["voided"] != null ? element["voided"].GetValue() : null),
                    _isMarketpalceNotified: Convert.ToBoolean(element["marketplaceNotified"] != null ? element["marketplaceNotified"].GetValue() : null),
                    _notifyErrorMessage: Convert.ToString(element["notifyErrorMessage"] != null ? element["notifyErrorMessage"].GetValue() : null),
                    _shipTo: addrShipTo));*/
            }
           
            elementPage.Total = Convert.ToInt32(setTotal.GetValue());
            elementPage.Page = Convert.ToInt32(setPage.GetValue());
            elementPage.PageSize = Convert.ToInt32(setPageSize.GetValue());
            
            FulfillmentResponse fulfillmentRes = new FulfillmentResponse(listFulFill, elementPage);
            
            return fulfillmentRes;
        }
    }

    public class CreateLabel
    {
        public static CreateLabelForOrderResponse ClReq(CreateLabelForOrderRequest _createLabelForOrderReq)
        {
            string url = "https://ssapi.shipstation.com/orders/createlabelfororder";

            JsonObjectCollection weight = new JsonObjectCollection
            {
                new JsonStringValue("value", _createLabelForOrderReq.Weight.Value != null ? _createLabelForOrderReq.Weight.Value.ToString() : null),
                new JsonStringValue("units", _createLabelForOrderReq.Weight.Units != null ? _createLabelForOrderReq.Weight.Units.ToString() : string.Empty),
                new JsonStringValue("weightUnits", _createLabelForOrderReq.Weight.WeightUnits != null ? _createLabelForOrderReq.Weight.WeightUnits.ToString() : null)
            };

               

            JsonObjectCollection reqMain = new JsonObjectCollection
            /* JsonArrayCollection accountReq = new JsonArrayCollection("AccountRequest");
            JsonObjectCollection items = new JsonObjectCollection */
            {
                new JsonStringValue("OrderId", _createLabelForOrderReq.OrderID != null ? _createLabelForOrderReq.OrderID.ToString() : string.Empty),
                new JsonStringValue("CarrierCode", _createLabelForOrderReq.CarrierCode != null ? _createLabelForOrderReq.CarrierCode.ToString() : string.Empty),
                new JsonStringValue("ServiceCode", _createLabelForOrderReq.ServiceCode != null ? _createLabelForOrderReq.ServiceCode.ToString() : string.Empty),
                new JsonStringValue("PackageCode", _createLabelForOrderReq.PackageCode != null ? _createLabelForOrderReq.PackageCode.ToString() : string.Empty),
                new JsonStringValue("Confirmation", _createLabelForOrderReq.Confirmation != null ? _createLabelForOrderReq.Confirmation.ToString() : string.Empty),
                new JsonStringValue("ShipDate", _createLabelForOrderReq.ShipDate != null ? _createLabelForOrderReq.ShipDate.ToString() : string.Empty),
                new JsonObjectCollection("Weight", weight),
                new JsonStringValue("Dimensions", _createLabelForOrderReq.Dimensions != null ? _createLabelForOrderReq.Dimensions.ToString() : string.Empty),
                new JsonStringValue("InsuranceOptions", _createLabelForOrderReq.InsuranceOptions != null ? _createLabelForOrderReq.InsuranceOptions.ToString() : string.Empty),
                new JsonStringValue("InternationalOptions", _createLabelForOrderReq.InternationalOptions != null ? _createLabelForOrderReq.InternationalOptions.ToString() : string.Empty),
                new JsonStringValue("AdvancedOptions", _createLabelForOrderReq.AdvancedOptions != null ? _createLabelForOrderReq.AdvancedOptions.ToString() : string.Empty),
                new JsonStringValue("TestLabel", _createLabelForOrderReq.TestLabel != null ? _createLabelForOrderReq.TestLabel.ToString() : string.Empty)
            };
            
            string reqJson = reqMain.ToString();
            reqJson = reqJson.Replace("\n", "");
            reqJson = reqJson.Replace("\r", "");
            reqJson = reqJson.Replace("\t", "");

            // string reqResult = ShipStation.ApiResult(url, "POST", reqJson);

            string resJsonData = "{\r\n  \"shipmentId\": 72513480,\r\n  \"shipmentCost\": 7.3,\r\n  \"insuranceCost\": 0,\r\n  \"trackingNumber\": \"248201115029520\",\r\n  \"labelData\": \"JVBERi0xLjQKJeLjz9MKMiAwIG9iago8PC9MZW5ndGggNjIvRmlsdGVyL0ZsYXRlRGVjb2RlPj5zdHJlYW0KeJwr5HIK4TI2UzC2NFMISeFyDeEK5CpUMFQwAEJDBV0jCz0LBV1jY0M9I4XkXAX9iDRDBZd8hUAuAEdGC7cKZW5kc3RyZWFtCmVuZG9iago0IDAgb2JqCjw8L1R5cGUvUGFnZS9NZWRpYUJveFswIDAgMjg4IDQzMl0vUmVzb3VyY2VzPDwvUHJvY1NldCBbL1BERiAvVGV4dCAvSW1hZ2VCIC9JbWFnZUMgL0ltYWdlSV0vWE9iamVjdDw8L1hmMSAxIDAgUj4+Pj4vQ29udGVudHMgMiAwIFIvUGFyZW50....\",\r\n  \"formData\": null\r\n}\r\n";
            
            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(resJsonData);
            JsonObjectCollection col = (JsonObjectCollection)obj;

            CreateLabelForOrderResponse createLabelForOrderRes = new CreateLabelForOrderResponse()
            {
                ShipmentId = Convert.ToInt32(col["shipmentId"] != null ? col["shipmentId"].GetValue() : null),
                ShipmentCost = Convert.ToDouble(col["shipmentCost"] != null ? col["shipmentCost"].GetValue() : null),
                InsuranceCost = Convert.ToInt32(col["insuranceCost"] != null ? col["insuranceCost"].GetValue() : null),
                TrackingNumber = Convert.ToString(col["trackingNumber"] != null ? col["trackingNumber"].GetValue() : string.Empty),
                LabelData = Convert.ToString(col["labelData"] != null ? col["labelData"].GetValue() : string.Empty),
                FormData = Convert.ToString(col["formData"] != null ? col["formData"].GetValue() : string.Empty)
            };
            

            return createLabelForOrderRes;
        }
    }
}
