using ShipStation.Entities;
using ShipStation.Models;
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

    public class API_Account
    {
        public static AccountResponse Register(AccountRequest _accountsReq)
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

            string jsonText = "{\r\n  \"message\": \"ShipStation account created.\",\r\n  \"sellerId\": 123456,\r\n  \"success\": true,\r\n  \"apiKey\": \"abcdt9845hjmgfklj3498gkljdkuyekl\",\r\n  \"apiSecret\": \"1234iou983lkj8mnxgfwu509hkhdy7u3\"\r\n}\r\n";

            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(jsonText);
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

    public class API_Fulfillments
    {
        public static FulfillmentResponse ListFulfillments(FulfillmentRequest _fulfillmentsReq)
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



            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(jsonText);
            JsonObjectCollection col = (JsonObjectCollection)obj;

            JsonArrayCollection fulfillmentsArray = (JsonArrayCollection)col["fulfillments"];
            JsonNumericValue setTotal = (JsonNumericValue)col["total"];
            JsonNumericValue setPage = (JsonNumericValue)col["page"];
            JsonNumericValue setPageSize = (JsonNumericValue)col["pages"];

            List<Fulfillments> listFulFill = new List<Fulfillments>();
            ElementPage elementPage = new ElementPage();

            for (int i = 0; i < fulfillmentsArray.Count; i++)
            {
                JsonObjectCollection element = (JsonObjectCollection)fulfillmentsArray[i];
                JsonObjectCollection elementShipTo = (JsonObjectCollection)element["shipTo"];

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
                        AddressVerified status = AddressVerified.NotVerified; // 상태를 마지막에 함께 넘겨줘야 하나? 
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
            }

            elementPage.Total = Convert.ToInt32(setTotal.GetValue());
            elementPage.Page = Convert.ToInt32(setPage.GetValue());
            elementPage.PageSize = Convert.ToInt32(setPageSize.GetValue());

            FulfillmentResponse fulfillmentRes = new FulfillmentResponse(listFulFill, elementPage);

            return fulfillmentRes;
        }
    }

    public class API_Orders
    {
        public static CreateLabelForOrderResponse CreateLabel(CreateLabelForOrderRequest _createLabelForOrderReq)
        {
            string url = "https://ssapi.shipstation.com/orders/createlabelfororder";

            JsonObjectCollection weight = new JsonObjectCollection
            {
                new JsonStringValue("value", _createLabelForOrderReq.Weight.Value != null ? _createLabelForOrderReq.Weight.Value.ToString() : null),
                new JsonStringValue("units", _createLabelForOrderReq.Weight.Units != null ? _createLabelForOrderReq.Weight.Units.ToString() : string.Empty),
                new JsonStringValue("weightUnits", _createLabelForOrderReq.Weight.WeightUnits != null ? _createLabelForOrderReq.Weight.WeightUnits.ToString() : null)
            };

            JsonObjectCollection reqMain = new JsonObjectCollection
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

            string jsonText = "{\r\n  \"shipmentId\": 72513480,\r\n  \"shipmentCost\": 7.3,\r\n  \"insuranceCost\": 0,\r\n  \"trackingNumber\": \"248201115029520\",\r\n  \"labelData\": \"JVBERi0xLjQKJeLjz9MKMiAwIG9iago8PC9MZW5ndGggNjIvRmlsdGVyL0ZsYXRlRGVjb2RlPj5zdHJlYW0KeJwr5HIK4TI2UzC2NFMISeFyDeEK5CpUMFQwAEJDBV0jCz0LBV1jY0M9I4XkXAX9iDRDBZd8hUAuAEdGC7cKZW5kc3RyZWFtCmVuZG9iago0IDAgb2JqCjw8L1R5cGUvUGFnZS9NZWRpYUJveFswIDAgMjg4IDQzMl0vUmVzb3VyY2VzPDwvUHJvY1NldCBbL1BERiAvVGV4dCAvSW1hZ2VCIC9JbWFnZUMgL0ltYWdlSV0vWE9iamVjdDw8L1hmMSAxIDAgUj4+Pj4vQ29udGVudHMgMiAwIFIvUGFyZW50....\",\r\n  \"formData\": null\r\n}\r\n";

            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(jsonText);
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

        public static Create_UpdateOrderResponse CreateUpdateOrder(Create_UpdateOrderRequest _create_updateOrderReq)
        {
            string url = "https://ssapi.shipstation.com/orders/createorder";

            // Create new object. type : Address
            JsonObjectCollection elementsBillTo = new JsonObjectCollection
            {
                new JsonStringValue("name", _create_updateOrderReq.BillTo.Name != null ? _create_updateOrderReq.BillTo.Name.ToString() : string.Empty),
                new JsonStringValue("company", _create_updateOrderReq.BillTo.Company != null ? _create_updateOrderReq.BillTo.Company.ToString() : string.Empty),
                new JsonStringValue("street1", _create_updateOrderReq.BillTo.Street1 != null ? _create_updateOrderReq.BillTo.Street1.ToString() : string.Empty),
                new JsonStringValue("street2", _create_updateOrderReq.BillTo.Street2 != null ? _create_updateOrderReq.BillTo.Street2.ToString() : string.Empty),
                new JsonStringValue("street3", _create_updateOrderReq.BillTo.Street3 != null ? _create_updateOrderReq.BillTo .Street3.ToString() : string.Empty),
                new JsonStringValue("city", _create_updateOrderReq.BillTo.City != null ? _create_updateOrderReq .BillTo .City.ToString() : string.Empty),
                new JsonStringValue("state", _create_updateOrderReq.BillTo.State != null ? _create_updateOrderReq.BillTo.State.ToString() : string.Empty),
                new JsonStringValue("postalCode", _create_updateOrderReq.BillTo.PostalCode != null ? _create_updateOrderReq.BillTo.PostalCode.ToString() : string.Empty),
                new JsonStringValue("country", _create_updateOrderReq.BillTo.Country != null ? _create_updateOrderReq.BillTo.Country.ToString() : string.Empty),
                new JsonStringValue("phone", _create_updateOrderReq.BillTo.Phone != null ? _create_updateOrderReq.BillTo.Phone.ToString() : string.Empty),
                new JsonStringValue("residential", _create_updateOrderReq.BillTo.IsResidential != null ? _create_updateOrderReq.BillTo.IsResidential.ToString() : string.Empty),
                new JsonStringValue("addressVerifed", _create_updateOrderReq.BillTo.AddressVerified != null ? _create_updateOrderReq.BillTo.AddressVerified.ToString() : string.Empty),
            };

            // Create new object. type : Address
            JsonObjectCollection elementsShipTo = new JsonObjectCollection
            {
                new JsonStringValue("name", _create_updateOrderReq.ShipTo.Name != null ? _create_updateOrderReq.ShipTo.Name.ToString() : string.Empty),
                new JsonStringValue("company", _create_updateOrderReq.ShipTo.Company != null ? _create_updateOrderReq.ShipTo.Company.ToString() : string.Empty),
                new JsonStringValue("street1", _create_updateOrderReq.ShipTo.Street1 != null ? _create_updateOrderReq.ShipTo.Street1.ToString() : string.Empty),
                new JsonStringValue("street2", _create_updateOrderReq.ShipTo.Street2 != null ? _create_updateOrderReq.ShipTo.Street2.ToString() : string.Empty),
                new JsonStringValue("street3", _create_updateOrderReq.ShipTo.Street3 != null ? _create_updateOrderReq.ShipTo .Street3.ToString() : string.Empty),
                new JsonStringValue("city", _create_updateOrderReq.ShipTo.City != null ? _create_updateOrderReq .ShipTo .City.ToString() : string.Empty),
                new JsonStringValue("state", _create_updateOrderReq.ShipTo.State != null ? _create_updateOrderReq.ShipTo.State.ToString() : string.Empty),
                new JsonStringValue("postalCode", _create_updateOrderReq.ShipTo.PostalCode != null ? _create_updateOrderReq.ShipTo.PostalCode.ToString() : string.Empty),
                new JsonStringValue("country", _create_updateOrderReq.ShipTo.Country != null ? _create_updateOrderReq.ShipTo.Country.ToString() : string.Empty),
                new JsonStringValue("phone", _create_updateOrderReq.ShipTo.Phone != null ? _create_updateOrderReq.ShipTo.Phone.ToString() : string.Empty),
                new JsonStringValue("residential", _create_updateOrderReq.ShipTo.IsResidential != null ? _create_updateOrderReq.ShipTo.IsResidential.ToString() : string.Empty),
                new JsonStringValue("addressVerifed", _create_updateOrderReq.ShipTo.AddressVerified != null ? _create_updateOrderReq.ShipTo.AddressVerified.ToString() : string.Empty),
            };

            // Create new object. type : Weight
            JsonObjectCollection elementsWeight = new JsonObjectCollection
            {
                new JsonStringValue("value", _create_updateOrderReq.Weight.Value != null ? _create_updateOrderReq.Weight.Value.ToString() : string.Empty),
                new JsonStringValue("units", _create_updateOrderReq.Weight.Units != null ? _create_updateOrderReq.Weight.Units.ToString() : string.Empty),
                new JsonStringValue("weightUnits", _create_updateOrderReq.Weight.WeightUnits != null ? _create_updateOrderReq.Weight.WeightUnits.ToString() : string.Empty)
            };

            // Create new Ojbect. type : Demensions
            JsonObjectCollection elementsDimensions = new JsonObjectCollection
            {
                new JsonStringValue("units", _create_updateOrderReq.Dimensions.Units != null ? _create_updateOrderReq.Dimensions.Units.ToString() : string.Empty),
                new JsonStringValue("length", _create_updateOrderReq.Dimensions.Length != null ? _create_updateOrderReq.Dimensions.Length.ToString() : null),
                new JsonStringValue("width", _create_updateOrderReq.Dimensions.Width != null ? _create_updateOrderReq.Dimensions.Width.ToString() : null),
                new JsonStringValue("height", _create_updateOrderReq.Dimensions.Height != null ? _create_updateOrderReq.Dimensions.Height.ToString() : null)
            };

            // Create new Ojbect. type : InsuranceOption
            JsonObjectCollection elementsInsuranceOption = new JsonObjectCollection
            {
                new JsonStringValue("provider", _create_updateOrderReq.InsuranceOptions.Provider != null ? _create_updateOrderReq.InsuranceOptions.Provider.ToString() : string.Empty),
                new JsonStringValue("insureShipment", _create_updateOrderReq.InsuranceOptions.InsureShipment != null ? _create_updateOrderReq.InsuranceOptions.InsureShipment.ToString() : null),
                new JsonStringValue("insuredValue", _create_updateOrderReq.InsuranceOptions.InsuredValue != null ? _create_updateOrderReq.InsuranceOptions.InsuredValue.ToString() : null)
            };

            // Create new Ojbect. type : InternationalOptions
            JsonObjectCollection elementsInternationalOptions = new JsonObjectCollection
            {
                new JsonStringValue("contents", _create_updateOrderReq.InternationalOptions.Contents != null ? _create_updateOrderReq.InternationalOptions.Contents.ToString() : string.Empty),
                new JsonStringValue("customsItems", _create_updateOrderReq.InternationalOptions.CustomsItems != null ? _create_updateOrderReq.InternationalOptions.CustomsItems.ToString() : null)
            };

            // Create new Ojbect. type : AdvancedOptions
            JsonObjectCollection elementsAdvancedOptions = new JsonObjectCollection
            {
                new JsonStringValue("warehouseId", _create_updateOrderReq.AdvancedOptions.WarehouseId != null ? _create_updateOrderReq.AdvancedOptions.WarehouseId.ToString() : null),
                new JsonStringValue("nonMachinable", _create_updateOrderReq.AdvancedOptions.NonMachinable != null ? _create_updateOrderReq.AdvancedOptions.NonMachinable.ToString() : null),
                new JsonStringValue("saturdayDelivery", _create_updateOrderReq.AdvancedOptions.SaturdayDelivery != null ? _create_updateOrderReq.AdvancedOptions.SaturdayDelivery.ToString() : null),
                new JsonStringValue("containsAlcohol", _create_updateOrderReq.AdvancedOptions.ContainsAlcohol != null ? _create_updateOrderReq.AdvancedOptions.ContainsAlcohol.ToString() : null),
                new JsonStringValue("mergedOrSplit", _create_updateOrderReq.AdvancedOptions.MergedOrSplit != null ? _create_updateOrderReq.AdvancedOptions.MergedOrSplit.ToString() : null),
                new JsonArrayCollection("mergedIds"),
                new JsonStringValue("parentId", _create_updateOrderReq.AdvancedOptions.ParentId != null ? _create_updateOrderReq.AdvancedOptions.ParentId.ToString() : null),
                new JsonStringValue("storedId", _create_updateOrderReq.AdvancedOptions.StoreId != null ? _create_updateOrderReq.AdvancedOptions.StoreId.ToString() : null),
                new JsonStringValue("customField1", _create_updateOrderReq.AdvancedOptions.CustomField1 != null ? _create_updateOrderReq.AdvancedOptions.CustomField1.ToString() : string.Empty),
                new JsonStringValue("customField2", _create_updateOrderReq.AdvancedOptions.CustomField2 != null ? _create_updateOrderReq.AdvancedOptions.CustomField2.ToString() : string.Empty),
                new JsonStringValue("customField3", _create_updateOrderReq.AdvancedOptions.CustomField3 != null ? _create_updateOrderReq.AdvancedOptions.CustomField3.ToString() : string.Empty),
                new JsonStringValue("source", _create_updateOrderReq.AdvancedOptions.Source != null ? _create_updateOrderReq.AdvancedOptions.Source.ToString() : string.Empty),
                new JsonStringValue("billToParty", _create_updateOrderReq.AdvancedOptions.BillToParty != null ? _create_updateOrderReq.AdvancedOptions.BillToParty.ToString() : string.Empty),
                new JsonStringValue("billToAccount", _create_updateOrderReq.AdvancedOptions.BillToAccount != null ? _create_updateOrderReq.AdvancedOptions.BillToAccount.ToString() : string.Empty),
                new JsonStringValue("billToPostalCode", _create_updateOrderReq.AdvancedOptions.BillToPostalCode != null ? _create_updateOrderReq.AdvancedOptions.BillToPostalCode.ToString() : string.Empty),
                new JsonStringValue("billToCountryCode", _create_updateOrderReq.AdvancedOptions.BillToCountryCode != null ? _create_updateOrderReq.AdvancedOptions.BillToCountryCode.ToString() : string.Empty),
                new JsonStringValue("billToMyOtherAccount", _create_updateOrderReq.AdvancedOptions.BillToMyOtherAccount != null ? _create_updateOrderReq.AdvancedOptions.BillToMyOtherAccount.ToString() : string.Empty)
            };

            // Create new ItemArray : type OrderItem
            JsonArrayCollection itemArray = new JsonArrayCollection();
            JsonArrayCollection optionArray = new JsonArrayCollection();

            for (int i = 0; i < _create_updateOrderReq.Items.Count; i++)
            {
                JsonObjectCollection elementsItemsWeight = new JsonObjectCollection
                {
                    new JsonStringValue("value", _create_updateOrderReq.Items[i].Weight.Value != null ? _create_updateOrderReq.Items[i].Weight.Value.ToString() : null),
                    new JsonStringValue("units", _create_updateOrderReq.Items[i].Weight.Units != null ? _create_updateOrderReq.Items[i].Weight.Units.ToString() : string.Empty),
                    new JsonStringValue("weightUnits", _create_updateOrderReq.Items[i].Weight.WeightUnits != null ? _create_updateOrderReq.Items[i].Weight.WeightUnits.ToString() : null),
                };


                JsonObjectCollection elementsOptions = new JsonObjectCollection();
                for (int j = 0; j < _create_updateOrderReq.Items[i].Options.Count; j++)
                {
                    elementsOptions = new JsonObjectCollection
                    {
                        new JsonStringValue("name", _create_updateOrderReq.Items[i].Options[j].Name != null ? _create_updateOrderReq.Items[i].Options[j].Name.ToString(): string.Empty),
                        new JsonStringValue("value", _create_updateOrderReq.Items[i].Options[j].Value != null ? _create_updateOrderReq.Items[i].Options[j].Value.ToString() : string.Empty)
                    };
                }
                optionArray.Clear();
                optionArray.Add(elementsOptions);


                JsonObjectCollection elementsItmes = new JsonObjectCollection
                {
                    new JsonStringValue("orderItemId", _create_updateOrderReq.Items[i].OrderItemId != null ? _create_updateOrderReq.Items[i].OrderItemId.ToString() : null),
                    new JsonStringValue("llineItemKey", _create_updateOrderReq.Items[i].LineItemKey != null ? _create_updateOrderReq.Items[i].LineItemKey.ToString() : string.Empty),
                    new JsonStringValue("sku", _create_updateOrderReq.Items[i].Sku != null ? _create_updateOrderReq.Items[i].Sku.ToString() : string.Empty),
                    new JsonStringValue("name", _create_updateOrderReq.Items[i].Name != null ? _create_updateOrderReq.Items[i].Name.ToString() : string.Empty),
                    new JsonStringValue("imageUrl", _create_updateOrderReq.Items[i].ImageUrl != null ? _create_updateOrderReq.Items[i].ImageUrl.ToString() : string.Empty),
                    new JsonObjectCollection("weight", elementsItemsWeight),
                    new JsonStringValue("quantity", _create_updateOrderReq.Items[i].Quantity != null ? _create_updateOrderReq.Items[i].Quantity.ToString() : null),
                    new JsonStringValue("unitPrice", _create_updateOrderReq.Items[i].UnitPrice != null ? _create_updateOrderReq.Items[i].UnitPrice.ToString() : null),
                    new JsonStringValue("taxAmount", _create_updateOrderReq.Items[i].TaxAmount != null ? _create_updateOrderReq.Items[i].TaxAmount.ToString() : null),
                    new JsonStringValue("shippingAmount", _create_updateOrderReq.Items[i].ShippingAmount != null ? _create_updateOrderReq.Items[i].ShippingAmount.ToString() : null),
                    new JsonStringValue("warehouseLocation", _create_updateOrderReq.Items[i].WarehouseLocation != null? _create_updateOrderReq.Items[i].WarehouseLocation.ToString() : string.Empty),
                    new JsonArrayCollection("options", optionArray),
                    new JsonStringValue("productId", _create_updateOrderReq.Items[i].ProductId != null ? _create_updateOrderReq.Items[i].ProductId.ToString() : null),
                    new JsonStringValue("fulfillmentSku", _create_updateOrderReq.Items[i].FulfillmentSku != null ? _create_updateOrderReq.Items[i].FulfillmentSku.ToString() : string.Empty),
                    new JsonStringValue("adjustment", _create_updateOrderReq.Items[i].Adjustment != null ? _create_updateOrderReq.Items[i].Adjustment.ToString() : null),
                    new JsonStringValue("upc", _create_updateOrderReq.Items[i].Upc != null ? _create_updateOrderReq.Items[i].Upc.ToString() : string.Empty)
                };

                itemArray.Add(elementsItmes);
            }

            JsonArrayCollection jarry = new JsonArrayCollection();
            for (int i = 0; i < _create_updateOrderReq.TagIds.Count; i++)
            {
                jarry.Add(new JsonNumericValue(Convert.ToInt32(_create_updateOrderReq.TagIds[i])));
            }

            // Json Request Text
            JsonObjectCollection reqMain = new JsonObjectCollection
            {
                new JsonStringValue("orderNumber", _create_updateOrderReq.OrderNumber != null ? _create_updateOrderReq.OrderNumber.ToString() : string.Empty),
                new JsonStringValue("orderKey", _create_updateOrderReq.OrderKey != null ? _create_updateOrderReq.OrderKey.ToString() : null),
                new JsonStringValue("orderDate", _create_updateOrderReq.OrderDate != null ? _create_updateOrderReq.OrderDate.ToString() : null),
                new JsonStringValue("paymentDate", _create_updateOrderReq.PaymentDate != null ? _create_updateOrderReq.PaymentDate.ToString() : null),
                new JsonStringValue("shipByDate", _create_updateOrderReq.ShipByDate != null ? _create_updateOrderReq.ShipByDate.ToString() : null),
                new JsonStringValue("orderStatus", _create_updateOrderReq.OrderStatus != null ? _create_updateOrderReq.OrderStatus.ToString() : string.Empty),
                new JsonStringValue("customerId", _create_updateOrderReq.OrderId != null? _create_updateOrderReq.OrderId.ToString() : null),
                new JsonStringValue("customerUserName", _create_updateOrderReq.CustomerUsername != null ?_create_updateOrderReq.CustomerUsername.ToString() : string.Empty),
                new JsonStringValue("customerEmail", _create_updateOrderReq.CustomerEmail != null ? _create_updateOrderReq.CustomerEmail.ToString() : string.Empty),
                new JsonObjectCollection("billTo", elementsBillTo),
                new JsonObjectCollection("shipTo", elementsShipTo),
                new JsonArrayCollection("items", itemArray),
                new JsonStringValue("amountPaid", _create_updateOrderReq.AmountPaid != null ? _create_updateOrderReq.AmountPaid.ToString() : null),
                new JsonStringValue("taxAmount", _create_updateOrderReq.TaxAmount != null ? _create_updateOrderReq.TaxAmount.ToString() : null),
                new JsonStringValue("shippingAmount", _create_updateOrderReq.ShippingAmount != null ? _create_updateOrderReq.ShippingAmount.ToString() : null),
                new JsonStringValue("customerNotes", _create_updateOrderReq.CustomerNotes != null ? _create_updateOrderReq.CustomerNotes.ToString() : string.Empty),
                new JsonStringValue("internalNotes", _create_updateOrderReq.InternalNotes != null ? _create_updateOrderReq.InternalNotes.ToString() : string.Empty),
                new JsonStringValue("gift", _create_updateOrderReq.Gift != null ? _create_updateOrderReq.Gift.ToString() : null),
                new JsonStringValue("giftMessage", _create_updateOrderReq.GiftMessage != null ? _create_updateOrderReq.GiftMessage.ToString() : string.Empty),
                new JsonStringValue("paymentMethod", _create_updateOrderReq.PaymentMethod != null ? _create_updateOrderReq.PaymentMethod.ToString() : string.Empty),
                new JsonStringValue("requestedShippingService", _create_updateOrderReq.RequestedShippingService != null ? _create_updateOrderReq.RequestedShippingService.ToString() : string.Empty),
                new JsonStringValue("carrierCode", _create_updateOrderReq.CarrierCode != null ? _create_updateOrderReq.CarrierCode.ToString() : string.Empty),
                new JsonStringValue("serviceCode", _create_updateOrderReq.ServiceCode != null ? _create_updateOrderReq.ServiceCode.ToString() : string.Empty),
                new JsonStringValue("packageCode", _create_updateOrderReq.PackageCode != null ? _create_updateOrderReq.PackageCode.ToString() : string.Empty),
                new JsonStringValue("confirmation", _create_updateOrderReq.Confirmation != null ? _create_updateOrderReq.Confirmation.ToString() : string.Empty),
                new JsonStringValue("shipDate", _create_updateOrderReq.ShipDate != null ? _create_updateOrderReq.ShipDate.ToString() : null),
                new JsonObjectCollection("weight", elementsWeight),
                new JsonObjectCollection("dimnesions", elementsDimensions),
                new JsonObjectCollection("insuranceOptions", elementsInsuranceOption),
                new JsonObjectCollection("internationalOptions", elementsInternationalOptions),
                new JsonObjectCollection("advancedOptions", elementsAdvancedOptions),
                new JsonArrayCollection("tagIds", jarry)
            };

            string reqJson = reqMain.ToString();
            reqJson = reqJson.Replace("\n", "");
            reqJson = reqJson.Replace("\r", "");
            reqJson = reqJson.Replace("\t", "");

            // response
            string jsonText = "{\r\n  \"orderId\": 140335319,\r\n  \"orderNumber\": \"TEST-ORDER-API-DOCS\",\r\n  \"orderKey\": \"0f6bec18-3e89-4881-83aa-f392d84f4c74\",\r\n  \"orderDate\": \"2015-06-29T08:46:27.0000000\",\r\n  \"createDate\": \"2016-02-16T15:16:53.7070000\",\r\n  \"modifyDate\": \"2016-02-16T15:16:53.7070000\",\r\n  \"paymentDate\": \"2015-06-29T08:46:27.0000000\",\r\n  \"shipByDate\": \"2015-07-05T00:00:00.0000000\",\r\n  \"orderStatus\": \"awaiting_shipment\",\r\n  \"customerId\": null,\r\n  \"customerUsername\": \"headhoncho@whitehouse.gov\",\r\n  \"customerEmail\": \"headhoncho@whitehouse.gov\",\r\n  \"billTo\": {\r\n    \"name\": \"The President\",\r\n    \"company\": null,\r\n    \"street1\": null,\r\n    \"street2\": null,\r\n    \"street3\": null,\r\n    \"city\": null,\r\n    \"state\": null,\r\n    \"postalCode\": null,\r\n    \"country\": null,\r\n    \"phone\": null,\r\n    \"residential\": null,\r\n    \"addressVerified\": null\r\n  },\r\n  \"shipTo\": {\r\n    \"name\": \"The President\",\r\n    \"company\": \"US Govt\",\r\n    \"street1\": \"1600 Pennsylvania Ave\",\r\n    \"street2\": \"Oval Office\",\r\n    \"street3\": null,\r\n    \"city\": \"Washington\",\r\n    \"state\": \"DC\",\r\n    \"postalCode\": \"20500\",\r\n    \"country\": \"US\",\r\n    \"phone\": \"555-555-5555\",\r\n    \"residential\": false,\r\n    \"addressVerified\": \"Address validation warning\"\r\n  },\r\n  \"items\": [\r\n    {\r\n      \"orderItemId\": 192210956,\r\n      \"lineItemKey\": \"vd08-MSLbtx\",\r\n      \"sku\": \"ABC123\",\r\n      \"name\": \"Test item #1\",\r\n      \"imageUrl\": null,\r\n      \"weight\": {\r\n        \"value\": 24,\r\n        \"units\": \"ounces\"\r\n      },\r\n      \"quantity\": 2,\r\n      \"unitPrice\": 99.99,\r\n      \"taxAmount\": 2.5,\r\n      \"shippingAmount\": 5,\r\n      \"warehouseLocation\": \"Aisle 1, Bin 7\",\r\n      \"options\": [\r\n        {\r\n          \"name\": \"Size\",\r\n          \"value\": \"Large\"\r\n        }\r\n      ],\r\n      \"productId\": null,\r\n      \"fulfillmentSku\": null,\r\n      \"adjustment\": false,\r\n      \"upc\": \"32-65-98\",\r\n      \"createDate\": \"2016-02-16T15:16:53.707\",\r\n      \"modifyDate\": \"2016-02-16T15:16:53.707\"\r\n    },\r\n    {\r\n      \"orderItemId\": 192210957,\r\n      \"lineItemKey\": null,\r\n      \"sku\": \"DISCOUNT CODE\",\r\n      \"name\": \"10% OFF\",\r\n      \"imageUrl\": null,\r\n      \"weight\": {\r\n        \"value\": 0,\r\n        \"units\": \"ounces\"\r\n      },\r\n      \"quantity\": 1,\r\n      \"unitPrice\": -20.55,\r\n      \"taxAmount\": null,\r\n      \"shippingAmount\": null,\r\n      \"warehouseLocation\": null,\r\n      \"options\": [\r\n        {\r\n          \"name\": null,\r\n          \"value\": null\r\n        }\r\n      ],\r\n      \"productId\": null,\r\n      \"fulfillmentSku\": \"SKU-Discount\",\r\n      \"adjustment\": true,\r\n      \"upc\": null,\r\n      \"createDate\": \"2016-02-16T15:16:53.707\",\r\n      \"modifyDate\": \"2016-02-16T15:16:53.707\"\r\n    }\r\n  ],\r\n  \"orderTotal\": 194.43,\r\n  \"amountPaid\": 218.73,\r\n  \"taxAmount\": 5,\r\n  \"shippingAmount\": 10,\r\n  \"customerNotes\": \"Please ship as soon as possible!\",\r\n  \"internalNotes\": \"Customer called and would like to upgrade shipping\",\r\n  \"gift\": true,\r\n  \"giftMessage\": \"Thank you!\",\r\n  \"paymentMethod\": \"Credit Card\",\r\n  \"requestedShippingService\": \"Priority Mail\",\r\n  \"carrierCode\": \"fedex\",\r\n  \"serviceCode\": \"fedex_2day\",\r\n  \"packageCode\": \"package\",\r\n  \"confirmation\": \"delivery\",\r\n  \"shipDate\": \"2015-07-02\",\r\n  \"holdUntilDate\": null,\r\n  \"weight\": {\r\n    \"value\": 25,\r\n    \"units\": \"ounces\"\r\n  },\r\n  \"dimensions\": {\r\n    \"units\": \"inches\",\r\n    \"length\": 7,\r\n    \"width\": 5,\r\n    \"height\": 6\r\n  },\r\n  \"insuranceOptions\": {\r\n    \"provider\": \"carrier\",\r\n    \"insureShipment\": true,\r\n    \"insuredValue\": 200\r\n  },\r\n  \"internationalOptions\": {\r\n    \"contents\": null,\r\n    \"customsItems\": null,\r\n    \"nonDelivery\": null\r\n  },\r\n  \"advancedOptions\": {\r\n    \"warehouseId\": 9876,\r\n    \"nonMachinable\": false,\r\n    \"saturdayDelivery\": false,\r\n    \"containsAlcohol\": false,\r\n    \"mergedOrSplit\": false,\r\n    \"mergedIds\": [ null ],\r\n    \"parentId\": null,\r\n    \"storeId\": 12345,\r\n    \"customField1\": \"Custom data that you can add to an order. See Custom Field #2 & #3 for more info!\",\r\n    \"customField2\": \"Per UI settings, this information can appear on some carrier's shipping labels. See link below\",\r\n    \"customField3\": \"https://help.shipstation.com/hc/en-us/articles/206639957\",\r\n    \"source\": \"Webstore\",\r\n    \"billToParty\": null,\r\n    \"billToAccount\": null,\r\n    \"billToPostalCode\": null,\r\n    \"billToCountryCode\": null\r\n  },\r\n  \"tagIds\": null,\r\n  \"userId\": null,\r\n  \"externallyFulfilled\": false,\r\n  \"externallyFulfilledBy\": null\r\n}\r\n";

            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(jsonText);
            JsonObjectCollection col = (JsonObjectCollection)obj;

            JsonArrayCollection resItems = (JsonArrayCollection)col["items"];
            JsonObjectCollection elementsBillToRes = (JsonObjectCollection)col["billTo"];
            JsonObjectCollection elementsShipToRes = (JsonObjectCollection)col["shipTo"];
            JsonObjectCollection elementsWeightRes = (JsonObjectCollection)col["weight"];
            JsonObjectCollection elementsDimensionsRes = (JsonObjectCollection)col["dimensions"];
            JsonObjectCollection elementsInsuranceRes = (JsonObjectCollection)col["insuranceOptions"];
            JsonObjectCollection elementsInternationalRes = (JsonObjectCollection)col["internationalOptions"];
            JsonObjectCollection elementsAdvancedRes = (JsonObjectCollection)col["advancedOptions"];

            List<OrderItem> listItems = new List<OrderItem>();

            for (int i = 0; i < resItems.Count; i++)
            {
                JsonObjectCollection elements = (JsonObjectCollection)resItems[i];
                JsonObjectCollection elementsItemWeight = (JsonObjectCollection)elements["weight"];

                JsonArrayCollection elementsItemsOptionsArry = (JsonArrayCollection)elements["options"];

                List<ItemOption> listItemsOptions = new List<ItemOption>();

                for (int j = 0; j < elementsItemsOptionsArry.Count; j++)
                {
                    JsonObjectCollection elementsItemsOptions = (JsonObjectCollection)elementsItemsOptionsArry[j];
                    listItemsOptions.Add(new ItemOption()
                    {
                        Name = Convert.ToString(elementsItemsOptions["name"] != null ? elementsItemsOptions["name"].GetValue() : string.Empty),
                        Value = Convert.ToString(elementsItemsOptions["value"] != null ? elementsItemsOptions["value"].GetValue() : string.Empty)
                    });
                }

                listItems.Add(new OrderItem()
                {
                    OrderItemId = Convert.ToInt32(elements["orderItemId"] != null ? elements["orderItemId"].GetValue() : null),
                    LineItemKey = Convert.ToString(elements["lineItemKey"] != null ? elements["lineItemKey"].GetValue() : string.Empty),
                    Sku = Convert.ToString(elements["sku"] != null ? elements["sku"].GetValue() : string.Empty),
                    Name = Convert.ToString(elements["Name"] != null ? elements["name"].GetValue() : string.Empty),
                    ImageUrl = Convert.ToString(elements["imageUrl"] != null ? elements["imageUrl"].GetValue() : string.Empty),
                    Weight = new Weight()
                    {
                        Value = Convert.ToInt32(elementsItemWeight["value"] != null ? elementsItemWeight["value"].GetValue() : null),
                        Units = Convert.ToString(elementsItemWeight["units"] != null ? elementsItemWeight["units"].GetValue() : string.Empty)
                    },
                    Quantity = Convert.ToInt32(elements["quantity"] != null ? elements["quantity"].GetValue() : null),
                    UnitPrice = Convert.ToDouble(elements["unitPrice"] != null ? elements["unitPrice"].GetValue() : null),
                    TaxAmount = Convert.ToDouble(elements["taxAmount"] != null ? elements["taxAmount"].GetValue() : null),
                    ShippingAmount = Convert.ToInt32(elements["shippingAmount"] != null ? elements["shippingAmount"].GetValue() : null),
                    WarehouseLocation = Convert.ToString(elements["warehouseLocation"] != null ? elements["warehouseLocation"].GetValue() : string.Empty),
                    Options = listItemsOptions,
                    ProductId = Convert.ToInt32(elements["productId"] != null ? elements["productId"].GetValue() : null),
                    FulfillmentSku = Convert.ToString(elements["fulfillmentSku"] != null ? elements["fulfillmentSku"].GetValue() : string.Empty),
                    Adjustment = Convert.ToBoolean(elements["adjustment"] != null ? elements["adjustment"].GetValue() : null),
                    Upc = Convert.ToString(elements["upc"] != null ? elements["upc"].GetValue() : string.Empty),
                    CreateDate = Convert.ToDateTime(elements["createDate"] != null ? elements["createDate"].GetValue() : null),
                    ModifyDate = Convert.ToDateTime(elements["modifyDate"] != null ? elements["modifyDate"].GetValue() : null)
                });

            }

            List<int?> listMergedIds = new List<int?>();

            Create_UpdateOrderResponse create_UpdateOrderResponse = new Create_UpdateOrderResponse()
            {
                OrderId = Convert.ToInt32(col["orderId"] != null ? col["orderId"].GetValue() : null),
                Number = Convert.ToString(col["number"] != null ? col["number"].GetValue() : string.Empty),
                OrderKey = Convert.ToString(col["orderKey"] != null ? col["orderKey"].GetValue() : string.Empty),
                OrderDate = Convert.ToDateTime(col["orderDate"] != null ? col["orderDate"].GetValue() : null),
                CreateDate = Convert.ToDateTime(col["createDate"] != null ? col["createDate"].GetValue() : null),
                ModifyDate = Convert.ToDateTime(col["modifyDate"] != null ? col["modifyDate"].GetValue() : null),
                PaymentDate = Convert.ToDateTime(col["paymentDate"] != null ? col["paymentDate"].GetValue() : null),
                ShipByDate = Convert.ToDateTime(col["shipByDate"] != null ? col["shipByDate"].GetValue() : null),
                OrderStatus = Convert.ToString(col["orderStatus"] != null ? col["orderStatus"].GetValue() : string.Empty),
                CustomerId = Convert.ToInt32(col["customerId"] != null ? col["customerId"].GetValue() : null),
                CustomerUserName = Convert.ToString(col["customerUserName"] != null ? col["customerUserName"].GetValue() : string.Empty),
                CustomerEmail = Convert.ToString(col["customerEmail"] != null ? col["customerEmail"].GetValue() : string.Empty),
                BillTo = new Address()
                {
                    Name = Convert.ToString(elementsBillToRes["name"] != null ? elementsBillToRes["name"].GetValue() : string.Empty),
                    Company = Convert.ToString(elementsBillToRes["company"] != null ? elementsBillToRes["company"].GetValue() : string.Empty),
                    Street1 = Convert.ToString(elementsBillToRes["street1"] != null ? elementsBillToRes["street1"].GetValue() : string.Empty),
                    Street2 = Convert.ToString(elementsBillToRes["street2"] != null ? elementsBillToRes["street2"].GetValue() : string.Empty),
                    Street3 = Convert.ToString(elementsBillToRes["street3"] != null ? elementsBillToRes["street3"].GetValue() : string.Empty),
                    City = Convert.ToString(elementsBillToRes["city"] != null ? elementsBillToRes["city"].GetValue() : string.Empty),
                    State = Convert.ToString(elementsBillToRes["state"] != null ? elementsBillToRes["state"].GetValue() : string.Empty),
                    PostalCode = Convert.ToString(elementsBillToRes["postalCode"] != null ? elementsBillToRes["postalCode"].GetValue() : string.Empty),
                    Country = Convert.ToString(elementsBillToRes["country"] != null ? elementsBillToRes["country"].GetValue() : string.Empty),
                    Phone = Convert.ToString(elementsBillToRes["phone"] != null ? elementsBillToRes["phone"].GetValue() : string.Empty),
                    IsResidential = Convert.ToBoolean(elementsBillToRes["residential"] != null ? elementsBillToRes["residential"].GetValue() : string.Empty),
                    AddressVerified = Convert.ToString(elementsBillToRes["addressVerified"] != null ? elementsBillToRes["addressVerified"].GetValue() : string.Empty)
                },
                ShipTo = new Address()
                {
                    Name = Convert.ToString(elementsShipToRes["name"] != null ? elementsShipToRes["name"].GetValue() : string.Empty),
                    Company = Convert.ToString(elementsShipToRes["company"] != null ? elementsShipToRes["company"].GetValue() : string.Empty),
                    Street1 = Convert.ToString(elementsShipToRes["street1"] != null ? elementsShipToRes["street1"].GetValue() : string.Empty),
                    Street2 = Convert.ToString(elementsShipToRes["street2"] != null ? elementsShipToRes["street2"].GetValue() : string.Empty),
                    Street3 = Convert.ToString(elementsShipToRes["street3"] != null ? elementsShipToRes["street3"].GetValue() : string.Empty),
                    City = Convert.ToString(elementsShipToRes["city"] != null ? elementsShipToRes["city"].GetValue() : string.Empty),
                    State = Convert.ToString(elementsShipToRes["state"] != null ? elementsShipToRes["state"].GetValue() : string.Empty),
                    PostalCode = Convert.ToString(elementsShipToRes["postalCode"] != null ? elementsShipToRes["postalCode"].GetValue() : string.Empty),
                    Country = Convert.ToString(elementsShipToRes["country"] != null ? elementsShipToRes["country"].GetValue() : string.Empty),
                    Phone = Convert.ToString(elementsBillToRes["phone"] != null ? elementsShipToRes["phone"].GetValue() : string.Empty),
                    IsResidential = Convert.ToBoolean(elementsShipToRes["residential"] != null ? elementsShipToRes["residential"].GetValue() : string.Empty),
                    AddressVerified = Convert.ToString(elementsShipToRes["addressVerified"] != null ? elementsShipToRes["addressVerified"].GetValue() : string.Empty)
                },
                Items = listItems,
                OrderTotal = Convert.ToDouble(col["orderTotal"] != null ? col["orderTotal"].GetValue() : null),
                AmountTotal = Convert.ToDouble(col["amountTotal"] != null ? col["amountTotal"].GetValue() : null),
                TaxAmount = Convert.ToInt32(col["taxAmount"] != null ? col["taxAmount"].GetValue() : null),
                CustomerNotes = Convert.ToString(col["customerNotes"] != null ? col["customerNotes"].GetValue() : string.Empty),
                InternalNotes = Convert.ToString(col["internalNotes"] != null ? col["internalNotes"].GetValue() : string.Empty),
                Gift = Convert.ToBoolean(col["gift"] != null ? col["gift"].GetValue() : null),
                GiftMessage = Convert.ToString(col["giftMessage"] != null ? col["giftMessage"].GetValue() : string.Empty),
                PayMentMethod = Convert.ToString(col["paymentMethod"] != null ? col["paymentMethod"].GetValue() : string.Empty),
                RequestedShippingService = Convert.ToString(col["requestedShippingService"] != null ? col["requestedShippingService"].GetValue() : string.Empty),
                CarrierCode = Convert.ToString(col["carrierCode"] != null ? col["carrierCode"].GetValue() : string.Empty),
                Service = Convert.ToString(col["service"] != null ? col["service"].GetValue() : string.Empty),
                PackageCode = Convert.ToString(col["packageCode"] != null ? col["packageCode"].GetValue() : string.Empty),
                Confirmation = Convert.ToString(col["confirmation"] != null ? col["confirmation"].GetValue() : string.Empty),
                ShipDate = Convert.ToDateTime(col["shipDate"] != null ? col["shipDate"].GetValue() : null),
                HoldUntillDate = Convert.ToDateTime(col["holdUntillDate"] != null ? col["holdUntilDate"].GetValue() : null),
                Weight = new Weight()
                {
                    Value = Convert.ToInt32(elementsWeightRes["value"] != null ? elementsWeightRes["value"].GetValue() : null),
                    Units = Convert.ToString(elementsWeightRes["units"] != null ? elementsWeightRes["units"].GetValue() : string.Empty)
                },
                Dimensions = new Dimensions()
                {
                    Units = Convert.ToString(elementsDimensionsRes["units"] != null ? elementsDimensionsRes["units"].GetValue() : string.Empty),
                    Length = Convert.ToInt32(elementsDimensionsRes["length"] != null ? elementsDimensionsRes["length"].GetValue() : null),
                    Width = Convert.ToInt32(elementsDimensionsRes["width"] != null ? elementsDimensionsRes["width"].GetValue() : null),
                    Height = Convert.ToInt32(elementsDimensionsRes["height"] != null ? elementsDimensionsRes["height"].GetValue() : null)
                },
                InsuranceOptions = new InsuranceOptions()
                {
                    Provider = Convert.ToString(elementsInsuranceRes["provider"] != null ? elementsInsuranceRes["provider"].GetValue() : string.Empty),
                    InsureShipment = Convert.ToBoolean(elementsInsuranceRes["insureShipment"] != null ? elementsInsuranceRes["insureShipment"].GetValue() : null),
                    InsuredValue = Convert.ToInt32(elementsInsuranceRes["insuredValue"] != null ? elementsInsuranceRes["insuredValue"].GetValue() : null),
                },
                InternationalOptions = new InternationalOptions()
                {
                    Contents = Convert.ToString(elementsInternationalRes["content"] != null ? elementsInternationalRes["content"].GetValue() : string.Empty),
                    CustomsItems = (CustomsItems)(elementsInternationalRes["customsItems"] != null ? elementsInternationalRes["customsItems"].GetValue() : null),
                    NonDelivery = Convert.ToString(elementsInternationalRes["nonDelivery"] != null ? elementsInternationalRes["nonDelivery"].GetValue() : string.Empty)
                },
                AdvancedOptions = new AdvancedOptions()
                {
                    WarehouseId = Convert.ToInt32(elementsAdvancedRes["warehouseId"] != null ? elementsAdvancedRes["warehouseId"].GetValue() : null),
                    NonMachinable = Convert.ToBoolean(elementsAdvancedRes["nonMachinable"] != null ? elementsAdvancedRes["nonMachinable"].GetValue() : null),
                    SaturdayDelivery = Convert.ToBoolean(elementsAdvancedRes["saturdayDelivery"] != null ? elementsAdvancedRes["saturdayDelivery"].GetValue() : null),
                    ContainsAlcohol = Convert.ToBoolean(elementsAdvancedRes["containsAlcohol"] != null ? elementsAdvancedRes["containsAlcohol"].GetValue() : null),
                    MergedOrSplit = Convert.ToBoolean(elementsAdvancedRes["mergedOrSplit"] != null ? elementsAdvancedRes["mergedOrSplit"].GetValue() : null),
                    MergedIds = listMergedIds,
                    ParentId = Convert.ToInt32(elementsAdvancedRes["parentId"] != null ? elementsAdvancedRes["parentId"].GetValue() : null),
                    StoreId = Convert.ToInt32(elementsAdvancedRes["storeId"] != null ? elementsAdvancedRes["storeId"].GetValue() : null),
                    CustomField1 = Convert.ToString(elementsAdvancedRes["customField1"] != null ? elementsAdvancedRes["customField1"].GetValue() : string.Empty),
                    CustomField2 = Convert.ToString(elementsAdvancedRes["customFiedl2"] != null ? elementsAdvancedRes["customField2"].GetValue() : string.Empty),
                    CustomField3 = Convert.ToString(elementsAdvancedRes["customField3"] != null ? elementsAdvancedRes["customField3"].GetValue() : string.Empty),
                    Source = Convert.ToString(elementsAdvancedRes["source"] != null ? elementsAdvancedRes["source"].GetValue() : string.Empty),
                    BillToParty = Convert.ToString(elementsAdvancedRes["billToParty"] != null ? elementsAdvancedRes["billToParty"].GetValue() : string.Empty),
                    BillToAccount = Convert.ToString(elementsAdvancedRes["billToAccount"] != null ? elementsAdvancedRes["billToAccount"].GetValue() : string.Empty),
                    BillToPostalCode = Convert.ToString(elementsAdvancedRes["billToPostalCode"] != null ? elementsAdvancedRes["billToPostalCode"].GetValue() : string.Empty),
                    BillToCountryCode = Convert.ToString(elementsAdvancedRes["billToCountryCode"] != null ? elementsAdvancedRes["billToCountryCode"].GetValue() : string.Empty)
                },
                TagIds = new List<int?> { },
                UserId = Convert.ToInt32(col["userId"] != null ? col["userId"].GetValue() : null),
                ExternallyFulfilled = Convert.ToBoolean(col["externallyFulfilled"] != null ? col["externallyFulfilled"].GetValue() : null),
                ExternallyFulfilledBy = Convert.ToString(col["externallyFulfilledBy"] != null ? col["externallyFulfilledBy"].GetValue() : string.Empty)
            };
            return create_UpdateOrderResponse;
        }

        public static Create_UpdateMultiOrderResponse CreateUpdateMultiOrder(Create_UpdateMultiOrderRequest _createUpdateMultiOrderReq)
        {
            string url = "http://ssapi.shipstation.com//orders/createorders";

            JsonArrayCollection reqMain = new JsonArrayCollection();
            for (int i = 0; i < _createUpdateMultiOrderReq.Orders.Count; i++)
            {
                JsonObjectCollection elementBillTo = new JsonObjectCollection
                {
                    new JsonStringValue("name", _createUpdateMultiOrderReq.Orders[i].BillTo.Name != null ? _createUpdateMultiOrderReq.Orders[i].BillTo.Name.ToString() : string.Empty),
                    new JsonStringValue("company", _createUpdateMultiOrderReq.Orders[i].BillTo.Company != null ? _createUpdateMultiOrderReq.Orders[i].BillTo.Company.ToString() : string.Empty),
                    new JsonStringValue("street1", _createUpdateMultiOrderReq.Orders[i].BillTo.Street1 != null ? _createUpdateMultiOrderReq.Orders[i].BillTo.Street1.ToString() : string.Empty),
                    new JsonStringValue("street2", _createUpdateMultiOrderReq.Orders[i].BillTo.Street2 != null ? _createUpdateMultiOrderReq.Orders[i].BillTo.Street2.ToString() : string.Empty),
                    new JsonStringValue("street3", _createUpdateMultiOrderReq.Orders[i].BillTo.Street3 != null ? _createUpdateMultiOrderReq.Orders[i].BillTo.Street3.ToString() : string.Empty),
                    new JsonStringValue("city", _createUpdateMultiOrderReq.Orders[i].BillTo.City != null ? _createUpdateMultiOrderReq.Orders[i].BillTo.City.ToString() : string.Empty),
                    new JsonStringValue("state", _createUpdateMultiOrderReq.Orders[i].BillTo.State != null ? _createUpdateMultiOrderReq.Orders[i].BillTo.State.ToString() : string.Empty),
                    new JsonStringValue("postalCode", _createUpdateMultiOrderReq.Orders[i].BillTo.PostalCode != null ? _createUpdateMultiOrderReq.Orders[i].BillTo.PostalCode.ToString() : string.Empty),
                    new JsonStringValue("country", _createUpdateMultiOrderReq.Orders[i].BillTo.Country != null ? _createUpdateMultiOrderReq.Orders[i].BillTo.Country.ToString() : string.Empty),
                    new JsonStringValue("phone", _createUpdateMultiOrderReq.Orders[i].BillTo.Phone != null ? _createUpdateMultiOrderReq.Orders[i].BillTo.Phone.ToString() : string.Empty),
                    new JsonStringValue("residential", _createUpdateMultiOrderReq.Orders[i].BillTo.IsResidential != null ? _createUpdateMultiOrderReq.Orders[i].BillTo.IsResidential.ToString() : string.Empty)
                };

                JsonObjectCollection elementShipTo = new JsonObjectCollection
                {
                    new JsonStringValue("name", _createUpdateMultiOrderReq.Orders[i].ShipTo.Name != null ? _createUpdateMultiOrderReq.Orders[i].ShipTo.Name.ToString() : string.Empty),
                    new JsonStringValue("company", _createUpdateMultiOrderReq.Orders[i].ShipTo.Company != null ? _createUpdateMultiOrderReq.Orders[i].ShipTo.Company.ToString() : string.Empty),
                    new JsonStringValue("street1", _createUpdateMultiOrderReq.Orders[i].ShipTo.Street1 != null ? _createUpdateMultiOrderReq.Orders[i].ShipTo.Street1.ToString() : string.Empty),
                    new JsonStringValue("street2", _createUpdateMultiOrderReq.Orders[i].ShipTo.Street2 != null ? _createUpdateMultiOrderReq.Orders[i].ShipTo.Street2.ToString() : string.Empty),
                    new JsonStringValue("street3", _createUpdateMultiOrderReq.Orders[i].ShipTo.Street3 != null ? _createUpdateMultiOrderReq.Orders[i].ShipTo.Street3.ToString() : string.Empty),
                    new JsonStringValue("city", _createUpdateMultiOrderReq.Orders[i].ShipTo.City != null ? _createUpdateMultiOrderReq.Orders[i].ShipTo.City.ToString() : string.Empty),
                    new JsonStringValue("state", _createUpdateMultiOrderReq.Orders[i].ShipTo.State != null ? _createUpdateMultiOrderReq.Orders[i].ShipTo.State.ToString() : string.Empty),
                    new JsonStringValue("postalCode", _createUpdateMultiOrderReq.Orders[i].ShipTo.PostalCode != null ? _createUpdateMultiOrderReq.Orders[i].ShipTo.PostalCode.ToString() : string.Empty),
                    new JsonStringValue("country", _createUpdateMultiOrderReq.Orders[i].ShipTo.Country != null ? _createUpdateMultiOrderReq.Orders[i].ShipTo.Country.ToString() : string.Empty),
                    new JsonStringValue("phone", _createUpdateMultiOrderReq.Orders[i].ShipTo.Phone != null ? _createUpdateMultiOrderReq.Orders[i].ShipTo.Phone.ToString() : string.Empty),
                    new JsonStringValue("residential", _createUpdateMultiOrderReq.Orders[i].ShipTo.IsResidential != null ? _createUpdateMultiOrderReq.Orders[i].ShipTo.IsResidential.ToString() : string.Empty)
                };

                JsonArrayCollection itemList = new JsonArrayCollection();
                for (int j = 0; j < _createUpdateMultiOrderReq.Orders[i].Items.Count; j++)
                {
                    JsonObjectCollection elementItemsWeight = new JsonObjectCollection
                    {
                        new JsonStringValue("value", _createUpdateMultiOrderReq.Orders[i].Items[j].Weight.Value != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].Weight.Value.ToString() : null),
                        new JsonStringValue("units", _createUpdateMultiOrderReq.Orders[i].Items[j].Weight.Units != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].Weight.Units.ToString() : string.Empty)
                    };

                    JsonArrayCollection itemsOptions = new JsonArrayCollection();
                    JsonObjectCollection elementItemsOptions = null;
                    for (int k = 0; k < _createUpdateMultiOrderReq.Orders[i].Items[j].Options.Count; k++)
                    {
                        elementItemsOptions = new JsonObjectCollection
                        {
                            new JsonStringValue("name", _createUpdateMultiOrderReq.Orders[i].Items[j].Options[k].Name != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].Options[k].Name.ToString() : string.Empty),
                            new JsonStringValue("value", _createUpdateMultiOrderReq.Orders[i].Items[j].Options[k].Value != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].Options[k].Value.ToString() : string.Empty)
                        };
                        itemsOptions.Add(elementItemsOptions);
                    }

                    JsonObjectCollection items = new JsonObjectCollection
                    {
                        new JsonStringValue("lineItemKey", _createUpdateMultiOrderReq.Orders[i].Items[j].LineItemKey != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].LineItemKey.ToString() : string.Empty),
                        new JsonStringValue("sku", _createUpdateMultiOrderReq.Orders[i].Items[j].Sku != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].Sku.ToString() : string.Empty),
                        new JsonStringValue("name", _createUpdateMultiOrderReq.Orders[i].Items[j].Name != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].Name.ToString() : string.Empty),
                        new JsonStringValue("image", _createUpdateMultiOrderReq.Orders[i].Items[j].ImageUrl != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].ImageUrl.ToString() : string.Empty),
                        new JsonObjectCollection("weight", elementItemsWeight),
                        new JsonStringValue("quantity", _createUpdateMultiOrderReq.Orders[i].Items[j].Quantity != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].Quantity.ToString() : null),
                        new JsonStringValue("unitPrice", _createUpdateMultiOrderReq.Orders[i].Items[j].UnitPrice != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].UnitPrice.ToString() : null),
                        new JsonStringValue("taxAmount", _createUpdateMultiOrderReq.Orders[i].Items[j].TaxAmount != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].TaxAmount.ToString() : null),
                        new JsonStringValue("shippingAmount", _createUpdateMultiOrderReq.Orders[i].Items[j].ShippingAmount != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].ShippingAmount.ToString() : null),
                        new JsonStringValue("warehouseLocation", _createUpdateMultiOrderReq.Orders[i].Items[j].WarehouseLocation != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].WarehouseLocation.ToString() : null),
                        new JsonArrayCollection("options", itemsOptions),
                        new JsonStringValue("productId", _createUpdateMultiOrderReq.Orders[i].Items[j].ProductId != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].ProductId.ToString() : null),
                        new JsonStringValue("fulfillmentSku", _createUpdateMultiOrderReq.Orders[i].Items[j].FulfillmentSku != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].FulfillmentSku.ToString() : string.Empty),
                        new JsonStringValue("adjustment", _createUpdateMultiOrderReq.Orders[i].Items[j].Adjustment != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].Adjustment.ToString() : null),
                        new JsonStringValue("upc", _createUpdateMultiOrderReq.Orders[i].Items[j].Upc != null ? _createUpdateMultiOrderReq.Orders[i].Items[j].Upc.ToString() : string.Empty)
                    };
                    itemList.Add(items);
                }

                JsonObjectCollection elementWeight = new JsonObjectCollection
                {
                    new JsonStringValue("value", _createUpdateMultiOrderReq.Orders[i].Weight.Value != null ? _createUpdateMultiOrderReq.Orders[i].Weight.Value.ToString() : null),
                    new JsonStringValue("units", _createUpdateMultiOrderReq.Orders[i].Weight.Units != null ? _createUpdateMultiOrderReq.Orders[i].Weight.Units.ToString() : string.Empty)

                };

                JsonObjectCollection elementDimensions = new JsonObjectCollection
                {
                    new JsonStringValue("units", _createUpdateMultiOrderReq.Orders[i].Dimensions.Units != null ? _createUpdateMultiOrderReq.Orders[i].Dimensions.Units.ToString() : string.Empty),
                    new JsonStringValue("length", _createUpdateMultiOrderReq.Orders[i].Dimensions.Length != null ? _createUpdateMultiOrderReq.Orders[i].Dimensions.Length.ToString() : string.Empty),
                    new JsonStringValue("width", _createUpdateMultiOrderReq.Orders[i].Dimensions.Width != null ? _createUpdateMultiOrderReq.Orders[i].Dimensions.Width.ToString() : string.Empty),
                    new JsonStringValue("height", _createUpdateMultiOrderReq.Orders[i].Dimensions.Height != null ? _createUpdateMultiOrderReq.Orders[i].Dimensions.Height.ToString() : string.Empty),
                };

                JsonObjectCollection elementInsuranceOptions = new JsonObjectCollection
                {
                    new JsonStringValue("provider", _createUpdateMultiOrderReq.Orders[i].InsuranceOptions.Provider != null ? _createUpdateMultiOrderReq.Orders[i].InsuranceOptions.Provider.ToString() : string.Empty),
                    new JsonStringValue("insureShipment", _createUpdateMultiOrderReq.Orders[i].InsuranceOptions.InsureShipment != null ? _createUpdateMultiOrderReq.Orders[i].InsuranceOptions.InsureShipment.ToString() : null),
                    new JsonStringValue("insuredValue", _createUpdateMultiOrderReq.Orders[i].InsuranceOptions.InsuredValue != null ? _createUpdateMultiOrderReq.Orders[i].InsuranceOptions.InsuredValue.ToString() : null)
                };

                JsonObjectCollection elementInternationalOptions = new JsonObjectCollection
                {
                    new JsonStringValue("contents", _createUpdateMultiOrderReq.Orders[i].InternationalOptions.Contents != null ? _createUpdateMultiOrderReq.Orders[i].InternationalOptions.Contents.ToString() : string.Empty),
                    new JsonStringValue("customsItems", _createUpdateMultiOrderReq.Orders[i].InternationalOptions.CustomsItems != null ? _createUpdateMultiOrderReq.Orders[i].InternationalOptions.CustomsItems.ToString() : string.Empty)
                };

                JsonArrayCollection jarr = new JsonArrayCollection();
                for (int j = 0; j < _createUpdateMultiOrderReq.Orders[i].TagIds.Count; j++)
                {
                    jarr.Add(new JsonNumericValue(Convert.ToInt32(_createUpdateMultiOrderReq.Orders[i].TagIds[j])));
                }

                JsonObjectCollection elemenAdvancedOptions = new JsonObjectCollection
                {
                    new JsonStringValue("warehouseId", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.WarehouseId != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.WarehouseId.ToString() : null),
                    new JsonStringValue("nonMachinable", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.NonMachinable != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.NonMachinable.ToString() : null),
                    new JsonStringValue("saturdayDelivery", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.SaturdayDelivery != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.SaturdayDelivery.ToString() : null),
                    new JsonStringValue("containsAlcohol", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.ContainsAlcohol != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.SaturdayDelivery.ToString() : null),
                    new JsonStringValue("mergedOrSplit", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.MergedOrSplit != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.MergedOrSplit.ToString() : null),
                    new JsonObjectCollection("mergedIds"),
                    new JsonStringValue("parentId", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.ParentId != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.ParentId.ToString() : null),
                    new JsonStringValue("storeId", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.StoreId != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.StoreId.ToString() : null),
                    new JsonStringValue("customField1", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.CustomField1 != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.CustomField1.ToString() : null),
                    new JsonStringValue("customField2", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.CustomField2 != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.CustomField2.ToString() : null),
                    new JsonStringValue("customField3", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.CustomField3 != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.CustomField3.ToString() : null),
                    new JsonStringValue("source", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.Source != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.Source.ToString() : null),
                    new JsonStringValue("billToParty", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.BillToParty != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.BillToParty.ToString() : null),
                    new JsonStringValue("billToAccount", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.BillToAccount != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.BillToAccount.ToString() : null),
                    new JsonStringValue("billToPostalCode", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.BillToPostalCode != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.BillToPostalCode.ToString() : null),
                    new JsonStringValue("billToCountryCode", _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.BillToCountryCode != null ? _createUpdateMultiOrderReq.Orders[i].AdvancedOptions.BillToCountryCode.ToString() : null)
                };


                JsonObjectCollection jobj = new JsonObjectCollection
                {
                    new JsonStringValue("orderNumber", _createUpdateMultiOrderReq.Orders[i].OrderNumber != null ? _createUpdateMultiOrderReq.Orders[i].OrderNumber.ToString() : string.Empty),
                    new JsonStringValue("orderKey", _createUpdateMultiOrderReq.Orders[i].OrderKey != null ? _createUpdateMultiOrderReq.Orders[i].OrderKey.ToString() : string.Empty),
                    new JsonStringValue("orderDate", _createUpdateMultiOrderReq.Orders[i].OrderDate != null ? _createUpdateMultiOrderReq.Orders[i].OrderDate.ToString() : null),
                    new JsonStringValue("paymentDate", _createUpdateMultiOrderReq.Orders[i].PaymentDate != null ? _createUpdateMultiOrderReq.Orders[i].PaymentDate.ToString() : null),
                    new JsonStringValue("shipByDate", _createUpdateMultiOrderReq.Orders[i].ShipByDate != null ? _createUpdateMultiOrderReq.Orders[i].ShipByDate.ToString() : null),
                    new JsonStringValue("orderStatus", _createUpdateMultiOrderReq.Orders[i].OrderStatus != null ? _createUpdateMultiOrderReq.Orders[i].OrderStatus.ToString() : string.Empty),
                    new JsonStringValue("customerId", _createUpdateMultiOrderReq.Orders[i].CustomerId != null ? _createUpdateMultiOrderReq.Orders[i].CustomerId.ToString() : null),
                    new JsonStringValue("customerUsername", _createUpdateMultiOrderReq.Orders[i].CustomerUsername != null ? _createUpdateMultiOrderReq.Orders[i].CustomerUsername.ToString() : string.Empty),
                    new JsonStringValue("customerEmail", _createUpdateMultiOrderReq.Orders[i].CustomerEmail != null ? _createUpdateMultiOrderReq.Orders[i].CustomerEmail.ToString() : null),
                    new JsonObjectCollection("billTo", elementBillTo),
                    new JsonObjectCollection("shipTo", elementShipTo),
                    new JsonArrayCollection("items", itemList),
                    new JsonStringValue("amountPaid", _createUpdateMultiOrderReq.Orders[i].AmountPaid != null ? _createUpdateMultiOrderReq.Orders[i].AmountPaid.ToString() : null),
                    new JsonStringValue("taxAmount", _createUpdateMultiOrderReq.Orders[i].TaxAmount != null ? _createUpdateMultiOrderReq.Orders[i].TaxAmount.ToString() : null),
                    new JsonStringValue("shippingAmount", _createUpdateMultiOrderReq.Orders[i].ShippingAmount != null ? _createUpdateMultiOrderReq.Orders[i].ShippingAmount.ToString() : null),
                    new JsonStringValue("customerNotes", _createUpdateMultiOrderReq.Orders[i].CustomerNotes != null ? _createUpdateMultiOrderReq.Orders[i].CustomerNotes.ToString() : string.Empty),
                    new JsonStringValue("internalNotes", _createUpdateMultiOrderReq.Orders[i].InternalNotes != null ? _createUpdateMultiOrderReq.Orders[i].InternalNotes.ToString() : string.Empty),
                    new JsonStringValue("gift", _createUpdateMultiOrderReq.Orders[i].Gift != null ? _createUpdateMultiOrderReq.Orders[i].Gift.ToString() : null),
                    new JsonStringValue("giftMessage", _createUpdateMultiOrderReq.Orders[i].GiftMessage != null ? _createUpdateMultiOrderReq.Orders[i].GiftMessage.ToString() : string.Empty),
                    new JsonStringValue("paymentMethod", _createUpdateMultiOrderReq.Orders[i].PaymentMethod != null ? _createUpdateMultiOrderReq.Orders[i].PaymentMethod.ToString() : string.Empty),
                    new JsonStringValue("requestedShippingService", _createUpdateMultiOrderReq.Orders[i].RequestedShippingService != null ? _createUpdateMultiOrderReq.Orders[i].RequestedShippingService.ToString() : string.Empty),
                    new JsonStringValue("carrierCode", _createUpdateMultiOrderReq.Orders[i].CarrierCode != null ? _createUpdateMultiOrderReq.Orders[i].CarrierCode.ToString() : string.Empty),
                    new JsonStringValue("serviceCode", _createUpdateMultiOrderReq.Orders[i].ServiceCode != null ? _createUpdateMultiOrderReq.Orders[i].ServiceCode.ToString() : string.Empty),
                    new JsonStringValue("packageCode", _createUpdateMultiOrderReq.Orders[i].PackageCode != null ? _createUpdateMultiOrderReq.Orders[i].PackageCode.ToString() : string.Empty),
                    new JsonStringValue("confirmation", _createUpdateMultiOrderReq.Orders[i].Confirmation != null ? _createUpdateMultiOrderReq.Orders[i].Confirmation.ToString() : string.Empty),
                    new JsonStringValue("shipDate", _createUpdateMultiOrderReq.Orders[i].ShipDate != null ? _createUpdateMultiOrderReq.Orders[i].ShipDate.ToString() : null),
                    new JsonObjectCollection("weight", elementWeight),
                    new JsonObjectCollection("dimensions", elementDimensions),
                    new JsonObjectCollection("insuranceOptions", elementInsuranceOptions),
                    new JsonObjectCollection("internationalOptions", elementInternationalOptions),
                    new JsonObjectCollection("advancedOptions", elemenAdvancedOptions),
                    new JsonArrayCollection("tagIds", jarr)
                };
                reqMain.Add(jobj);
            }

            string reqJson = reqMain.ToString();
            reqJson = reqJson.Replace("\n", "");
            reqJson = reqJson.Replace("\r", "");
            reqJson = reqJson.Replace("\t", "");

            // response
            string jsonText = "{\r\n    \"hasErrors\": false,\r\n    \"results\": [\r\n        {\r\n            \"orderId\": 168426889,\r\n            \"orderNumber\": \"TEST-ORDER-API-DOCS-01\",\r\n            \"orderKey\": \"0f6bec18-3e89-4881-83aa-f392d84f4c74\",\r\n            \"success\": true,\r\n            \"errorMessage\": null\r\n        },\r\n        {\r\n            \"orderId\": 168432343,\r\n            \"orderNumber\": \"TEST-ORDER-API-DOCS-02\",\r\n            \"orderKey\": \"0d6bec18-3e79-4981-83ca-f392d84f4c19\",\r\n            \"success\": true,\r\n            \"errorMessage\": null\r\n        }\r\n    ]\r\n}\r\n";

            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(jsonText);
            JsonObjectCollection col = (JsonObjectCollection)obj;

            JsonArrayCollection resResult = (JsonArrayCollection)col["results"];
            List<MultiOrdersResponseResults> listMultiOrders = new List<MultiOrdersResponseResults>();
            for (int i = 0; i < resResult.Count; i++)
            {
                JsonObjectCollection element = (JsonObjectCollection)resResult[i];

                listMultiOrders.Add(new MultiOrdersResponseResults()
                {
                    OrderId = Convert.ToInt32(element["orderId"] != null ? element["orderId"].GetValue() : null),
                    OrderNumber = Convert.ToString(element["orderNumber"] != null ? element["orderNumber"].GetValue() : string.Empty),
                    OrderKey = Convert.ToString(element["orderKey"] != null ? element["orderKey"].GetValue() : string.Empty),
                    Success = Convert.ToBoolean(element["success"] != null ? element["success"].GetValue() : null),
                    ErrorMessage = Convert.ToString(element["errorMessage"] != null ? element["errorMessage"].GetValue() : string.Empty)
                });
            }

            Create_UpdateMultiOrderResponse multiOrderRes = new Create_UpdateMultiOrderResponse
            {
                HasError = Convert.ToBoolean(col["result"] != null ? col["result"].GetValue() : null),
                Results = listMultiOrders
            };


            return multiOrderRes;
        }

        public static DeleteOrderResponse DeleteOrders(DeleteOrderRequest _delectOrdersReq)
        {
            string url = "http://ssapi.shipstation.com/orders/orderId";
            // method DELECT

            string jsonText = "{\r\n  \"success\": true,\r\n  \"message\": \"The requested order has been deleted.\"\r\n}\r\n";

            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(jsonText);
            JsonObjectCollection col = (JsonObjectCollection)obj;

            DeleteOrderResponse delectOrdersRes = new DeleteOrderResponse
            {
                Success = Convert.ToBoolean(col["success"] != null ? col["success"].GetValue() : null),
                Message = Convert.ToString(col["message"] != null ? col["message"].GetValue() : string.Empty)
            };
            return delectOrdersRes;
        }

        public static HoldOrderResponse HoldOrders(HoldOrderRequest _holdOrdersReq)
        {
            string url = "http://ssapi.shipstation.com/orders/holduntil";
            // method : POST

            JsonObjectCollection reqMain = new JsonObjectCollection
            {
                new JsonStringValue("orderId", _holdOrdersReq.OrderId != null ? _holdOrdersReq.OrderId.ToString() : null),
                new JsonStringValue("holdUntilDate", _holdOrdersReq.HoldUntilDate != null ? _holdOrdersReq.HoldUntilDate.ToString() : null)
            };
            
            string reqJson = reqMain.ToString();
            reqJson = reqJson.Replace("\n", "");
            reqJson = reqJson.Replace("\r", "");
            reqJson = reqJson.Replace("\t", "");

            //response
            string jsonText = " {\r\n  \"success\": true,\r\n  \"message\": \"Order held successfully.\"\r\n}\r\n";
            
            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(jsonText);
            JsonObjectCollection col = (JsonObjectCollection)obj;

            HoldOrderResponse holdOrdersRes = new HoldOrderResponse
            {
                Success = Convert.ToBoolean(col["success"] != null ? col["success"].GetValue() : null),
                Message = Convert.ToString(col["message"] != null ? col["message"].GetValue() : string.Empty),
            };

            return holdOrdersRes;
        }
    }
}
